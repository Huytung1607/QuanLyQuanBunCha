namespace QuanLyQuanBunCha
{
    partial class FormTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrangChu));
            this.DangXuat = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmKhoHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DangXuat
            // 
            this.DangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DangXuat.Location = new System.Drawing.Point(690, 406);
            this.DangXuat.Name = "DangXuat";
            this.DangXuat.Size = new System.Drawing.Size(110, 41);
            this.DangXuat.TabIndex = 1;
            this.DangXuat.Text = "Đăng xuất";
            this.DangXuat.UseVisualStyleBackColor = false;
            this.DangXuat.Click += new System.EventHandler(this.DangXuat_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kháchHàngToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.khoHàngToolStripMenuItem,
            this.khoHàngToolStripMenuItem1,
            this.thanhToánToolStripMenuItem,
            this.tìmKiếmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.nhânViênToolStripMenuItem.Text = "Nhân Viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // khoHàngToolStripMenuItem
            // 
            this.khoHàngToolStripMenuItem.Name = "khoHàngToolStripMenuItem";
            this.khoHàngToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.khoHàngToolStripMenuItem.Text = "Đơn Hàng";
            this.khoHàngToolStripMenuItem.Click += new System.EventHandler(this.khoHàngToolStripMenuItem_Click);
            // 
            // khoHàngToolStripMenuItem1
            // 
            this.khoHàngToolStripMenuItem1.Name = "khoHàngToolStripMenuItem1";
            this.khoHàngToolStripMenuItem1.Size = new System.Drawing.Size(89, 24);
            this.khoHàngToolStripMenuItem1.Text = "Kho Hàng";
            this.khoHàngToolStripMenuItem1.Click += new System.EventHandler(this.khoHàngToolStripMenuItem1_Click);
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.thanhToánToolStripMenuItem.Text = "Thanh Toán";
            this.thanhToánToolStripMenuItem.Click += new System.EventHandler(this.thanhToánToolStripMenuItem_Click);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tìmKiếmKháchHàngToolStripMenuItem,
            this.tìmKiToolStripMenuItem,
            this.tìmKiếmĐơnHàngToolStripMenuItem,
            this.tìmKiếmKhoHàngToolStripMenuItem,
            this.tìmKiếmThanhToánToolStripMenuItem});
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            // 
            // tìmKiếmKháchHàngToolStripMenuItem
            // 
            this.tìmKiếmKháchHàngToolStripMenuItem.Name = "tìmKiếmKháchHàngToolStripMenuItem";
            this.tìmKiếmKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.tìmKiếmKháchHàngToolStripMenuItem.Text = "Tìm kiếm khách hàng";
            this.tìmKiếmKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmKháchHàngToolStripMenuItem_Click);
            // 
            // tìmKiToolStripMenuItem
            // 
            this.tìmKiToolStripMenuItem.Name = "tìmKiToolStripMenuItem";
            this.tìmKiToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.tìmKiToolStripMenuItem.Text = "Tìm kiếm nhân viên";
            this.tìmKiToolStripMenuItem.Click += new System.EventHandler(this.tìmKiToolStripMenuItem_Click);
            // 
            // tìmKiếmĐơnHàngToolStripMenuItem
            // 
            this.tìmKiếmĐơnHàngToolStripMenuItem.Name = "tìmKiếmĐơnHàngToolStripMenuItem";
            this.tìmKiếmĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.tìmKiếmĐơnHàngToolStripMenuItem.Text = "Tìm kiếm đơn hàng";
            this.tìmKiếmĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmĐơnHàngToolStripMenuItem_Click);
            // 
            // tìmKiếmKhoHàngToolStripMenuItem
            // 
            this.tìmKiếmKhoHàngToolStripMenuItem.Name = "tìmKiếmKhoHàngToolStripMenuItem";
            this.tìmKiếmKhoHàngToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.tìmKiếmKhoHàngToolStripMenuItem.Text = "Tìm kiếm kho hàng";
            this.tìmKiếmKhoHàngToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmKhoHàngToolStripMenuItem_Click);
            // 
            // tìmKiếmThanhToánToolStripMenuItem
            // 
            this.tìmKiếmThanhToánToolStripMenuItem.Name = "tìmKiếmThanhToánToolStripMenuItem";
            this.tìmKiếmThanhToánToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.tìmKiếmThanhToánToolStripMenuItem.Text = "Tìm kiếm thanh toán";
            this.tìmKiếmThanhToánToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmThanhToánToolStripMenuItem_Click);
            // 
            // FormTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DangXuat);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTrangChu";
            this.Text = "FormTrangChu";
            this.Load += new System.EventHandler(this.FormTrangChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button DangXuat;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmĐơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmKhoHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmThanhToánToolStripMenuItem;
    }
}