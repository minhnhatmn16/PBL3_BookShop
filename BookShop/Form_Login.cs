using BookShop.BLL;
using BookShop.BLL_ST;
using BookShop.Controls;
using BookShop.DAL_ST;
using BookShop.GUI_ADMIN;
using BookShop.GUI_Sale;
using BookShop.Storekeeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookShop
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();

            /*            // Hash
                        var hash = SecurePasswordHasher.Hash("Admin");
                        txtbUserName.Text = hash;
                        // Verify
                        var result = SecurePasswordHasher.Verify("Admin", hash);*/
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void but_Login_Click(object sender, EventArgs e)
        {
            string account = txtbUserName.Text;
            string password = txtbPassword.Text;
            if (!Login_DAL.Instance.checkHashPassword(account, password))
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu!");
                return;
            }
            if (Login_DAL.Instance.Staff_Infor(account, password).Rows.Count > 0)
            {
                Login_DAL.Instance.Get_Infor_Staff();
                if(Login_DAL.Instance.status == "Block")
                {
                    MessageBox.Show("Tài khoản của bạn tạm thời bị khóa!", "Trạng thái tài khoản");
                    return;
                }
                Account_BLL.Instance.UserID = Login_DAL.Instance.ID_USER; //assign value to field 'UserID' 
                string k = Login_DAL.Instance.ID_Pos;
                switch (k)
                {
                    case "1":
                        Form_Admin form1 = new Form_Admin();
                        form1.ShowDialog();
                        txtbUserName.Text = "";
                        txtbPassword.Text = "";
                        break;
                    case "2":
                        Form_MainStoreKeeper form2 = new Form_MainStoreKeeper();
                        form2.ShowDialog();
                        txtbUserName.Text = "";
                        txtbPassword.Text = "";
                        break;
                    case "3":
                        Form_MainSalePerson form3 = new Form_MainSalePerson();
                        form3.ShowDialog();
                        txtbUserName.Text = "";
                        txtbPassword.Text = "";
                        break;
                }
            }
            
        }

        private void pic_Show_Click(object sender, EventArgs e)
        {
            txtbPassword.UseSystemPasswordChar = true;
            pic_Show.Visible = false;
            pic_Hide.Visible = true;
        }

        private void pic_Hide_Click(object sender, EventArgs e)
        {
            txtbPassword.UseSystemPasswordChar = false;
            pic_Show.Visible = true;
            pic_Hide.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtbPassword.UseSystemPasswordChar = true;
            pic_Show.Visible = false;
            pic_Hide.Visible = true;
        }
    }
}
