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
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookShop.GUI_ADMIN
{
    public partial class Form_AddAccount : Form
    {
        Account account = new Account();
        List<Role> listRole = new List<Role>();
        public Form_AddAccount()
        {
            InitializeComponent();
            setCombobox();
            setInitialForm();
            txtbID.Text = Account_BLL.Instance.getNextAccountID_BLL().ToString();
        }
        public void setCombobox()
        {
            listRole = Role_BLL.Instance.GetRoleInfor("");
            cbbRole.DataSource = listRole;
            cbbRole.DisplayMember = "RoleName";
            cbbRole.SelectedIndex = -1; //clear combobox

            cbbSex.Items.Add(Gender.ID[1]);
            cbbSex.Items.Add(Gender.ID[2]);
            cbbSex.Items.Add(Gender.ID[3]);
        }
        public void setInitialForm()
        {
            txtbID.Text = Account_BLL.Instance.getNextAccountID_BLL().ToString();
            txtbPhoneNumber.Text = "";
            txtbAddress.Text = "";
            txtbAccountName.Text = "";
            txtbPassword.Text = "";
            txtbName.Text = "";
            cbbRole.SelectedIndex = -1;
            cbbSex.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
        }

        public bool checkNullTxtb()
        {
            if (txtbPhoneNumber.Text == "" || txtbAddress.Text == "" || txtbAccountName.Text == "" || txtbPassword.Text == "" ||
                txtbName.Text == "" || cbbRole.SelectedIndex == -1 || cbbSex.SelectedIndex == -1)
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkNullTxtb())
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin");
            }
            else
            {
                account.AccountName = txtbAccountName.Text;
                account.PhoneNumber = txtbPhoneNumber.Text;
                account.Address = txtbAddress.Text;
                account.UserName = txtbName.Text;

                account.Password = SecurePasswordHasher.Hash(txtbPassword.Text);

                account.SexID = cbbSex.SelectedIndex + 1;
                account.RoleID = cbbRole.SelectedIndex + 1;
                account.Birth = dateTimePicker1.Value;
                account.Status = StatusAccount.status[0];

                Account_BLL.Instance.AddAccount_BLL(account);
                MessageBox.Show("Bạn đã thêm tài khoản thành công!");
                this.Close();

            }
            setInitialForm();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan age = DateTime.Today - dateTimePicker1.Value;
            int ageInYears = (int)(age.TotalDays / 365.25);
            txtbAge.Text = ageInYears.ToString();
        }

        private void txtbAccountName_TextChanged(object sender, EventArgs e)
        {
            if (Login_DAL.Instance.getPasswordByAccountName(txtbAccountName.Text) != "")
            {
                //MessageBox.Show("Tài khoản này đã tồn tại vui lòng chọn tên khác");
                //txtbAccountName.Text = "";
                label_Error.Text = "Tên đăng nhập đã tồn tại";
            }
            else label_Error.Text = "";
        }

        private void Load_Data(object sender, EventArgs e)
        {
            label_Error.Text = "";
        }
    }
}
