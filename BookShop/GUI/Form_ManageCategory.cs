using BookShop.BLL_ST;
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

namespace BookShop.GUI
{
    public partial class Form_ManageCategory : Form
    {
        Category category = new Category();
        List<Category> categorys = new List<Category>();
        public Form_ManageCategory()
        {
            InitializeComponent();
            categorys = Category_BLL.Instance.GetCategoryInfor("");
            dataGridView1.DataSource = categorys;
            vietnameseDatagridView();
            txtbID.Text = Category_BLL.Instance.getNextCategoryID_BLL().ToString();
        }
        public void refreshGridView()
        {
            txtbSearch.Text = "";
            dataGridView1.DataSource = null;
            categorys = Category_BLL.Instance.GetCategoryInfor("");
            dataGridView1.DataSource = categorys;
            txtbCategoryName.Text = "";
            txtbID.Text = Category_BLL.Instance.getNextCategoryID_BLL().ToString();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "";
            name = txtbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = categorys = Category_BLL.Instance.GetCategoryInfor(name);
            vietnameseDatagridView();
        }
        private void txtbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txtbCategoryName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                category.CategoryName = txtbCategoryName.Text;
                if (btnAddCategory.Text == "Thêm")
                {
                    Category_BLL.Instance.AddCategory_BLL(category);
                    MessageBox.Show("Bạn đã thêm thành công!");
                }
                else
                {
                    category.CategoryID = Convert.ToInt32(txtbID.Text);
                    Category_BLL.Instance.AddCategory_BLL(category);
                    MessageBox.Show("Bạn đã sửa thành công!");
                }

                refreshGridView();
            }
        }

        public void vietnameseDatagridView()
        {
            DataGridViewColumn CategoryID = dataGridView1.Columns["CategoryID"];
            CategoryID.HeaderText = "Mã thể loại";
            DataGridViewColumn CategoryName = dataGridView1.Columns["CategoryName"];
            CategoryName.HeaderText = "Tên";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Sửa")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    {
                        txtbID.Text = (i.Cells["CategoryID"].Value).ToString();
                        txtbCategoryName.Text = (i.Cells["CategoryName"].Value).ToString();
                    }
                    btnEdit.Text = "Reset";
                    btnAddCategory.Text = "OK";
                    lbAddBookInfor.Text = "Sửa thể loại";
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp để sửa!");
                }
            }
            else
            {
                txtbID.Text = Category_BLL.Instance.getNextCategoryID_BLL().ToString();
                txtbCategoryName.Text = "";
                btnEdit.Text = "Sửa";
                btnAddCategory.Text = "Thêm";
                lbAddBookInfor.Text = "Thêm thể loại";
            }
        }
    }
}
