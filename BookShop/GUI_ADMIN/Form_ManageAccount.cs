using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI;
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

namespace BookShop.GUI_ADMIN
{
    public partial class Form_ManageAccount : Form
    {
        //int numberProperty = 11;
        List<Account> Accounts = new List<Account>(); //save all property of Account. bcuz when we double click on a row
                                                      //we need to pass all property and the datagridview just display some necessary infor to
                                                      //viewer.
        Account mainAccount = new Account();
        public Form_ManageAccount(Account account)
        {
            InitializeComponent();
            this.mainAccount = account;
            dataGridView1.DataSource = Account_BLL.Instance.GetAccountInfor("");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Remove("RoleID"); //remove the property that not necessary when display to viewer
            dataGridView1.Columns.Remove("Password"); //remove the property that not necessary when display to viewer
            dataGridView1.Columns.Remove("SexID"); //remove the property that not necessary when display to viewer
            dataGridView1.Columns.Remove("Address"); //remove the property that not necessary when display to viewer

            vietnameseDatagridView();
            refreshGridView();
        }

        public void refreshGridView()
        {
            dataGridView1.DataSource = null;
            Accounts = Account_BLL.Instance.GetAccountInfor("");
            dataGridView1.DataSource = Accounts;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            Form_DetailedAccount formBookDetail = new Form_DetailedAccount(Accounts[idx]);
            formBookDetail.ShowDialog();
            refreshGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "";
            name = txtbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Account_BLL.Instance.GetAccountInfor(name);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Form_AddAccount test = new Form_AddAccount();
            test.ShowDialog();
            refreshGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<int> listAccountID = new List<int>();
                    foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    {
                        listAccountID.Add(Convert.ToInt32(i.Cells["UserID"].Value));
                        if (Convert.ToString(i.Cells["RoleName"].Value) == "Quản trị viên")
                        {
                            MessageBox.Show("Đây là tài khoản chủ! Không thể thực hiện xóa.", "Không thể xóa");
                            return;
                        }
                    }
                    Account_BLL.Instance.DeleteAccount_BLL(listAccountID);
                    //refresh after delete book
                    refreshGridView();
                }
            }
            else
            {
                MessageBox.Show("Chọn một tài khoản để xóa!");
            }
        }

        private void txtbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            Form_DetailedAccount formBookDetail = new Form_DetailedAccount(Accounts[idx]);
            formBookDetail.ShowDialog();
            refreshGridView();
        }

        public void vietnameseDatagridView()
        {
            DataGridViewColumn UserID = dataGridView1.Columns["UserID"];
            UserID.HeaderText = "Mã Tài khoản";
            DataGridViewColumn RoleName = dataGridView1.Columns["RoleName"];
            RoleName.HeaderText = "Vai trò";
            DataGridViewColumn AccountName = dataGridView1.Columns["AccountName"];
            AccountName.HeaderText = "Tên đăng nhập";
            DataGridViewColumn UserName = dataGridView1.Columns["UserName"];
            UserName.HeaderText = "Tên người dùng";
            DataGridViewColumn Sex = dataGridView1.Columns["Sex"];
            Sex.HeaderText = "Giới tính";
            DataGridViewColumn Birth = dataGridView1.Columns["Birth"];
            Birth.HeaderText = "Ngày sinh";
            DataGridViewColumn PhoneNumber = dataGridView1.Columns["PhoneNumber"];
            PhoneNumber.HeaderText = "SĐT";
            DataGridViewColumn Status = dataGridView1.Columns["Status"];
            Status.HeaderText = "Trạng thái";
        }

        private void btnPersonalAccount_Click(object sender, EventArgs e)
        {
            Form_DetailedAccount form = new Form_DetailedAccount(mainAccount);
            form.ShowDialog();
            refreshGridView();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && btnBlock.Text == "Khóa")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn Khóa tài khoản", "Xác nhận Khóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<int> listAccountID = new List<int>();
                    foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    {
                        listAccountID.Add(Convert.ToInt32(i.Cells["UserID"].Value));
                        if (Convert.ToString(i.Cells["RoleName"].Value) == "Quản trị viên")
                        {
                            MessageBox.Show("Đây là tài khoản chủ! Không thể thực hiện khóa.", "Không thể khóa");
                            return;
                        }
                    }
                    Account_BLL.Instance.BlockAccount_BLL(listAccountID.First());
                    //refresh after delete book
                    refreshGridView();
                }
            }
            else
            {
                MessageBox.Show("Chọn một tài khoản để khóa!");
            }
        }
    }
}
