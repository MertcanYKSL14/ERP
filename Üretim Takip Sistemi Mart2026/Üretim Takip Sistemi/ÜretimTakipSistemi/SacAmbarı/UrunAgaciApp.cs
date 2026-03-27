using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Excel = Microsoft.Office.Interop.Excel;


namespace ÜretimTakipSistemi.SacAmbarı


{
    public partial class UrunAgaciApp : Form
    {
        private string connectionString = @"Data Source=192.168.1.144,1433;Initial Catalog=UrunAgaciDB;User ID=ADMIN;Password=1;MultipleActiveResultSets=True;";
       
        public UrunAgaciApp()
        {
            InitializeComponent();

            this.treeView1.Dock = DockStyle.Fill;

            //Treeview1 Metinsel İfade Boyutlandırmaları
            // 1. SplitContainer oluştur (Ağaç ve Detay Paneli arasına)
            SplitContainer splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.SplitterDistance = 400; // Sol taraftaki ağaç başlangıçta 400 piksel olsun
            splitContainer.SplitterWidth = 5;      // Ayırıcı çizginin kalınlığı

            // 3. Detay Paneli ayarları
            txtUrunDetay.Dock = DockStyle.Fill;
            txtUrunDetay.Multiline = true;

            // 4. Kontrolleri yeni panellere taşı
            this.Controls.Remove(treeView1);
            this.Controls.Remove(txtUrunDetay);
            splitContainer.Panel1.Controls.Add(treeView1);     // Sol panelde ağaç
            splitContainer.Panel2.Controls.Add(txtUrunDetay);  // Sağ panelde detaylar
            this.Controls.Add(splitContainer);
            splitContainer.BringToFront();
            LoadProductTreeWithHierarchy(); // Form yüklendiğinde ağacı yükle
        }
        protected override void OnLoad(EventArgs e) //Uygulama açıldığında ağaç otomatik olarak içeriğe göre genişlemeye çalışır
        {
            base.OnLoad(e);
            // Form açıldığında splitter'ı makul bir yere çek
            splitContainer1.SplitterDistance = 400;
        }

        private void AdjustTreeViewWidth() //en uzun metne göre genişliği otomatik ayarlamak istendiğinde
        {
            int maxWidth = 0;
            foreach (TreeNode node in treeView1.Nodes)
            {
                // En geniş düğümü bul (Genişletilmiş dallar dahil)
                int nodeWidth = GetNodeMaxRight(node);
                if (nodeWidth > maxWidth) maxWidth = nodeWidth;
            }

        }

