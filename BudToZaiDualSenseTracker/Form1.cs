using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;


namespace BudToZaiDualSenseTracker
{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Form1()
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
        }
    }
}
