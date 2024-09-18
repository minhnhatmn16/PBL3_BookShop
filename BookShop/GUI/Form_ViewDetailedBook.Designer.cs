namespace BookShop.GUI_SALE
{
    partial class Form_ViewDetailedBook
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.pictureboxBookCover = new System.Windows.Forms.PictureBox();
            this.txtbTranslator = new System.Windows.Forms.TextBox();
            this.txtbPublisher = new System.Windows.Forms.TextBox();
            this.txtbQuantity = new System.Windows.Forms.TextBox();
            this.txtbAuthor = new System.Windows.Forms.TextBox();
            this.txtbSalePrice = new System.Windows.Forms.TextBox();
            this.txtbPublishYear = new System.Windows.Forms.TextBox();
            this.txtbBookInforID = new System.Windows.Forms.TextBox();
            this.txtbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAddBookInfor = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxBookCover)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.btnX);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lbAddBookInfor);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 539);
            this.panel1.TabIndex = 0;
            // 
            // btnX
            // 
            this.btnX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnX.Location = new System.Drawing.Point(903, -1);
            this.btnX.Margin = new System.Windows.Forms.Padding(4);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(55, 49);
            this.btnX.TabIndex = 5;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cbbCategory);
            this.panel2.Controls.Add(this.pictureboxBookCover);
            this.panel2.Controls.Add(this.txtbTranslator);
            this.panel2.Controls.Add(this.txtbPublisher);
            this.panel2.Controls.Add(this.txtbQuantity);
            this.panel2.Controls.Add(this.txtbAuthor);
            this.panel2.Controls.Add(this.txtbSalePrice);
            this.panel2.Controls.Add(this.txtbPublishYear);
            this.panel2.Controls.Add(this.txtbBookInforID);
            this.panel2.Controls.Add(this.txtbTitle);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(20, 52);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 468);
            this.panel2.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label10.Location = new System.Drawing.Point(485, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "Mã sách";
            // 
            // cbbCategory
            // 
            this.cbbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(597, 130);
            this.cbbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(192, 31);
            this.cbbCategory.TabIndex = 12;
            // 
            // pictureboxBookCover
            // 
            this.pictureboxBookCover.ErrorImage = null;
            this.pictureboxBookCover.ImageLocation = "";
            this.pictureboxBookCover.Location = new System.Drawing.Point(4, 4);
            this.pictureboxBookCover.Margin = new System.Windows.Forms.Padding(4);
            this.pictureboxBookCover.Name = "pictureboxBookCover";
            this.pictureboxBookCover.Size = new System.Drawing.Size(403, 460);
            this.pictureboxBookCover.TabIndex = 11;
            this.pictureboxBookCover.TabStop = false;
            // 
            // txtbTranslator
            // 
            this.txtbTranslator.Location = new System.Drawing.Point(597, 247);
            this.txtbTranslator.Margin = new System.Windows.Forms.Padding(4);
            this.txtbTranslator.Name = "txtbTranslator";
            this.txtbTranslator.Size = new System.Drawing.Size(192, 30);
            this.txtbTranslator.TabIndex = 8;
            // 
            // txtbPublisher
            // 
            this.txtbPublisher.Location = new System.Drawing.Point(597, 209);
            this.txtbPublisher.Margin = new System.Windows.Forms.Padding(4);
            this.txtbPublisher.Name = "txtbPublisher";
            this.txtbPublisher.Size = new System.Drawing.Size(192, 30);
            this.txtbPublisher.TabIndex = 8;
            // 
            // txtbQuantity
            // 
            this.txtbQuantity.Location = new System.Drawing.Point(597, 326);
            this.txtbQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtbQuantity.Name = "txtbQuantity";
            this.txtbQuantity.Size = new System.Drawing.Size(192, 30);
            this.txtbQuantity.TabIndex = 3;
            // 
            // txtbAuthor
            // 
            this.txtbAuthor.Location = new System.Drawing.Point(597, 170);
            this.txtbAuthor.Margin = new System.Windows.Forms.Padding(4);
            this.txtbAuthor.Name = "txtbAuthor";
            this.txtbAuthor.Size = new System.Drawing.Size(192, 30);
            this.txtbAuthor.TabIndex = 3;
            // 
            // txtbSalePrice
            // 
            this.txtbSalePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbSalePrice.Location = new System.Drawing.Point(597, 287);
            this.txtbSalePrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtbSalePrice.Name = "txtbSalePrice";
            this.txtbSalePrice.Size = new System.Drawing.Size(192, 30);
            this.txtbSalePrice.TabIndex = 3;
            // 
            // txtbPublishYear
            // 
            this.txtbPublishYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbPublishYear.Location = new System.Drawing.Point(597, 91);
            this.txtbPublishYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtbPublishYear.Name = "txtbPublishYear";
            this.txtbPublishYear.Size = new System.Drawing.Size(100, 30);
            this.txtbPublishYear.TabIndex = 3;
            // 
            // txtbBookInforID
            // 
            this.txtbBookInforID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbBookInforID.Location = new System.Drawing.Point(597, 16);
            this.txtbBookInforID.Margin = new System.Windows.Forms.Padding(4);
            this.txtbBookInforID.Name = "txtbBookInforID";
            this.txtbBookInforID.Size = new System.Drawing.Size(100, 30);
            this.txtbBookInforID.TabIndex = 3;
            // 
            // txtbTitle
            // 
            this.txtbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbTitle.Location = new System.Drawing.Point(597, 52);
            this.txtbTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtbTitle.Name = "txtbTitle";
            this.txtbTitle.Size = new System.Drawing.Size(305, 30);
            this.txtbTitle.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(460, 247);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Người dịch";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label6.Location = new System.Drawing.Point(431, 209);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nhà xuất bản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label5.Location = new System.Drawing.Point(484, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Năm Xb";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label9.Location = new System.Drawing.Point(489, 287);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Giá bán";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label8.Location = new System.Drawing.Point(496, 170);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tác giả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(485, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thể loại";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label7.Location = new System.Drawing.Point(479, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tên sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(480, 330);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // lbAddBookInfor
            // 
            this.lbAddBookInfor.AutoSize = true;
            this.lbAddBookInfor.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddBookInfor.ForeColor = System.Drawing.Color.White;
            this.lbAddBookInfor.Location = new System.Drawing.Point(387, 9);
            this.lbAddBookInfor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAddBookInfor.Name = "lbAddBookInfor";
            this.lbAddBookInfor.Size = new System.Drawing.Size(182, 36);
            this.lbAddBookInfor.TabIndex = 2;
            this.lbAddBookInfor.Text = "Chi tiết sách";
            // 
            // Form_ViewDetailedBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(965, 545);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_ViewDetailedBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookDetail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxBookCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbAddBookInfor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtbQuantity;
        private System.Windows.Forms.TextBox txtbAuthor;
        private System.Windows.Forms.TextBox txtbSalePrice;
        private System.Windows.Forms.TextBox txtbPublishYear;
        private System.Windows.Forms.TextBox txtbTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbPublisher;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.PictureBox pictureboxBookCover;
        private System.Windows.Forms.TextBox txtbTranslator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtbBookInforID;
    }
}