        //Ağaç yapısı yatayda kapladığı en fazla yere göre şekil alır
        private int GetNodeMaxRight(TreeNode node)
        {
            int right = node.Bounds.Right;
            if (node.IsExpanded)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    int childRight = GetNodeMaxRight(child);
                    if (childRight > right) right = childRight;
                }
            }
            return right;
        }

        // AĞAÇ YAPISINI OLUŞTURAN ANA METOD
        private void LoadProductTreeWithHierarchy()
        {
            treeView1.Nodes.Clear();
            lblStatus.Text = "Ürün ağacı yükleniyor...";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. ÖNCE VERİTABANI VE TABLOLARI KONTROL ET
                    CheckAndCreateDatabase(conn);

                    // 2. ROOT ÜRÜNLERİ BUL (ana ürün olan ama alt ürün olmayanlar)
                    string rootQuery = @"
                        SELECT u.UrunID, u.UrunKodu, u.UrunAdi 
                        FROM Urunler u
                        WHERE u.UrunID IN (SELECT DISTINCT AnaUrunID FROM UrunAgaci)
                        AND u.UrunID NOT IN (SELECT DISTINCT AltUrunID FROM UrunAgaci)
                        ORDER BY u.UrunAdi";

                    using (SqlCommand rootCmd = new SqlCommand(rootQuery, conn))
                    using (SqlDataReader rootReader = rootCmd.ExecuteReader())
                    {
                        int rootCount = 0;
                        while (rootReader.Read())
                        {
                            rootCount++;
                            int urunID = Convert.ToInt32(rootReader["UrunID"]);
                            string urunAdi = rootReader["UrunAdi"].ToString();
                            string urunKodu = rootReader["UrunKodu"].ToString();

                            // Ana ürün node'u oluştur
                            TreeNode anaNode = new TreeNode($"{urunAdi} ({urunKodu})");
                            anaNode.Tag = urunID;
                            anaNode.ForeColor = Color.DarkBlue;
                            anaNode.NodeFont = new Font(treeView1.Font, FontStyle.Bold);

                            // Alt ürünleri recursive olarak ekle
                            AddChildNodes(anaNode, urunID, conn, 1);

                            treeView1.Nodes.Add(anaNode);
                        }

                        lblStatus.Text = $"{rootCount} ana ürün yüklendi.";

                        // Eğer hiç ürün yoksa uyarı ver
                        if (rootCount == 0)
                        {
                            TreeNode infoNode = new TreeNode("⚠️ Hiç ürün bulunamadı. 'Test Verisi Ekle' butonuna tıklayın.");
                            treeView1.Nodes.Add(infoNode);
                        }
                        else
                        {
                            // İlk node'u otomatik genişlet
                            if (treeView1.Nodes.Count > 0)
                            {
                                treeView1.Nodes[0].Expand();
                            }
                        }
                    } // DataReader otomatik kapanır (using bloğu sayesinde)
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

        // ALT ÜRÜNLERİ RECURSIVE OLARAK EKLEYEN METOD 
        private void AddChildNodes(TreeNode parentNode, int parentUrunID, SqlConnection conn, int level)
        {
            string childQuery = @"
                SELECT 
                    u.UrunID, 
                    u.UrunAdi, 
                    u.UrunKodu, 
                    u.Birim,
                    ua.Miktar,
                    ua.SiraNo
                FROM UrunAgaci ua
                INNER JOIN Urunler u ON ua.AltUrunID = u.UrunID
                WHERE ua.AnaUrunID = @ParentID
                ORDER BY ISNULL(ua.SiraNo, 999), u.UrunAdi";

            using (SqlCommand childCmd = new SqlCommand(childQuery, conn))
            {
                childCmd.Parameters.AddWithValue("@ParentID", parentUrunID);

                using (SqlDataReader childReader = childCmd.ExecuteReader())
                {
                    while (childReader.Read())
                    {
                        int childUrunID = Convert.ToInt32(childReader["UrunID"]);
                        string childUrunAdi = childReader["UrunAdi"].ToString();
                        string childUrunKodu = childReader["UrunKodu"].ToString();
                        decimal miktar = Convert.ToDecimal(childReader["Miktar"]);
                        string birim = childReader["Birim"].ToString();

                        // Alt ürün node'u oluştur
                        string nodeText = $"{childUrunAdi} ({childUrunKodu}) - {miktar} {birim}";

                        TreeNode childNode = new TreeNode(nodeText);
                        childNode.Tag = childUrunID;
                        childNode.ForeColor = Color.DarkGreen;

                        // RECURSIVE: Bu alt ürünün de alt ürünleri varsa ekle
                        AddChildNodes(childNode, childUrunID, conn, level + 1);

                        parentNode.Nodes.Add(childNode);
                    }
                } // DataReader otomatik kapanır
            }
        }

        // VERİTABANI VE TABLO KONTROLÜ
        private void CheckAndCreateDatabase(SqlConnection conn)
        {
            try
            {
                // ÖNCE TABLOLARIN VAR OLUP OLMADIĞINI KONTROL ET
                string checkTablesQuery = @"
                    SELECT 
                        CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Urunler') THEN 1 ELSE 0 END as UrunlerVar,
                        CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UrunAgaci') THEN 1 ELSE 0 END as AgacVar";

                bool urunlerVar = false;
                bool agacVar = false;

                using (SqlCommand cmd = new SqlCommand(checkTablesQuery, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        urunlerVar = Convert.ToInt32(reader["UrunlerVar"]) == 1;
                        agacVar = Convert.ToInt32(reader["AgacVar"]) == 1;
                    }
                }

                // EĞER TABLOLAR YOKSA OLUŞTUR
                if (!urunlerVar)
                {
                    string createUrunler = @"
                        CREATE TABLE Urunler (
                            UrunID INT IDENTITY(1,1) PRIMARY KEY,
                            UrunKodu NVARCHAR(50) NOT NULL,
                            UrunAdi NVARCHAR(100) NOT NULL,
                            Birim NVARCHAR(20) DEFAULT 'Adet',
                            BirimFiyat DECIMAL(18,2) DEFAULT 0,
                            Aciklama NVARCHAR(500),
                            KayitTarihi DATETIME DEFAULT GETDATE()
                        )";

                    using (SqlCommand cmd = new SqlCommand(createUrunler, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                if (!agacVar)
                {
                    string createUrunAgaci = @"
                        CREATE TABLE UrunAgaci (
                            AgacID INT IDENTITY(1,1) PRIMARY KEY,
                            AnaUrunID INT NOT NULL,
                            AltUrunID INT NOT NULL,
                            Miktar DECIMAL(10,3) DEFAULT 1,
                            SiraNo INT DEFAULT 0,
                            Aciklama NVARCHAR(200),
                            FOREIGN KEY (AnaUrunID) REFERENCES Urunler(UrunID),
                            FOREIGN KEY (AltUrunID) REFERENCES Urunler(UrunID)
                        )";

                    using (SqlCommand cmd = new SqlCommand(createUrunAgaci, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // TABLO SAYILARINI KONTROL ET
                string countQuery = @"
                    SELECT 
                        (SELECT COUNT(*) FROM Urunler) as UrunSayisi,
                        (SELECT COUNT(*) FROM UrunAgaci) as AgacSayisi";

                int urunSayisi = 0;
                int agacSayisi = 0;

                using (SqlCommand cmd = new SqlCommand(countQuery, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        urunSayisi = reader.GetInt32(0);
                        agacSayisi = reader.GetInt32(1);
                    }
                } // Reader otomatik kapanır

                if (urunSayisi == 0)
                {

                    AddSampleTestData(conn); // İlk açılışta test verisi ekle
                }
                else
                {
                    lblStatus.Text = $"Veritabanında {urunSayisi} ürün ve {agacSayisi} ağaç kaydı var.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı hazırlama hatası: {ex.Message}", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddSampleTestData(SqlConnection conn)  // ÖRNEK TEST VERİSİ EKLE
        {
            try
            {


                // Örnek ürünler ekle
                string insertUrunler = @"
                    INSERT INTO Urunler (UrunKodu, UrunAdi, Birim, BirimFiyat, Aciklama) VALUES
                    ('BSK-001', 'Bisiklet', 'Adet', 1500.00, 'Dağ Bisikleti'),
                    ('GDN-001', 'Gidon', 'Adet', 75.00, 'Alüminyum Gidon'),
                    ('PDL-001', 'Pedal', 'Adet', 25.00, 'Plastik Pedal'),
                    ('TKR-001', 'Tekerlek', 'Adet', 200.00, '26 inç Tekerlek'),
                    ('JNT-001', 'Jant', 'Adet', 120.00, 'Alüminyum Jant'),
                    ('LST-001', 'Lastik', 'Adet', 80.00, '26x1.95 Lastik'),
                    ('VID-001', 'Vida Seti', 'Adet', 15.00, 'Montaj Vidası'),
                    ('FRM-001', 'Bisiklet Frame', 'Adet', 300.00, 'Ana Gövde');";

                using (SqlCommand cmd = new SqlCommand(insertUrunler, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Ürün ağacı ilişkilerini ekle (HIYERARŞİK YAPI)
                string insertAgac = @"
                    INSERT INTO UrunAgaci (AnaUrunID, AltUrunID, Miktar, SiraNo, Aciklama) VALUES
                    -- BİSİKLET parçaları
                    (1, 8, 1, 10, 'Ana gövde'),
                    (1, 2, 1, 20, 'Direksiyon'),
                    (1, 3, 2, 30, 'Ayak desteği'),
                    (1, 4, 2, 40, 'Dönme elemanı'),
                    
                    -- TEKERLEK parçaları
                    (4, 5, 1, 10, 'Tekerlek çerçevesi'),
                    (4, 6, 1, 20, 'Dış kaplama'),
                    (4, 7, 10, 30, 'Sabitleme elemanı');";

                using (SqlCommand cmd = new SqlCommand(insertAgac, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Test verileri başarıyla eklendi!\n\n" +
                              "• Bisiklet\n" +
                              "  ├── Bisiklet Frame\n" +
                              "  ├── Gidon\n" +
                              "  ├── Pedal (2 adet)\n" +
                              "  └── Tekerlek (2 adet)\n" +
                              "        ├── Jant\n" +
                              "        ├── Lastik\n" +
                              "        └── Vida Seti (10 adet)",
                              "Test Verisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Test verisi ekleme hatası: {ex.Message}", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // BUTON EVENT'LERİ - ÇALIŞIR HALDE
        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadProductTreeWithHierarchy();
        }
        private void btnTestVerisiEkle_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    AddSampleTestData(conn);
                    LoadProductTreeWithHierarchy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isExpanded = false; // Ağacın açık mı kapalı mı olduğunu tutan değişken,daralt-genişlet btn
        private void btnToggleTree_Click(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                // Şu an açık, o halde kapat (daralt)
                treeView1.CollapseAll();
                btnTumunuAc.Text = "Tümünü Genişlet ▼";
                btnTumunuAc.BackColor = Color.DimGray;
                isExpanded = false;
                lblStatus.Text = "Tüm dallar daraltıldı.";
            }
            else
            {
                // Şu an kapalı, o halde aç (genişlet)
                treeView1.ExpandAll();
                btnTumunuAc.Text = "Tümünü Daralt ▲";
                btnTumunuAc.BackColor = Color.DarkSlateGray; // Görsel geri bildirim için rengi değiştirebilirsiniz
                isExpanded = true;
                lblStatus.Text = "Tüm dallar genişletildi.";
            }
        }
        private void btnTumunuAc_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            lblStatus.Text = "Tüm dallar genişletildi.";
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            using (var form = new SimpleUrunEkleForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            SqlTransaction tran = conn.BeginTransaction();

                            try
                            {
                                // 1. ANA ÜRÜN VAR MI KONTROL ET VEYA EKLE
                                int anaID = GetOrCreateUrun(form.UrunKodu, form.UrunAdi, conn, tran);

                                // 2. ALT ÜRÜN EKLENECEKSE
                                if (form.AltUrunEklenecek && !string.IsNullOrWhiteSpace(form.AltUrunKodu))
                                {
                                    int altID = GetOrCreateUrun(form.AltUrunKodu, form.AltUrunAdi, conn, tran);
                                    // Miktar bilgisini kullanarak bağı kuruyoruz
                                    string queryAgac = "INSERT INTO UrunAgaci (AnaUrunID, AltUrunID, Miktar) VALUES (@Ana, @Alt, @Miktar)";
                                    using (SqlCommand cmd = new SqlCommand(queryAgac, conn, tran))
                                    {
                                        cmd.Parameters.AddWithValue("@Ana", anaID);
                                        cmd.Parameters.AddWithValue("@Alt", altID);
                                        cmd.Parameters.AddWithValue("@Miktar", form.Miktar); // Formdan gelen adet
                                        cmd.ExecuteNonQuery();
                                    }
                                    // 3. ARADAKİ BAĞI KUR (Zaten varsa ekleme)
                                    string checkAgac = "SELECT COUNT(*) FROM UrunAgaci WHERE AnaUrunID = @Ana AND AltUrunID = @Alt";
                                    using (SqlCommand cmd = new SqlCommand(checkAgac, conn, tran))
                                    {
                                        cmd.Parameters.AddWithValue("@Ana", anaID);
                                        cmd.Parameters.AddWithValue("@Alt", altID);
                                        if ((int)cmd.ExecuteScalar() == 0)
                                        {
                                            string insAgac = "INSERT INTO UrunAgaci (AnaUrunID, AltUrunID, Miktar) VALUES (@Ana, @Alt, 1)";
                                            using (SqlCommand cmdIns = new SqlCommand(insAgac, conn, tran))
                                            {
                                                cmdIns.Parameters.AddWithValue("@Ana", anaID);
                                                cmdIns.Parameters.AddWithValue("@Alt", altID);
                                                cmdIns.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }

                                tran.Commit();
                                MessageBox.Show("İşlem başarıyla tamamlandı.");
                                LoadProductTreeWithHierarchy();
                            }
                            catch { tran.Rollback(); throw; }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
                }
            }
        }

        // Yardımcı Metot: Ürün varsa ID döner, yoksa oluşturur
        private int GetOrCreateUrun(string kod, string ad, SqlConnection conn, SqlTransaction tran)
        {
            string query = "SELECT UrunID FROM Urunler WHERE UrunKodu = @Kod";
            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@Kod", kod);
                object result = cmd.ExecuteScalar();

                if (result != null) return (int)result;

                string insert = "INSERT INTO Urunler (UrunKodu, UrunAdi, Birim) OUTPUT INSERTED.UrunID VALUES (@Kod, @Ad, 'Adet')";
                using (SqlCommand cmdIns = new SqlCommand(insert, conn, tran))
                {
                    cmdIns.Parameters.AddWithValue("@Kod", kod);
                    cmdIns.Parameters.AddWithValue("@Ad", ad);
                    return (int)cmdIns.ExecuteScalar();
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) // TreeView'de ürün seçildiğinde
        {

            TreeNode secilenUrun = e.Node; // Seçilen düğümü (node) alıyoruz

            // Bilgileri alt alta hazırlıyoruz 
            string detay = "ÜRÜN BİLGİ KARTI" + Environment.NewLine; // Environment.NewLine bir alt satıra geçmeyi sağlar
            detay += "----------------------------" + Environment.NewLine;
            detay += "Ürün Adı    : " + secilenUrun.Text + Environment.NewLine;
            detay += "Ürün Seviyesi: " + (secilenUrun.Level + 1).ToString() + Environment.NewLine;
            detay += "Bağlı Olduğu: " + (secilenUrun.Parent != null ? secilenUrun.Parent.Text : "Ana Ürün") + Environment.NewLine;
            detay += "Alt Parça Sayısı: " + secilenUrun.Nodes.Count.ToString() + Environment.NewLine;
            detay += "----------------------------" + Environment.NewLine;
            detay += "Tarih: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            txtUrunDetay.Text = detay; // Hazırladığımız metni TextBox'a aktarıyoruz 
        }

        private void ShowProductDetails(int urunID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            u.UrunKodu,
                            u.UrunAdi,
                            u.Birim,
                            u.BirimFiyat,
                            u.Aciklama,
                            (SELECT COUNT(*) FROM UrunAgaci WHERE AnaUrunID = u.UrunID) as AltUrunSayisi,
                            (SELECT COUNT(*) FROM UrunAgaci WHERE AltUrunID = u.UrunID) as UstUrunSayisi
                        FROM Urunler u
                        WHERE u.UrunID = @UrunID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UrunID", urunID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUrunDetay.Text =
                                    $"KOD: {reader["UrunKodu"]}\n\n" +
                                    $"AD: {reader["UrunAdi"]}\n\n" +
                                    $"BİRİM: {reader["Birim"]}\n\n" +
                                    $"FİYAT: {reader["BirimFiyat"]:N2} TL\n\n" +
                                    $"ALT ÜRÜN SAYISI: {reader["AltUrunSayisi"]}\n\n" +
                                    $"ÜST ÜRÜN SAYISI: {reader["UstUrunSayisi"]}\n\n" +
                                    $"AÇIKLAMA:\n{reader["Aciklama"]}";
                            }
                        } // Reader otomatik kapanır
                    }
                }
            }
            catch (Exception ex)
            {
                txtUrunDetay.Text = $"Hata: {ex.Message}";
            }
        }

        private void Bul_Btn_Click(object sender, EventArgs e)
        {
            string arananKod = Interaction.InputBox("Aranacak Ürün Kodunu Giriniz:", "Ürün Bul", "");
            if (string.IsNullOrWhiteSpace(arananKod)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT UrunID, UrunAdi FROM Urunler WHERE UrunKodu = @Kod";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Kod", arananKod);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int urunID = Convert.ToInt32(reader["UrunID"]);
                                string urunAdi = reader["UrunAdi"].ToString();

                                // 1. Detayları sağdaki text kutusuna yazdır (Var olan metodunu kullanıyoruz)
                                ShowProductDetails(urunID);

                                // 2. TreeView içerisinde bu ürünü bul ve seç
                                FocusNodeByTag(treeView1.Nodes, urunID);

                                lblStatus.Text = $"Ürün bulundu: {urunAdi}";
                            }
                            else
                            {
                                MessageBox.Show("Bu koda ait bir ürün bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FocusNodeByTag(TreeNodeCollection nodes, int targetID)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null && (int)node.Tag == targetID)
                {
                    treeView1.SelectedNode = node; // Düğümü seç
                    node.EnsureVisible();          // Düğümün görünür olmasını sağla (üst dalları açar)
                    treeView1.Focus();             // TreeView'a odaklan
                    return true;
                }

                // Alt düğümlerde ara (Recursive)
                if (FocusNodeByTag(node.Nodes, targetID))
                    return true;
            }
            return false;
        }

        private void UrunSil_Btn_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.");
                return;
            }

            // Seçili düğümün ID'sini alıyoruz
            int seciliID = (int)treeView1.SelectedNode.Tag;
            string urunAdi = treeView1.SelectedNode.Text;

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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1. ADIM: Bu ürünün başkalarının altında "Alt Ürün" olarak kullanıldığı bağları kopar
                    string sqlAgac = "DELETE FROM UrunAgaci WHERE AnaUrunID = @id OR AltUrunID = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlAgac, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", urunID);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. ADIM: Artık hiçbir yerde bağı kalmadığına göre ana tablodan (Urunler) silebiliriz
                    string sqlUrun = "DELETE FROM Urunler WHERE UrunID = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlUrun, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", urunID);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    lblStatus.Text = "Ürün sistemden tamamen kaldırıldı.";

                    // Ekranı tazele
                    btnYenile.PerformClick();
                    txtUrunDetay.Clear();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Silme başarısız: " + ex.Message);
                }
            }
        }

        private void UrunuVeritabanindanSil(int urunID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1. Önce UrunAgaci tablosundaki bağlantıları silelim
                    // Sizin tablonuzda kolon isimleri: AnaUrunID ve AltUrunID
                    string deleteAgac = "DELETE FROM UrunAgaci WHERE AnaUrunID = @id OR AltUrunID = @id";
                    using (SqlCommand cmd = new SqlCommand(deleteAgac, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", urunID);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Sonra Urunler tablosundan asıl ürünü silelim
                    string deleteUrun = "DELETE FROM Urunler WHERE UrunID = @id";
                    using (SqlCommand cmd = new SqlCommand(deleteUrun, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", urunID);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    lblStatus.Text = "Ürün ve bağlı olduğu ağaç kayıtları silindi.";

                    // Yenileme butonuna basarak TreeView'ı güncelle
                    btnYenile.PerformClick();
                    txtUrunDetay.Clear();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Silme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadProductTree()
        {

            try
            {
                treeView1.Nodes.Clear(); // Önce mevcut ağacı temizle

                // Bu metodun amacı veritabanındaki hiyerarşiyi çekip TreeView'ı doldurmaktır.
                // Daha önce yazdığınız listeleme/yenileme metodunu buraya bağlayın.

                // Örnek olarak varsa şu metodunuzu çağırabilirsiniz:
                LoadProductTreeWithHierarchy();

                lblStatus.Text = "Ağaç güncellendi: " + DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ağaç yüklenirken hata: " + ex.Message);
            }
        }

        private void btnMaliyetAc_Click(object sender, EventArgs e)
        {
            MaliyetHesaplaForm yeni = new MaliyetHesaplaForm();
            yeni.Show();
        }

        private bool showingHierarchy = true; // Başlangıçta ağaç yapısı gösteriliyor
        private void LoadAllProductsFlatList()
        {
            treeView1.Nodes.Clear();
            lblStatus.Text = "Tüm ürünler listeleniyor...";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT UrunID, UrunKodu, UrunAdi FROM Urunler ORDER BY UrunAdi";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            count++;
                            int urunID = Convert.ToInt32(reader["UrunID"]);
                            string urunAdi = reader["UrunAdi"].ToString();
                            string urunKodu = reader["UrunKodu"].ToString();

                            TreeNode node = new TreeNode($"{urunAdi} ({urunKodu})");
                            node.Tag = urunID;
                            node.ForeColor = Color.DarkSlateBlue;
                            treeView1.Nodes.Add(node);
                        }
                        lblStatus.Text = $"{count} ürün listelendi.";
                    }
                }
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
                // Şu an ağaç yapısı var, düz listeye geç
                LoadAllProductsFlatList();
                Gecis_Btn.Text = "Ürün Ağacına Dön";
                Gecis_Btn.BackColor = Color.Orange; // Görsel fark için renk değişimi
                showingHierarchy = false;
            }
            else
            {
                // Şu an düz liste var, hiyerarşik yapıya dön
                LoadProductTreeWithHierarchy();
                Gecis_Btn.Text = "Tüm Ürünleri Gör";
                Gecis_Btn.BackColor = Color.LightSteelBlue;
                showingHierarchy = true;
            }
        }

        //Excele Aktarma
        private void ExportTreeViewToExcel(TreeView tv)
        {
            if (tv.Nodes.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel yüklü değil!");
                return;
            }

            excelApp.Visible = true;
            Excel.Workbook workbook = excelApp.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Başlık
            worksheet.Cells[1, 1] = "Ürün Listesi / Ağaç Yapısı";
            worksheet.Range["A1"].Font.Bold = true;
            worksheet.Range["A1"].Font.Size = 14;


            int rowIndex = 2; // Verilerin başlayacağı satır

            // Tüm ana düğümleri dön
            foreach (TreeNode node in tv.Nodes)
            {
                WriteNodeToExcel(node, worksheet, ref rowIndex);
            }

            // Sütun genişliğini otomatik ayarla
            worksheet.Columns.AutoFit();
        }

        // Rekürsif (Özyinelemeli) yardımcı metot
        private void WriteNodeToExcel(TreeNode node, Excel.Worksheet sheet, ref int rowIndex)
        {
            // Düğümün seviyesine göre girinti yap (Ağaç yapısını korumak için)
            string indent = new string(' ', node.Level * 4);
            sheet.Cells[rowIndex, 1] = indent + node.Text;

            // Eğer sadece isim değil, detayları da isterseniz sütunlara bölebilirsiniz:
            sheet.Cells[rowIndex,2] = node.Tag; // Örn: ID bilgisini B sütununa yazar

            rowIndex++;

            // Alt düğümler varsa onları da yaz
            foreach (TreeNode childNode in node.Nodes)
            {
                WriteNodeToExcel(childNode, sheet, ref rowIndex);
            }
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Excel'e aktarılıyor, lütfen bekleyin...";
            ExportTreeViewToExcel(treeView1);
            lblStatus.Text = "Excel'e aktarma tamamlandı.";
        }
    }

    // BASİT ÜRÜN EKLEME FORMU
    public class SimpleUrunEkleForm : Form
    {
        public string UrunKodu => txtKod.Text;
        public string UrunAdi => txtAd.Text;
        public string AltUrunKodu => txtAltKod.Text;
        public string AltUrunAdi => txtAltAd.Text;
        public decimal Miktar => numMiktar.Value; // Miktar bilgisini dışarı açıyoruz
        public bool AltUrunEklenecek { get; private set; }

        private TextBox txtKod, txtAd, txtAltKod, txtAltAd;
        private NumericUpDown numMiktar; // Sayısal giriş için en güvenlisi
        private Button btnKaydet, btnIptal, btnAltUrunAc;
        private GroupBox grpAltUrun;

        public SimpleUrunEkleForm() { InitializeForm(); }

        private void InitializeForm()
        {
            this.Text = "Ürün Kayıt Paneli";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // --- ANA ÜRÜN ---
            Label lblKod = new Label { Text = "Ürün Kodu:", Location = new Point(20, 20), Size = new Size(80, 25) };
            txtKod = new TextBox { Location = new Point(110, 20), Size = new Size(240, 25) };
            Label lblAd = new Label { Text = "Ürün Adı:", Location = new Point(20, 55), Size = new Size(80, 25) };
            txtAd = new TextBox { Location = new Point(110, 55), Size = new Size(240, 25) };

            btnAltUrunAc = new Button { Text = "Alt Ürün Ekle (+)", Location = new Point(110, 95), Size = new Size(150, 30) };
            btnAltUrunAc.Click += BtnAltUrunAc_Click;

            // --- ALT ÜRÜN GRUBU ---
            grpAltUrun = new GroupBox { Text = "Eklenecek Alt Ürün ve Miktar", Location = new Point(20, 135), Size = new Size(340, 140), Visible = false };

            Label l1 = new Label { Text = "Kodu:", Location = new Point(15, 30), Size = new Size(40, 20) };
            txtAltKod = new TextBox { Location = new Point(60, 30), Size = new Size(250, 20) };

            Label l2 = new Label { Text = "Adı:", Location = new Point(15, 65), Size = new Size(40, 20) };
            txtAltAd = new TextBox { Location = new Point(60, 65), Size = new Size(250, 20) };

            Label l3 = new Label { Text = "Adet:", Location = new Point(15, 100), Size = new Size(40, 20) };
            numMiktar = new NumericUpDown { Location = new Point(60, 100), Size = new Size(80, 20), Minimum = 1, Maximum = 10000, Value = 1 };

            grpAltUrun.Controls.AddRange(new Control[] { l1, txtAltKod, l2, txtAltAd, l3, numMiktar });

            // --- BUTONLAR ---
            btnKaydet = new Button { Text = "Kaydet", Location = new Point(150, 160), Size = new Size(100, 35), BackColor = Color.LightBlue, DialogResult = DialogResult.OK };
            btnKaydet.Click += (s, e) => this.Close();
            btnIptal = new Button { Text = "İptal", Location = new Point(260, 160), Size = new Size(100, 35) };
            btnIptal.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] { lblKod, txtKod, lblAd, txtAd, btnAltUrunAc, grpAltUrun, btnKaydet, btnIptal });
        }

        private void BtnAltUrunAc_Click(object sender, EventArgs e)
        {
            AltUrunEklenecek = true;
            grpAltUrun.Visible = true;
            this.Height = 440; // Miktar geldiği için biraz daha uzattık
            btnKaydet.Location = new Point(150, 340);
            btnIptal.Location = new Point(260, 340);
            btnAltUrunAc.Enabled = false;
        }
    }
}