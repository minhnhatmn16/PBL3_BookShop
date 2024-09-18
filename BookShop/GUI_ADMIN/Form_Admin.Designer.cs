namespace BookShop.GUI_ADMIN
{
    partial class Form_Admin
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
            this.panel_Slide = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnManageRevenue = new System.Windows.Forms.Button();
            this.btnManageAccount = new System.Windows.Forms.Button();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.btnManageBook = new System.Windows.Forms.Button();
            this.btnViewSaledInvoice = new System.Windows.Forms.Button();
            this.btnViewImportInvoice = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.Controls.Add(this.panel_Slide);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnManageRevenue);
            this.panel1.Controls.Add(this.btnManageAccount);
            this.panel1.Controls.Add(this.btnManageCustomer);
            this.panel1.Controls.Add(this.btnManageBook);
            this.panel1.Controls.Add(this.btnViewSaledInvoice);
            this.panel1.Controls.Add(this.btnViewImportInvoice);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 945);
            this.panel1.TabIndex = 0;
            // 
            // panel_Slide
            // 
            this.panel_Slide.BackColor = System.Drawing.Color.Blue;
            this.panel_Slide.Location = new System.Drawing.Point(0, 113);
            this.panel_Slide.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Slide.Name = "panel_Slide";
            this.panel_Slide.Size = new System.Drawing.Size(9, 127);
            this.panel_Slide.TabIndex = 7;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::BookShop.Properties.Resources.iconManageAccount;
            this.pictureBox7.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox7.Location = new System.Drawing.Point(109, 847);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(69, 63);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.but_Personal_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::BookShop.Properties.Resources.iconRevenue;
            this.pictureBox6.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox6.Location = new System.Drawing.Point(109, 720);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(69, 63);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.btnManageRevenue_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::BookShop.Properties.Resources.manageCustomer;
            this.pictureBox5.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox5.Location = new System.Drawing.Point(109, 586);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(69, 63);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.btnManageCustomer_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BookShop.Properties.Resources.iconViewSaleInvoice;
            this.pictureBox2.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox2.Location = new System.Drawing.Point(109, 442);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.btnViewSaledInvoice_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::BookShop.Properties.Resources.iconViewInvoice;
            this.pictureBox4.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox4.Location = new System.Drawing.Point(109, 298);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 70);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.btnViewImportInvoice_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BookShop.Properties.Resources.iconManageBook02;
            this.pictureBox3.InitialImage = global::BookShop.Properties.Resources.iconManageBook;
            this.pictureBox3.Location = new System.Drawing.Point(101, 155);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(85, 70);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.but_BookManage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhà sách KC";
            // 
            // btnManageRevenue
            // 
            this.btnManageRevenue.BackColor = System.Drawing.Color.Transparent;
            this.btnManageRevenue.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnManageRevenue.FlatAppearance.BorderSize = 2;
            this.btnManageRevenue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.btnManageRevenue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnManageRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageRevenue.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageRevenue.ForeColor = System.Drawing.Color.White;
            this.btnManageRevenue.Location = new System.Drawing.Point(11, 676);
            this.btnManageRevenue.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageRevenue.Name = "btnManageRevenue";
            this.btnManageRevenue.Size = new System.Drawing.Size(267, 127);
            this.btnManageRevenue.TabIndex = 2;
            this.btnManageRevenue.Text = "Quản lý doanh thu";
            this.btnManageRevenue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManageRevenue.UseVisualStyleBackColor = false;
            this.btnManageRevenue.Click += new System.EventHandler(this.btnManageRevenue_Click);
            // 
            // btnManageAccount
            // 
            this.btnManageAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnManageAccount.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnManageAccount.FlatAppearance.BorderSize = 2;
            this.btnManageAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.btnManageAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnManageAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageAccount.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageAccount.ForeColor = System.Drawing.Color.White;
            this.btnManageAccount.Location = new System.Drawing.Point(11, 811);
            this.btnManageAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageAccount.Name = "btnManageAccount";
            this.btnManageAccount.Size = new System.Drawing.Size(267, 127);
            this.btnManageAccount.TabIndex = 2;
            this.btnManageAccount.Text = "Quản lý tài khoản";
            this.btnManageAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManageAccount.UseVisualStyleBackColor = false;
            this.btnManageAccount.Click += new System.EventHandler(this.but_Personal_Click);
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnManageCustomer.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnManageCustomer.FlatAppearance.BorderSize = 2;
            this.btnManageCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.btnManageCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnManageCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCustomer.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageCustomer.ForeColor = System.Drawing.Color.White;
            this.btnManageCustomer.Location = new System.Drawing.Point(12, 542);
            this.btnManageCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(267, 127);
            this.btnManageCustomer.TabIndex = 2;
            this.btnManageCustomer.Text = "Quản lý khách hàng";
            this.btnManageCustomer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManageCustomer.UseVisualStyleBackColor = false;
            this.btnManageCustomer.Click += new System.EventHandler(this.btnManageCustomer_Click);
            // 
            // btnManageBook
            // 
            this.btnManageBook.BackColor = System.Drawing.Color.Transparent;
            this.btnManageBook.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnManageBook.FlatAppearance.BorderSize = 2;
            this.btnManageBook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.btnManageBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnManageBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageBook.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageBook.ForeColor = System.Drawing.Color.White;
            this.btnManageBook.Location = new System.Drawing.Point(12, 113);
            this.btnManageBook.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageBook.Name = "btnManageBook";
            this.btnManageBook.Size = new System.Drawing.Size(267, 127);
            this.btnManageBook.TabIndex = 2;
            this.btnManageBook.Text = "Quản lý sách";
            this.btnManageBook.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManageBook.UseVisualStyleBackColor = false;
            this.btnManageBook.Click += new System.EventHandler(this.but_BookManage_Click);
            // 
            // btnViewSaledInvoice
            // 
            this.btnViewSaledInvoice.BackColor = System.Drawing.Color.Transparent;
            this.btnViewSaledInvoice.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnViewSaledInvoice.FlatAppearance.BorderSize = 2;
            this.btnViewSaledInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.btnViewSaledInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnViewSaledInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSaledInvoice.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSaledInvoice.ForeColor = System.Drawing.Color.White;
            this.btnViewSaledInvoice.Location = new System.Drawing.Point(12, 399);
            this.btnViewSaledInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewSaledInvoice.Name = "btnViewSaledInvoice";
            this.btnViewSaledInvoice.Size = new System.Drawing.Size(267, 127);
            this.btnViewSaledInvoice.TabIndex = 2;
            this.btnViewSaledInvoice.Text = "Hóa đơn bán hàng";
            this.btnViewSaledInvoice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewSaledInvoice.UseVisualStyleBackColor = false;
            this.btnViewSaledInvoice.Click += new System.EventHandler(this.btnViewSaledInvoice_Click);
            // 
            // btnViewImportInvoice
            // 
            this.btnViewImportInvoice.BackColor = System.Drawing.Color.Transparent;
            this.btnViewImportInvoice.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnViewImportInvoice.FlatAppearance.BorderSize = 2;
            this.btnViewImportInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.btnViewImportInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnViewImportInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewImportInvoice.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewImportInvoice.ForeColor = System.Drawing.Color.White;
            this.btnViewImportInvoice.Location = new System.Drawing.Point(12, 256);
            this.btnViewImportInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewImportInvoice.Name = "btnViewImportInvoice";
            this.btnViewImportInvoice.Size = new System.Drawing.Size(267, 127);
            this.btnViewImportInvoice.TabIndex = 2;
            this.btnViewImportInvoice.Text = "Hóa đơn nhập kho";
            this.btnViewImportInvoice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewImportInvoice.UseVisualStyleBackColor = false;
            this.btnViewImportInvoice.Click += new System.EventHandler(this.btnViewImportInvoice_Click);
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
            this.panel2.Size = new System.Drawing.Size(1535, 112);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // but_Exit
            // 
            this.but_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Exit.BackColor = System.Drawing.Color.Transparent;
            this.but_Exit.FlatAppearance.BorderSize = 0;
            this.but_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Exit.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold);
            this.but_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.but_Exit.Location = new System.Drawing.Point(1467, 4);
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
            this.lbCurrentTime.Location = new System.Drawing.Point(1277, 37);
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
            this.lbRole.Location = new System.Drawing.Point(207, 55);
            this.lbRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(83, 28);
            this.lbRole.TabIndex = 1;
            this.lbRole.Text = "Admin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(105, 55);
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
            this.lbUserName.Location = new System.Drawing.Point(207, 21);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(186, 28);
            this.lbUserName.TabIndex = 3;
            this.lbUserName.Text = "Phan Chí Cương";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(47, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Người dùng:";
            // 
            // Form_Admin
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
            this.Name = "Form_Admin";
            this.Text = "Form_Storekeeper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_Control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_Control;
        private System.Windows.Forms.Label lbRole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnManageCustomer;
        private System.Windows.Forms.Button btnViewSaledInvoice;
        private System.Windows.Forms.Button btnViewImportInvoice;
        private System.Windows.Forms.Button btnManageBook;
        private System.Windows.Forms.Button but_Exit;
        private System.Windows.Forms.Label lbCurrentTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnManageAccount;
        private System.Windows.Forms.Button btnManageRevenue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel_Slide;
    }
}