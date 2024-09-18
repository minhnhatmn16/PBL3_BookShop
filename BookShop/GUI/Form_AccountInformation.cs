using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.Storekeeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.Controls
{
    public partial class Form_AccountInformation : Form
    {
        Account account = new Account();
        public Form_AccountInformation(Account account)
        {
            this.account = account;
            InitializeComponent();
            setInitialForm();
        }

        public void setInitialForm()
        {
            txtbAccountName.Text = account.AccountName;
/*            String passStar = "";
            for(int i = 0; i < account.Password.Length; i++)
            {
                passStar += "*";
            }
            txtbPassword.Text = passStar;*/
            txtbName.Text = account.UserName;
            txtbRole.Text = account.RoleName;
            txtbBirth.Text = account.Birth.ToString();

            TimeSpan age = DateTime.Today - account.Birth;
            int ageInYears = (int)(age.TotalDays / 365.25);
            txtbAge.Text = ageInYears.ToString();

            txtbSex.Text = account.Sex;
            txtbPhoneNumber.Text = account.PhoneNumber;
            txtbAddress.Text = account.Address;

            txtbAccountName.ReadOnly = true;
            txtbPassword.ReadOnly = true;
            txtbName.ReadOnly = true;
            txtbRole.ReadOnly = true;
            txtbBirth.ReadOnly = true;
            txtbAge.ReadOnly = true;
            txtbSex.ReadOnly = true;
            txtbPhoneNumber.ReadOnly = true;
            txtbAddress.ReadOnly = true;

            btnSave.Enabled = false;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Form_ChangePassword form = new Form_ChangePassword(account);
            form.ShowDialog();
            account = form.account;
            setInitialForm();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if(btnUpdateAccount.Text == "Cập nhật thông tin")
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
            btnSave.Enabled = edit;
            txtbPhoneNumber.ReadOnly = !edit;
            txtbAddress.ReadOnly = !edit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtbPhoneNumber.Text == "" || txtbAddress.Text == "")
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin");
            }
            else
            {
                account.PhoneNumber = txtbPhoneNumber.Text;
                account.Address = txtbAddress.Text;
                Account_BLL.Instance.UpdateAccount(account);
                MessageBox.Show("Bạn đã cập nhật thành công!");
            }
        }
    }
}
