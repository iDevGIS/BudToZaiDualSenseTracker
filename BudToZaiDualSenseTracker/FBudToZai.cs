using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.Windows.Shell;


namespace BudToZaiDualSenseTracker
{
    public partial class FBudToZai : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Constants for hotkey
        private const int HOTKEY_ID = 1;
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_ALT = 0x0001;
        private const int VK_B = 0x42;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public FBudToZai()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            if (Properties.Settings.Default.FormLocation != Point.Empty)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Properties.Settings.Default.FormLocation;
            }

            InitWebView();

            Label clickZone = new Label();
            clickZone.TextAlign = ContentAlignment.MiddleCenter;
            clickZone.Size = new Size(20, 20);
            clickZone.Location = new Point(130, 100);
            clickZone.BackColor = Color.FromArgb(50, Color.White);
            clickZone.ForeColor = Color.Black;
            clickZone.Cursor = Cursors.Hand;
            this.Controls.Add(clickZone);

            // Register hotkey (Control + Alt + B)
            RegisterHotKey(this.Handle, HOTKEY_ID, MOD_CONTROL | MOD_ALT, VK_B);

            InitializeJumpList();
        }

        private async void InitWebView()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Settings.IsWebMessageEnabled = true;

            string html = Properties.Resources.index;
            string tempPath = Path.Combine(Path.GetTempPath(), "index.html");
            File.WriteAllText(tempPath, html);
            webView21.Source = new Uri(tempPath);

            webView21.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
        }

        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string message = e.TryGetWebMessageAsString();
            if (message == "mousedown")
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
            else if (message == "mousemove" && dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
            else if (message == "mouseup")
            {
                dragging = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Properties.Settings.Default.FormLocation = this.Location;
            Properties.Settings.Default.Save();
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                this.ToggleVisibility();
            }
            base.WndProc(ref m);
        }

        private void ToggleVisibility()
        {
            if (this.Visible)
            {
                this.Hide();
                this.CItemMenu1.Checked = true;
            }
            else
            {
                this.Show();
                this.CItemMenu1.Checked = false;
            }
        }

        private void CMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.ToString() == "MenuToggleShowHide")
            {
                this.ToggleVisibility();
            }
            if (e.ClickedItem.Tag.ToString() == "MenuClose")
            {
                this.Close();
            }
        }

        private void InitializeJumpList()
        {
            JumpList jumpList = new JumpList();

            JumpTask showHideTask = new JumpTask
            {
                Title = "Show/Hide",
                Arguments = "/toggle",
                Description = "Show or hide the application",
                IconResourcePath = Application.ExecutablePath,
                ApplicationPath = Application.ExecutablePath
            };

            JumpTask exitTask = new JumpTask
            {
                Title = "Exit",
                Arguments = "/exit",
                Description = "Exit the application",
                IconResourcePath = Application.ExecutablePath,
                ApplicationPath = Application.ExecutablePath
            };

            //jumpList.JumpItems.Add(showHideTask);
            //jumpList.JumpItems.Add(exitTask);
            //jumpList.Apply();
        }
    }
}
