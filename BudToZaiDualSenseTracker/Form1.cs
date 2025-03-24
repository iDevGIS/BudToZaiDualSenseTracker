using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

            // ตั้งค่า FormBorderStyle เป็น None
            this.FormBorderStyle = FormBorderStyle.None;

            // ตั้งค่า BackColor เป็นสีที่คุณต้องการให้ใส
            //this.BackColor = Color.LimeGreen;
            //this.BackColor = Color.Black;

            // ตั้งค่า TransparencyKey ให้ตรงกับสีของ BackColor
            //this.TransparencyKey = Color.LimeGreen;
            //this.TransparencyKey = Color.Black;

            //this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            //this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            //this.MouseUp += new MouseEventHandler(Form1_MouseUp);


            InitWebView();




            //PictureBox clickableArea = new PictureBox();
            //clickableArea.BackColor = Color.FromArgb(1, 255, 255, 255); // Alpha 1 (เกือบใส แต่ยังรับ mouse ได้)
            //clickableArea.Size = new Size(344, 197);
            //clickableArea.Location = new Point(9, 9);

            //clickableArea.Click += (s, e) => {
            //    MessageBox.Show("Click ได้ ไม่ทะลุ!");
            //};

            //this.Controls.Add(clickableArea);



            //สมมติว่าโซนที่คลิกได้เป็นสี่เหลี่ยมตรงกลาง
            Label clickZone = new Label();
            //clickZone.Text = "Click Here";
            clickZone.TextAlign = ContentAlignment.MiddleCenter;
            clickZone.Size = new Size(20, 20);
            clickZone.Location = new Point(130, 100);
            clickZone.BackColor = Color.FromArgb(50, Color.White);
            clickZone.ForeColor = Color.Black;
            clickZone.Cursor = Cursors.Hand;

            // //clickZone.Click += (s, e) => {
            // //    MessageBox.Show("You clicked inside the zone!");
            // //};

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


        //private void Form1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    dragging = true;
        //    dragCursorPoint = Cursor.Position;
        //    dragFormPoint = this.Location;
        //}

        //private void Form1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (dragging)
        //    {
        //        Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
        //        this.Location = Point.Add(dragFormPoint, new Size(diff));
        //    }
        //}

        //private void Form1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    dragging = false;
        //}

    }
}
