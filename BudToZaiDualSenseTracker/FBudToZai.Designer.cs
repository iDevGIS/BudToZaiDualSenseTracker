using System.Drawing;

namespace BudToZaiDualSenseTracker
{
    partial class FBudToZai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private Microsoft.Web.WebView2.WinForms.WebView2 webView21;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBudToZai));
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.NSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.CMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CItemMenu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CItemMenuSep = new System.Windows.Forms.ToolStripSeparator();
            this.CItemMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.CMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.webView21.CreationProperties = null;
            this.webView21.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            this.webView21.Location = new System.Drawing.Point(9, 9);
            this.webView21.Margin = new System.Windows.Forms.Padding(0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(344, 197);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            // 
            // NSystemTray
            // 
            this.NSystemTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NSystemTray.ContextMenuStrip = this.CMenu;
            this.NSystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("NSystemTray.Icon")));
            this.NSystemTray.Text = "BudToZai";
            this.NSystemTray.Visible = true;
            // 
            // CMenu
            // 
            this.CMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CItemMenu1,
            this.CItemMenuSep,
            this.CItemMenuClose});
            this.CMenu.Name = "CMenu";
            this.CMenu.ShowCheckMargin = true;
            this.CMenu.Size = new System.Drawing.Size(273, 76);
            this.CMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.CMenu_ItemClicked);
            // 
            // CItemMenu1
            // 
            this.CItemMenu1.Checked = true;
            this.CItemMenu1.CheckOnClick = true;
            this.CItemMenu1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CItemMenu1.Image = global::BudToZaiDualSenseTracker.Properties.Resources.icon_menu_visibility_24;
            this.CItemMenu1.Name = "CItemMenu1";
            this.CItemMenu1.Size = new System.Drawing.Size(272, 22);
            this.CItemMenu1.Tag = "MenuToggleShowHide";
            this.CItemMenu1.Text = "Show/Hide (Control + Alt + B)";
            this.CItemMenu1.ToolTipText = "Toggle Show/Hide";
            // 
            // CItemMenuSep
            // 
            this.CItemMenuSep.Name = "CItemMenuSep";
            this.CItemMenuSep.Size = new System.Drawing.Size(269, 6);
            this.CItemMenuSep.Tag = "MenuSep";
            // 
            // CItemMenuClose
            // 
            this.CItemMenuClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CItemMenuClose.Image = global::BudToZaiDualSenseTracker.Properties.Resources.icon_menu_exit_24;
            this.CItemMenuClose.Name = "CItemMenuClose";
            this.CItemMenuClose.Size = new System.Drawing.Size(272, 22);
            this.CItemMenuClose.Tag = "MenuClose";
            this.CItemMenuClose.Text = "Quit";
            this.CItemMenuClose.ToolTipText = "Quit";
            // 
            // FBudToZai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(362, 215);
            this.Controls.Add(this.webView21);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FBudToZai";
            this.Opacity = 0.85D;
            this.Text = "BudToZai";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.CMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.NotifyIcon NSystemTray;
        private System.Windows.Forms.ContextMenuStrip CMenu;
        private System.Windows.Forms.ToolStripMenuItem CItemMenu1;
        private System.Windows.Forms.ToolStripSeparator CItemMenuSep;
        private System.Windows.Forms.ToolStripMenuItem CItemMenuClose;
    }
}

