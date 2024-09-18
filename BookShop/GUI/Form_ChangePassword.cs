using BookShop.BLL;
using BookShop.BLL_ST;
using BookShop.DAL_ST;
using BookShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.Controls
{
    public partial class Form_ChangePassword : Form
    {
        public Account account = new Account();
        public Form_ChangePassword(Account acc)
        {
            InitializeComponent();
            account = acc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pic_Show1_Click(object sender, EventArgs e)
        {
            txtbPassword.UseSystemPasswordChar = true;
            pic_Hide1.Visible = true;
            pic_Show1.Visible = false;
        }

        private void pic_Hide1_Click(object sender, EventArgs e)
        {
            txtbPassword.UseSystemPasswordChar = false;
            pic_Hide1.Visible = false;
            pic_Show1.Visible = true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            txtbPassword.UseSystemPasswordChar = true;
            pic_Hide1.Visible = true;
            pic_Show1.Visible = false;

            txtbNewPassword.UseSystemPasswordChar = true;
            pic_Hide2.Visible = true;
            pic_Show2.Visible = false;

            txtbReNewPassword.UseSystemPasswordChar = true;
            pic_Hide3.Visible = true;
            pic_Show3.Visible = false;
        }

        private void pic_Show2_Click(object sender, EventArgs e)
        {
            txtbNewPassword.UseSystemPasswordChar = true;
            pic_Hide2.Visible = true;
            pic_Show2.Visible = false;
        }

        private void pic_Hide2_Click(object sender, EventArgs e)
        {
            txtbNewPassword.UseSystemPasswordChar = false;
            pic_Hide2.Visible = false;
            pic_Show2.Visible = true;
        }

        private void pic_Show3_Click(object sender, EventArgs e)
        {
            txtbReNewPassword.UseSystemPasswordChar = true;
            pic_Hide3.Visible = true;
            pic_Show3.Visible = false;
        }

        private void pic_Hide3_Click(object sender, EventArgs e)
        {
            txtbReNewPassword.UseSystemPasswordChar = false;
            pic_Hide3.Visible = false;
            pic_Show3.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string acc = txtbAccountName.Text;
            string password = txtbPassword.Text;
            // Hash
            //var hash = SecurePasswordHasher.Hash(password);

            // Verify
            var result = SecurePasswordHasher.Verify(password, Login_DAL.Instance.getPasswordByAccountName(acc));
            if(result == false)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Sai thông tin");
                txtbNewPassword.Text = txtbReNewPassword.Text = "";
                return;
            }
            if (Login_DAL.Instance.Staff_Infor(acc, password).Rows.Count > 0)
            {
                var result2 = SecurePasswordHasher.Verify(txtbReNewPassword.Text, Login_DAL.Instance.getPasswordByAccountName(acc));
                if (txtbNewPassword.Text != txtbReNewPassword.Text)
                {
                    MessageBox.Show("Xin nhập lại mật khẩu mới!");
                    txtbNewPassword.Text = txtbReNewPassword.Text = "";
                }
                else if(result2)
                {
                    MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ!");
                    txtbNewPassword.Text = txtbReNewPassword.Text = "";
                }
                else
                {
                    account.Password = SecurePasswordHasher.Hash(txtbReNewPassword.Text);
                    Account_BLL.Instance.UpdateAccount(account);
                    MessageBox.Show("Mật khẩu cập nhật thành công!");
                    txtbAccountName.Text = txtbNewPassword.Text = txtbPassword.Text = txtbReNewPassword.Text = "";
                    this.Close();
                }
            }
            
        }
    }
}
