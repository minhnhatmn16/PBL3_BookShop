namespace BookShop.Storekeeper
{
    partial class Form_MainStoreKeeper
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_Control = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.but_Personal = new System.Windows.Forms.Button();
            this.but_BookManage = new System.Windows.Forms.Button();
            this.panel_Slide = new System.Windows.Forms.Panel();
            this.but_ViewInvoice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.but_CreateInvoice = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.but_Exit = new System.Windows.Forms.Button();
            this.lbCurrentTime = new System.Windows.Forms.Label();
            this.lbRole = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Tick);
            // 
            // panel_Control
            // 
            this.panel_Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Control.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel_Control.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_Control.Controls.Add(this.pictureBox1);
            this.panel_Control.Location = new System.Drawing.Point(287, 113);
            this.panel_Control.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Control.Name = "panel_Control";
            this.panel_Control.Size = new System.Drawing.Size(1535, 833);
            this.panel_Control.TabIndex = 2;
            this.panel_Control.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Control_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::BookShop.Properties.Resources.BackGround1;
            this.pictureBox1.Location = new System.Drawing.Point(7, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1515, 816);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.but_Personal);
            this.panel1.Controls.Add(this.but_BookManage);
            this.panel1.Controls.Add(this.panel_Slide);
            this.panel1.Controls.Add(this.but_ViewInvoice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.but_CreateInvoice);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 945);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::BookShop.Properties.Resources.iconManageAccount;
            this.pictureBox5.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox5.Location = new System.Drawing.Point(112, 598);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(69, 63);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.but_Personal_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::BookShop.Properties.Resources.iconViewInvoice;
            this.pictureBox4.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox4.Location = new System.Drawing.Point(112, 448);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 70);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.but_ViewInvoice_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BookShop.Properties.Resources.iconCreateInvoice;
            this.pictureBox3.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox3.Location = new System.Drawing.Point(109, 302);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(72, 70);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.but_CreateInvoice_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BookShop.Properties.Resources.iconManageBook02;
            this.pictureBox2.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox2.Location = new System.Drawing.Point(100, 158);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(85, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.but_BookManage_Click);
            // 
            // but_Personal
            // 
            this.but_Personal.BackColor = System.Drawing.Color.Transparent;
            this.but_Personal.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.but_Personal.FlatAppearance.BorderSize = 2;
            this.but_Personal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.but_Personal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.but_Personal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Personal.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_Personal.ForeColor = System.Drawing.Color.White;
            this.but_Personal.Location = new System.Drawing.Point(12, 542);
            this.but_Personal.Margin = new System.Windows.Forms.Padding(4);
            this.but_Personal.Name = "but_Personal";
            this.but_Personal.Size = new System.Drawing.Size(267, 135);
            this.but_Personal.TabIndex = 2;
            this.but_Personal.Text = "Quản lí tài khoản cá nhân";
            this.but_Personal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_Personal.UseVisualStyleBackColor = false;
            this.but_Personal.Click += new System.EventHandler(this.but_Personal_Click);
            // 
            // but_BookManage
            // 
            this.but_BookManage.BackColor = System.Drawing.Color.Transparent;
            this.but_BookManage.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.but_BookManage.FlatAppearance.BorderSize = 2;
            this.but_BookManage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.but_BookManage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.but_BookManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_BookManage.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_BookManage.ForeColor = System.Drawing.Color.White;
            this.but_BookManage.Location = new System.Drawing.Point(12, 113);
            this.but_BookManage.Margin = new System.Windows.Forms.Padding(4);
            this.but_BookManage.Name = "but_BookManage";
            this.but_BookManage.Size = new System.Drawing.Size(267, 135);
            this.but_BookManage.TabIndex = 2;
            this.but_BookManage.Text = "Quản lí sách";
            this.but_BookManage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_BookManage.UseVisualStyleBackColor = false;
            this.but_BookManage.Click += new System.EventHandler(this.but_BookManage_Click);
            // 
            // panel_Slide
            // 
            this.panel_Slide.BackColor = System.Drawing.Color.Blue;
            this.panel_Slide.Location = new System.Drawing.Point(0, 113);
            this.panel_Slide.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Slide.Name = "panel_Slide";
            this.panel_Slide.Size = new System.Drawing.Size(9, 135);
            this.panel_Slide.TabIndex = 4;
            // 
            // but_ViewInvoice
            // 
            this.but_ViewInvoice.BackColor = System.Drawing.Color.Transparent;
            this.but_ViewInvoice.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.but_ViewInvoice.FlatAppearance.BorderSize = 2;
            this.but_ViewInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.but_ViewInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.but_ViewInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ViewInvoice.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_ViewInvoice.ForeColor = System.Drawing.Color.White;
            this.but_ViewInvoice.Location = new System.Drawing.Point(12, 399);
            this.but_ViewInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.but_ViewInvoice.Name = "but_ViewInvoice";
            this.but_ViewInvoice.Size = new System.Drawing.Size(267, 135);
            this.but_ViewInvoice.TabIndex = 2;
            this.but_ViewInvoice.Text = "Xem hóa đơn";
            this.but_ViewInvoice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_ViewInvoice.UseVisualStyleBackColor = false;
            this.but_ViewInvoice.Click += new System.EventHandler(this.but_ViewInvoice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhà sách KC";
            // 
            // but_CreateInvoice
            // 
            this.but_CreateInvoice.BackColor = System.Drawing.Color.Transparent;
            this.but_CreateInvoice.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.but_CreateInvoice.FlatAppearance.BorderSize = 2;
            this.but_CreateInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.but_CreateInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.but_CreateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_CreateInvoice.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_CreateInvoice.ForeColor = System.Drawing.Color.White;
            this.but_CreateInvoice.Location = new System.Drawing.Point(12, 256);
            this.but_CreateInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.but_CreateInvoice.Name = "but_CreateInvoice";
            this.but_CreateInvoice.Size = new System.Drawing.Size(267, 135);
            this.but_CreateInvoice.TabIndex = 2;
            this.but_CreateInvoice.Text = "Tạo hóa đơn";
            this.but_CreateInvoice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.but_CreateInvoice.UseVisualStyleBackColor = false;
            this.but_CreateInvoice.Click += new System.EventHandler(this.but_CreateInvoice_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LimeGreen;
            this.panel2.Controls.Add(this.but_Exit);
            this.panel2.Controls.Add(this.lbCurrentTime);
            this.panel2.Controls.Add(this.lbRole);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lbUserName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(287, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1536, 112);
            this.panel2.TabIndex = 1;
            // 
            // but_Exit
            // 
            this.but_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Exit.BackColor = System.Drawing.Color.Transparent;
            this.but_Exit.FlatAppearance.BorderSize = 0;
            this.but_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Exit.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold);
            this.but_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.but_Exit.Location = new System.Drawing.Point(1468, 4);
            this.but_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(64, 59);
            this.but_Exit.TabIndex = 4;
            this.but_Exit.Text = "X";
            this.but_Exit.UseVisualStyleBackColor = false;
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurrentTime.AutoSize = true;
            this.lbCurrentTime.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrentTime.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentTime.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbCurrentTime.Location = new System.Drawing.Point(1279, 37);
            this.lbCurrentTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(110, 28);
            this.lbCurrentTime.TabIndex = 6;
            this.lbCurrentTime.Text = "00:00:00";
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.BackColor = System.Drawing.Color.Transparent;
            this.lbRole.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.ForeColor = System.Drawing.Color.White;
            this.lbRole.Location = new System.Drawing.Point(207, 57);
            this.lbRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(99, 28);
            this.lbRole.TabIndex = 1;
            this.lbRole.Text = "Thủ kho";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(92, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Vai trò:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.White;
            this.lbUserName.Location = new System.Drawing.Point(207, 22);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(189, 28);
            this.lbUserName.TabIndex = 3;
            this.lbUserName.Text = "Tên Người Dùng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(47, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Người dùng:";
            // 
            // Form_MainStoreKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(1821, 945);
            this.Controls.Add(this.panel_Control);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_MainStoreKeeper";
            this.Text = "Form_Storekeeper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_Control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_Control;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_Personal;
        private System.Windows.Forms.Button but_ViewInvoice;
        private System.Windows.Forms.Button but_CreateInvoice;
        private System.Windows.Forms.Button but_BookManage;
        private System.Windows.Forms.Panel panel_Slide;
        private System.Windows.Forms.Button but_Exit;
        private System.Windows.Forms.Label lbCurrentTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}