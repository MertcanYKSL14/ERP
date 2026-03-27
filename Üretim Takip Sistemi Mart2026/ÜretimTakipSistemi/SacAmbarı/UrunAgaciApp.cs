
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ÜretimTakipSistemi.BusinessLogic.Abstract;
using ÜretimTakipSistemi.BusinessLogic.DependencyInjectionTools.Ninject;
using ÜretimTakipSistemi.Entities.Concrete;

namespace ÜretimTakipSistemi.SacAmbarı
{
    public partial class UrunAgaciApp : Form
    {
        private TreeOperationsManager _treeManager;
        private readonly IUrunAgaciService _urunAgaciService;
        private string connectionString = @"Data Source=192.168.1.144,1433;Initial Catalog=UrunAgaciDB;User ID=ADMIN;Password=1;MultipleActiveResultSets=True;";

        public UrunAgaciApp()
        {
            InitializeComponent();
            _urunAgaciService = InstanceFactory.GetInstance<IUrunAgaciService>();
            TreeViewTasarimAyarla();
            SetupModernInterface();
            _treeManager = new TreeOperationsManager
            (
                treeView1,
                connectionString,
                () => LoadProductTreeWithHierarchy()
            );
            _treeManager.SetupContextMenu();
            this.treeView1.Dock = DockStyle.Fill;

            //Treeview1 Metinsel İfade Boyutlandırmaları
            SplitContainer splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.SplitterDistance = 400; // Sol taraftaki ağaç başlangıçta 400 piksel olsun
            splitContainer.SplitterWidth = 5;      // Ayırıcı çizginin kalınlığı 
            txtUrunDetay.Dock = DockStyle.Fill;
            txtUrunDetay.Multiline = true;
            this.Controls.Remove(treeView1);
            this.Controls.Remove(txtUrunDetay);
            splitContainer.Panel1.Controls.Add(treeView1);
            splitContainer.Panel2.Controls.Add(txtUrunDetay);
            this.Controls.Add(splitContainer);
            splitContainer.BringToFront();
            LoadProductTreeWithHierarchy();
        }
        private void SetupModernInterface()
        {
            txtSearch.TextChanged += TxtSearch_TextChanged;
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
            Color sidebarColor = Color.FromArgb(0, 122, 204);

            panelTop.BackColor = sidebarColor;

            foreach (Control ctrl in panelTop.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.Font = new Font("Segoe UI Semibold", 10.5F);
                    btn.Height = 45;

                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(27, 221, 225);
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.Transparent;
                }
            }
        }
        //--------------------------------------------------------------------------------------------------//
        //bul textboxı
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText) || txtSearch.Text == "Ürün ismi veya kodu giriniz...")
            {
                treeView1.BeginUpdate();
                if (showingHierarchy)
                {
                    LoadProductTreeWithHierarchy();
                }
                else
                {
                    LoadAllProductsFlatList();
                }
                treeView1.EndUpdate();
                return;
            }

            treeView1.BeginUpdate();
            if (showingHierarchy)
            {
                foreach (TreeNode node in treeView1.Nodes)
                {
                    ApplyStrictFilter(node, searchText, false);
                }
            }
            else
            {
                FilterFlatList(searchText);
            }
            treeView1.EndUpdate();
        }
        private void FilterFlatList(string searchText)
        {
            LoadAllProductsFlatList();

            for (int i = treeView1.Nodes.Count - 1; i >= 0; i--)
            {
                if (!treeView1.Nodes[i].Text.ToLower().Contains(searchText))
                {
                    treeView1.Nodes.RemoveAt(i);
                }
                else
                {

                    treeView1.Nodes[i].ForeColor = Color.Blue;
                    treeView1.Nodes[i].NodeFont = new Font(treeView1.Font, FontStyle.Bold);
                }
            }
        }
        private bool ApplyStrictFilter(TreeNode node, string searchText, bool forceHighlight)
        {
            bool isCurrentMatch = node.Text.ToLower().Contains(searchText);
            bool shouldHighlight = forceHighlight || isCurrentMatch;
            bool anyChildMatch = false;

            foreach (TreeNode child in node.Nodes)
            {

                if (ApplyStrictFilter(child, searchText, shouldHighlight))
                {
                    anyChildMatch = true;
                }
            }

            if (shouldHighlight || anyChildMatch)
            {
                if (isCurrentMatch)
                {
                    node.ForeColor = Color.Blue;
                    node.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
                }
                else if (forceHighlight)
                {
                    node.ForeColor = Color.Green;
                    node.NodeFont = new Font(treeView1.Font, FontStyle.Regular);
                }
                else
                {
                    node.ForeColor = Color.Black;
                }

                node.Expand();
                return true;
            }
            else
            {
                node.ForeColor = Color.LightGray;
                node.Collapse();
                return false;
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Ürün ismi veya kodu giriniz...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }
        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Ürün ismi veya kodu giriniz...";
                txtSearch.ForeColor = Color.Gray;
            }
        }
        //--------------------------------------------------------------------------------------------------//

        // AĞAÇ YAPISINI OLUŞTURAN ANA METOD
        private void LoadProductTreeWithHierarchy()
        {
            treeView1.Nodes.Clear();
            lblStatus.Text = "Ürün ağacı yükleniyor...";

            try
            {
                _urunAgaciService.VeritabaniHazirla(connectionString);

                List<UrunAgaciUrunDto> kokUrunler = _urunAgaciService.GetUrunAgaci(connectionString);
                foreach (UrunAgaciUrunDto kokUrun in kokUrunler)
                {
                    treeView1.Nodes.Add(UrunAgaciNodeOlustur(kokUrun, true));
                }

                lblStatus.Text = $"{kokUrunler.Count} ana ürün yüklendi.";

                if (kokUrunler.Count == 0)
                {
                    TreeNode infoNode = new TreeNode("⚠️ Hiç ürün bulunamadı. 'Test Verisi Ekle' butonuna tıklayın.");
                    treeView1.Nodes.Add(infoNode);
                }
                else if (treeView1.Nodes.Count > 0)
                {
                    treeView1.Nodes[0].Expand();
                }
            }
            catch (SqlException sqlEx)
            {
                lblStatus.Text = $"SQL Hatası: {sqlEx.Message}";
                MessageBox.Show($"SQL Hatası: {sqlEx.Message}", "Bağlantı Hatası",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Hata: {ex.Message}";
                MessageBox.Show($"Hata: {ex.Message}", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeNode UrunAgaciNodeOlustur(UrunAgaciUrunDto urun, bool anaUrunMu)
        {
            string nodeText = anaUrunMu
                ? $"{urun.UrunKodu} - {urun.UrunAdi}"
                : $"{urun.UrunAdi} ({urun.UrunKodu}) - {urun.Miktar} {urun.Birim}";

            TreeNode node = new TreeNode(nodeText);
            node.Tag = new UrunNodeInfo
            {
                UrunID = urun.UrunId,
                UrunKodu = urun.UrunKodu,
                UrunAdi = urun.UrunAdi
            };

            if (anaUrunMu)
            {
                node.NodeFont = new Font(treeView1.Font, FontStyle.Bold);
                node.ToolTipText = $"{urun.UrunKodu} - {urun.UrunAdi}";
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.ForeColor = Color.DarkBlue;
            }
            else
            {
                node.ForeColor = Color.DarkGreen;
            }

            foreach (UrunAgaciUrunDto altUrun in urun.AltUrunler)
            {
                node.Nodes.Add(UrunAgaciNodeOlustur(altUrun, false));
            }

            return node;
        }
        private void TreeViewTasarimAyarla()
        {
            treeView1.Indent = 14;                     // Daha az sağa kayma
            treeView1.ItemHeight = 26;                 // Daha kompakt
            treeView1.ShowNodeToolTips = true;         // Tooltip aktif
            treeView1.HideSelection = false;
            treeView1.BorderStyle = BorderStyle.None;

            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.DrawNode += TreeView1_DrawNode;
            treeView1.AfterExpand += (s, e) => AyarlaYatayScroll();
            treeView1.AfterCollapse += (s, e) => AyarlaYatayScroll();
        }
        private void AyarlaYatayScroll()
        {
            int maxWidth = 0;
            using (Graphics g = treeView1.CreateGraphics())
            {
                HesaplaMaxGenislik(treeView1.Nodes, g, ref maxWidth);
            }
        }

        private void HesaplaMaxGenislik(TreeNodeCollection nodes, Graphics g, ref int maxWidth)
        {
            foreach (TreeNode node in nodes)
            {
                Font f = node.NodeFont ?? treeView1.Font;
                int textWidth = (int)g.MeasureString(node.Text, f).Width;
                int indent = (node.Level + 1) * treeView1.Indent + 40;
                int total = textWidth + indent;
                if (total > maxWidth) maxWidth = total;
                if (node.IsExpanded)
                    HesaplaMaxGenislik(node.Nodes, g, ref maxWidth);
            }
        }

        private void TreeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Font nodeFont = e.Node.NodeFont ?? treeView1.Font;

            Color backColor = e.Node.IsSelected
                ? Color.FromArgb(0, 122, 204)
                : Color.White;

            Color textColor = e.Node.IsSelected
                ? Color.White
                : (e.Node.Level == 0 ? Color.Black : Color.DimGray);
            Rectangle drawRect = new Rectangle(
                e.Bounds.X,
                e.Bounds.Y,
                treeView1.ClientSize.Width - e.Bounds.X,  // sağa doğru tam genişlik
                e.Bounds.Height);

            using (SolidBrush backBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backBrush, drawRect);
            }

            TextRenderer.DrawText(
                e.Graphics,
                e.Node.Text,
                nodeFont,
                drawRect,
                textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.GlyphOverhangPadding);

            e.DrawDefault = false;
        }


        // BUTON EVENT'LERİ - ÇALIŞIR HALDE
        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadProductTreeWithHierarchy();
        }

        private bool isExpanded = false; // Ağacın açık mı kapalı mı olduğunu tutan değişken,daralt-genişlet btn
        private void btnToggleTree_Click(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                // Şu an açık, o halde kapat (daralt)
                treeView1.CollapseAll();
                btnTumunuAc.Text = "▼ Tümünü Genişlet";
                btnTumunuAc.BackColor = Color.DimGray;
                isExpanded = false;
                lblStatus.Text = "Tüm dallar daraltıldı.";
            }
            else
            {
                // Şu an kapalı, o halde aç (genişlet)
                treeView1.ExpandAll();
                btnTumunuAc.Text = "▲ Tümünü Daralt";
                btnTumunuAc.BackColor = Color.DarkSlateGray;
                isExpanded = true;
                lblStatus.Text = "Tüm dallar genişletildi.";
            }
        }
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            using (var form = new SimpleUrunEkleForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        UrunAgaciKaydetTalep talep = new UrunAgaciKaydetTalep
                        {
                            UrunKodu = form.UrunKodu,
                            UrunAdi = form.UrunAdi,
                            AltUrunEklenecek = form.AltUrunEklenecek,
                            AltUrunKodu = form.AltUrunKodu,
                            AltUrunAdi = form.AltUrunAdi,
                            Miktar = form.Miktar
                        };

                        _urunAgaciService.KaydetUrunAgaci(connectionString, talep);
                        MessageBox.Show("İşlem başarıyla tamamlandı.");
                        LoadProductTreeWithHierarchy();
                    }
                    catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
                }
            }
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            TreeNode secilenUrun = e.Node;

            string detay = "ÜRÜN BİLGİ KARTI" + Environment.NewLine;
            detay += "----------------------------" + Environment.NewLine;
            detay += "Ürün Adı    : " + secilenUrun.Text + Environment.NewLine;
            detay += "Ürün Seviyesi: " + (secilenUrun.Level + 1).ToString() + Environment.NewLine;
            detay += "Bağlı Olduğu: " + (secilenUrun.Parent != null ? secilenUrun.Parent.Text : "Ana Ürün") + Environment.NewLine;
            detay += "Alt Parça Sayısı: " + secilenUrun.Nodes.Count.ToString() + Environment.NewLine;
            detay += "----------------------------" + Environment.NewLine;
            detay += "Tarih: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            txtUrunDetay.Text = detay;
        }

        private void UrunSil_Btn_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.");
                return;
            }
            if (!(treeView1.SelectedNode.Tag is UrunNodeInfo silInfo)) return;
            int seciliID = silInfo.UrunID;
            string urunAdi = silInfo.UrunAdi;
            

            DialogResult onay = MessageBox.Show(
                $"'{urunAdi}' ürünü SİSTEMDEN TAMAMEN SİLİNECEKTİR.\n\n" +
                "Bu işlem geri alınamaz ve bu ürünün kullanıldığı tüm reçetelerden bu ürün kaldırılır. Onaylıyor musunuz?",
                "Kalıcı Silme Onayı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                TamamenSil(seciliID);
            }
        }

        private void TamamenSil(int urunID)
        {
            try
            {
                _urunAgaciService.SilUrunAgaci(connectionString, urunID);
                lblStatus.Text = "Ürün sistemden tamamen kaldırıldı.";
                btnYenile.PerformClick();
                txtUrunDetay.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme başarısız: " + ex.Message);
            }
        }
        private bool showingHierarchy = true;
        private void LoadAllProductsFlatList()
        {
            treeView1.Nodes.Clear();
            lblStatus.Text = "Tüm ürünler listeleniyor...";

            try
            {
                List<UrunAgaciUrunDto> urunler = _urunAgaciService.GetTumUrunler(connectionString);
                foreach (UrunAgaciUrunDto urun in urunler)
                {
                    TreeNode node = new TreeNode($"{urun.UrunAdi} ({urun.UrunKodu})");
                    node.Tag = new UrunNodeInfo
                    {
                        UrunID = urun.UrunId,
                        UrunKodu = urun.UrunKodu,
                        UrunAdi = urun.UrunAdi
                    };
                    node.ForeColor = Color.DarkSlateBlue;
                    treeView1.Nodes.Add(node);
                }

                lblStatus.Text = $"{urunler.Count} ürün listelendi.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void Gecis_Btn_Click(object sender, EventArgs e)
        {
            if (showingHierarchy)
            {
                // Düz Listeye Geç
                LoadAllProductsFlatList();
                showingHierarchy = false;
                Gecis_Btn.Text = "Ürün Ağacına Dön";
                lblStatus.Text = "Tüm ürünler listelendi (Düz Liste).";
                Gecis_Btn.BackColor = Color.Orange;
            }
            else
            {
                // Ağaç Yapısına Dön
                LoadProductTreeWithHierarchy();
                showingHierarchy = true;
                Gecis_Btn.Text = "Tüm Ürünleri Gör";
                Gecis_Btn.BackColor = Color.LightSteelBlue;
            }
        }
        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Excel'e aktarılıyor, lütfen bekleyin...";

            try
            {
                ExcelService excelService = new ExcelService();
                excelService.ExportTreeViewToExcel(treeView1);
                lblStatus.Text = "Excel aktarımı tamamlandı.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel'e aktarılırken hata oluştu: " + ex.Message);
                lblStatus.Text = "Hata oluştu.";
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panelTop.Width == 220)
            {
                panelTop.Width = 60;
                label1.Visible = false;
            }
            else
            {
                panelTop.Width = 220;
                label1.Visible = true;
            }
        }
    }
}
