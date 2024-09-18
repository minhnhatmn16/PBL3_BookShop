using BookShop.BLL;
using BookShop.BLL_ST;
using BookShop.Controls;
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

namespace BookShop.GUI_ADMIN
{
    public partial class Form_DetailedAccount : Form
    {
        Account account = new Account();

        public Form_DetailedAccount(Account account)
        {
            this.account = account;
            InitializeComponent();
            setInitialForm();
        }
        public void setInitialForm()
        {
            txtbID.Text = account.UserID.ToString();
            txtbAccountName.Text = account.AccountName;

            txtbPassword.Text = "";
            //txtbPassword.Text = SecurePasswordHasher.Hash(account.Password);
            txtbPassword.UseSystemPasswordChar = true;

            txtbName.Text = account.UserName;
            txtbRole.Text = account.RoleName;
            txtbBirth.Text = account.Birth.ToString();
            txtbStatus.Text = account.Status;

            TimeSpan age = DateTime.Today - account.Birth;
            int ageInYears = (int)(age.TotalDays / 365.25);
            txtbAge.Text = ageInYears.ToString();

            txtbSex.Text = account.Sex;
            txtbPhoneNumber.Text = account.PhoneNumber;
            txtbAddress.Text = account.Address;

            txtbID.ReadOnly = true;
            txtbAccountName.ReadOnly = true;
            txtbPassword.ReadOnly = true;
            txtbName.ReadOnly = true;
            txtbRole.ReadOnly = true;
            txtbBirth.ReadOnly = true;
            txtbAge.ReadOnly = true;
            txtbSex.ReadOnly = true;
            txtbPhoneNumber.ReadOnly = true;
            txtbAddress.ReadOnly = true;
            txtbStatus.ReadOnly = true;

            btnSave.Enabled = false;

            if(account.Status == StatusAccount.status[1])
            {
                btnUnLock.Text = "Mở Khóa";
            }
            else
            {
                btnUnLock.Text = "Khóa";
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if(btnChangePassword.Text == "Đổi mật khẩu")
            {
                txtbAccountName.ReadOnly = false;
                txtbPassword.ReadOnly = false;
                txtbPassword.UseSystemPasswordChar = false;
                btnChangePassword.Text = "Reset";
                btnSave.Enabled = true;
            }
            else
            {
                txtbAccountName.ReadOnly = true;
                txtbPassword.ReadOnly = true;
                txtbPassword.UseSystemPasswordChar = true;
                btnChangePassword.Text = "Đổi mật khẩu";
                btnSave.Enabled = false;
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if (btnUpdateAccount.Text == "Cập nhật thông tin")
            {
                btnUpdateAccount.Text = "Reset";
                setInitialForm();
                lockTxtb(true);
            }
            else
            {
                setInitialForm();
                btnUpdateAccount.Text = "Cập nhật thông tin";
                lockTxtb(false);
            }
        }

        public void lockTxtb(bool edit)
        {
            txtbAccountName.ReadOnly = !edit;
            txtbName.ReadOnly = !edit;
            txtbPhoneNumber.ReadOnly = !edit;
            txtbAddress.ReadOnly = !edit;

            btnSave.Enabled = edit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtbPhoneNumber.Text == "" || txtbAddress.Text == "" || txtbAccountName.Text == "" || txtbPassword.Text == "")
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin");
            }
            else
            {
                account.PhoneNumber = txtbPhoneNumber.Text;
                account.Address = txtbAddress.Text;
                account.UserName = txtbName.Text;
                
                if(btnChangePassword.Text == "Reset")
                {
                    account.AccountName = txtbAccountName.Text;
                    account.Password = SecurePasswordHasher.Hash(txtbPassword.Text);
                }
                Account_BLL.Instance.UpdateAccount(account);
                MessageBox.Show("Bạn đã cập nhật thành công!");
            }
            setInitialForm();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            if(account.RoleID == 1)
            {
                MessageBox.Show("Đây là tài khoản chủ! Không thể thực hiện khóa.", "Không thể khóa");
                return;
            }
            if(btnUnLock.Text == "Mở Khóa")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn Mở Khóa tài khoản", "Xác nhận Mở Khóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Account_BLL.Instance.UnlockAccount_BLL(account.UserID);
                    account.Status = StatusAccount.status[0];
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn Khóa tài khoản", "Xác nhận Khóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Account_BLL.Instance.BlockAccount_BLL(account.UserID);
                    account.Status = StatusAccount.status[1];
                }
            }
            setInitialForm();

        }
    }
}
