using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÜretimTakipSistemi.SacAmbarı.ModernUI
{
    #region ModernUIHelper - Renk, Font ve Buton Sınıfı
    /// <summary>
    /// Modern UI bileşenleri için yardımcı sınıf
    /// Tüm renk paleti, buton stilleri ve animasyonlar burada
    /// </summary>
    public static class ModernUIHelper
    {
        #region Renk Paleti
        // Ana Tema Renkleri (Karanlık Tema)
        public static readonly Color PrimaryDark = Color.FromArgb(32, 36, 42);
        public static readonly Color PrimaryLight = Color.FromArgb(45, 51, 60);
        public static readonly Color AccentBlue = Color.FromArgb(0, 122, 204);
        public static readonly Color AccentCyan = Color.FromArgb(27, 221, 225);
        public static readonly Color SuccessGreen = Color.FromArgb(46, 204, 113);
        public static readonly Color WarningOrange = Color.FromArgb(255, 159, 64);
        public static readonly Color DangerRed = Color.FromArgb(231, 76, 60);
        public static readonly Color TextPrimary = Color.FromArgb(236, 240, 241);
        public static readonly Color TextSecondary = Color.FromArgb(149, 165, 166);
        public static readonly Color BorderColor = Color.FromArgb(52, 73, 94);
        public static readonly Color CardBackground = Color.FromArgb(52, 58, 67);
        #endregion

        #region Fontlar
        public static readonly Font HeaderFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font SubHeaderFont = new Font("Segoe UI Semibold", 13F);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F);
        public static readonly Font SmallFont = new Font("Segoe UI", 9F);
        public static readonly Font ButtonFont = new Font("Segoe UI Semibold", 11F);
        #endregion

        #region Buton Oluşturucular
        /// <summary>
        /// Ana işlem butonu (Primary - Mavi)
        /// </summary>
        public static Button CreatePrimaryButton(string text, int height = 45)
        {
            Button btn = new Button
            {
                Text = text,
                Height = height,
                FlatStyle = FlatStyle.Flat,
                BackColor = AccentBlue,
                ForeColor = Color.White,
                Font = ButtonFont,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = AccentCyan;

            return btn;
        }

        /// <summary>
        /// Tehlikeli işlem butonu (Danger - Kırmızı)
        /// </summary>
        public static Button CreateDangerButton(string text, int height = 45)
        {
            Button btn = CreatePrimaryButton(text, height);
            btn.BackColor = DangerRed;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            return btn;
        }

        /// <summary>
        /// Başarı butonu (Success - Yeşil)
        /// </summary>
        public static Button CreateSuccessButton(string text, int height = 45)
        {
            Button btn = CreatePrimaryButton(text, height);
            btn.BackColor = SuccessGreen;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
            return btn;
        }

        /// <summary>
        /// İkincil buton (Secondary - Gri)
        /// </summary>
        public static Button CreateSecondaryButton(string text, int height = 45)
        {
            Button btn = CreatePrimaryButton(text, height);
            btn.BackColor = BorderColor;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 90, 110);
            return btn;
        }

        /// <summary>
        /// Menü butonu (Sidebar için)
        /// </summary>
        public static Button CreateMenuButton(string text, string icon = "")
        {
            Button btn = new Button
            {
                Text = string.IsNullOrEmpty(icon) ? $"  {text}" : $"  {icon}  {text}",
                Height = 50,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                ForeColor = TextPrimary,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = BorderColor;

            // Sol tarafta vurgu çizgisi
            Panel indicator = new Panel
            {
                Width = 4,
                Dock = DockStyle.Left,
                BackColor = Color.Transparent
            };
            btn.Controls.Add(indicator);

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = BorderColor;
                indicator.BackColor = AccentBlue;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.Transparent;
                indicator.BackColor = Color.Transparent;
            };

            return btn;
        }
        #endregion

        #region Panel ve Kart Oluşturucular
        /// <summary>
        /// Modern kart paneli oluşturur
        /// </summary>
        public static Panel CreateCard(int height = 100, bool addShadow = true)
        {
            Panel card = new Panel
            {
                Height = height,
                BackColor = CardBackground,
                Margin = new Padding(5)
            };

            if (addShadow)
            {
                card.Paint += (s, e) =>
                {
                    using (Pen pen = new Pen(Color.FromArgb(70, 70, 70), 1))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                    }
                };
            }

            return card;
        }

        /// <summary>
        /// Bilgi kartı (ikon, label, değer)
        /// </summary>
        public static Panel CreateInfoCard(string label, string value, string icon = "📊")
        {
            Panel card = CreateCard(70);

            Label lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 18F),
                Width = 50,
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = AccentBlue
            };

            Panel textPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(5) };

            Label lblLabel = new Label
            {
                Text = label,
                Font = SmallFont,
                ForeColor = TextSecondary,
                Dock = DockStyle.Top,
                Height = 20,
                Padding = new Padding(0, 5, 0, 0)
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = TextPrimary,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            textPanel.Controls.Add(lblValue);
            textPanel.Controls.Add(lblLabel);

            card.Controls.Add(textPanel);
            card.Controls.Add(lblIcon);

            return card;
        }

        /// <summary>
        /// Menü ayırıcı label oluşturur
        /// </summary>
        public static Label CreateMenuSeparator(string title)
        {
            Label separator = new Label
            {
                Text = title,
                Height = 35,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = TextSecondary,
                Padding = new Padding(15, 10, 0, 0),
                BackColor = Color.Transparent,
                AutoSize = false
            };
            return separator;
        }
        #endregion

        #region Animasyonlar
        /// <summary>
        /// Panel genişliğini yumuşak bir şekilde değiştirir
        /// </summary>
        public static void AnimatePanelWidth(Panel panel, int targetWidth, int duration = 300)
        {
            int steps = 20;
            int stepDuration = duration / steps;
            int currentWidth = panel.Width;
            int widthDifference = targetWidth - currentWidth;
            int stepSize = widthDifference / steps;

            Timer timer = new Timer { Interval = stepDuration };
            int currentStep = 0;

            timer.Tick += (s, e) =>
            {
                currentStep++;
                if (currentStep >= steps)
                {
                    panel.Width = targetWidth;
                    timer.Stop();
                    timer.Dispose();
                }
                else
                {
                    panel.Width += stepSize;
                }
            };

            timer.Start();
        }
        #endregion

        #region TreeView Özelleştirme
        /// <summary>
        /// TreeView'i modern tema ile özelleştirir
        /// </summary>
        public static void ApplyModernTheme(TreeView treeView)
        {
            treeView.BorderStyle = BorderStyle.None;
            treeView.BackColor = PrimaryDark;
            treeView.ForeColor = TextPrimary;
            treeView.Font = new Font("Segoe UI", 11F);
            treeView.ItemHeight = 32;
            treeView.Indent = 25;
            treeView.FullRowSelect = true;
            treeView.ShowLines = true;
            treeView.LineColor = BorderColor;
            treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;

            treeView.DrawNode += TreeView_DrawNode;
        }

        private static void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                using (SolidBrush brush = new SolidBrush(AccentBlue))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.NodeFont ?? e.Node.TreeView.Font,
                    e.Bounds, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
            else if ((e.State & TreeNodeStates.Hot) != 0)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(40, 44, 52)))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.NodeFont ?? e.Node.TreeView.Font,
                    e.Bounds, TextPrimary, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
        #endregion
    }
    #endregion

    #region ModernNotification - Bildirim Sistemi
    /// <summary>
    /// Modern toast notification sistemi
    /// Kullanım: ModernNotification.Show(this, "İşlem başarılı!", NotificationType.Success);
    /// </summary>
    public static class ModernNotification
    {
        public enum NotificationType
        {
            Success,
            Warning,
            Error,
            Info
        }

        /// <summary>
        /// Modern bildirim gösterir
        /// </summary>
        public static void Show(Form parentForm, string message, NotificationType type, int duration = 3000)
        {
            if (parentForm == null) return;

            Panel notification = CreateNotificationPanel(message, type);

            // Sağ üst köşeye yerleştir
            notification.Location = new Point(
                parentForm.ClientSize.Width - notification.Width - 20,
                70
            );

            notification.BringToFront();
            parentForm.Controls.Add(notification);

            // Otomatik kapanma
            Timer closeTimer = new Timer { Interval = duration };
            closeTimer.Tick += (s, e) =>
            {
                AnimateOut(notification, parentForm);
                closeTimer.Stop();
                closeTimer.Dispose();
            };
            closeTimer.Start();

            // Giriş animasyonu
            AnimateIn(notification);
        }

        private static Panel CreateNotificationPanel(string message, NotificationType type)
        {
            Panel notification = new Panel
            {
                Width = 350,
                Height = 80,
                BackColor = GetNotificationColor(type)
            };

            Label icon = new Label
            {
                Text = GetNotificationIcon(type),
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                Width = 60,
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 10, 0)
            };

            Button btnClose = new Button
            {
                Text = "✕",
                Width = 40,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 0, 0);
            btnClose.Click += (s, e) =>
            {
                if (notification.Parent != null)
                {
                    notification.Parent.Controls.Remove(notification);
                    notification.Dispose();
                }
            };

            notification.Controls.Add(lblMessage);
            notification.Controls.Add(icon);
            notification.Controls.Add(btnClose);

            notification.Paint += (s, e) =>
            {
                using (Pen shadowPen = new Pen(Color.FromArgb(100, 0, 0, 0), 2))
                {
                    e.Graphics.DrawRectangle(shadowPen, 0, 0, notification.Width - 1, notification.Height - 1);
                }
            };

            return notification;
        }

        private static Color GetNotificationColor(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Success: return Color.FromArgb(46, 204, 113);
                case NotificationType.Warning: return Color.FromArgb(255, 159, 64);
                case NotificationType.Error: return Color.FromArgb(231, 76, 60);
                case NotificationType.Info:
                default: return Color.FromArgb(0, 122, 204);
            }
        }

        private static string GetNotificationIcon(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Success: return "✓";
                case NotificationType.Warning: return "⚠";
                case NotificationType.Error: return "✕";
                case NotificationType.Info:
                default: return "ℹ";
            }
        }

        private static void AnimateIn(Panel notification)
        {
            int targetX = notification.Left;
            notification.Left = notification.Parent.Width;

            Timer timer = new Timer { Interval = 10 };
            timer.Tick += (s, e) =>
            {
                if (notification.Left > targetX)
                {
                    notification.Left -= 15;
                }
                else
                {
                    notification.Left = targetX;
                    timer.Stop();
                    timer.Dispose();
                }
            };
            timer.Start();
        }

        private static void AnimateOut(Panel notification, Form parentForm)
        {
            Timer timer = new Timer { Interval = 10 };
            timer.Tick += (s, e) =>
            {
                if (notification.Left < parentForm.Width)
                {
                    notification.Left += 15;
                }
                else
                {
                    parentForm.Controls.Remove(notification);
                    notification.Dispose();
                    timer.Stop();
                    timer.Dispose();
                }
            };
            timer.Start();
        }
    }
    #endregion

    #region ModernConfirmDialog - Onay Dialog
    /// <summary>
    /// Modern onay dialog kutusu (MessageBox yerine)
    /// </summary>
    public class ModernConfirmDialog : Form
    {
        public DialogResult Result { get; private set; }

        public ModernConfirmDialog(string title, string message, string confirmText = "Evet", string cancelText = "Hayır")
        {
            InitializeDialog(title, message, confirmText, cancelText);
        }

        private void InitializeDialog(string title, string message, string confirmText, string cancelText)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = ModernUIHelper.CardBackground;

            Panel titlePanel = new Panel
            {
                Height = 50,
                Dock = DockStyle.Top,
                BackColor = ModernUIHelper.AccentBlue
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = ModernUIHelper.SubHeaderFont,
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            titlePanel.Controls.Add(lblTitle);

            Label lblMessage = new Label
            {
                Text = message,
                Font = ModernUIHelper.BodyFont,
                ForeColor = ModernUIHelper.TextPrimary,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(20)
            };

            Panel buttonPanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Bottom,
                BackColor = ModernUIHelper.PrimaryLight,
                Padding = new Padding(10)
            };

            Button btnConfirm = ModernUIHelper.CreatePrimaryButton(confirmText);
            btnConfirm.Width = 120;
            btnConfirm.Dock = DockStyle.Right;
            btnConfirm.Click += (s, e) =>
            {
                this.Result = DialogResult.Yes;
                this.Close();
            };

            Button btnCancel = ModernUIHelper.CreateSecondaryButton(cancelText);
            btnCancel.Width = 120;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Margin = new Padding(0, 0, 10, 0);
            btnCancel.Click += (s, e) =>
            {
                this.Result = DialogResult.No;
                this.Close();
            };

            buttonPanel.Controls.Add(btnConfirm);
            buttonPanel.Controls.Add(btnCancel);

            this.Controls.Add(lblMessage);
            this.Controls.Add(titlePanel);
            this.Controls.Add(buttonPanel);

            this.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(100, 0, 0, 0), 3))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            };
        }

        public static DialogResult Show(string title, string message, string confirmText = "Evet", string cancelText = "Hayır")
        {
            using (ModernConfirmDialog dialog = new ModernConfirmDialog(title, message, confirmText, cancelText))
            {
                dialog.ShowDialog();
                return dialog.Result;
            }
        }
    }
    #endregion
}