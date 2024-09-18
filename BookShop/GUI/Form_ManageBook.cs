using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace BookShop.Controls
{
    public partial class Form_ManageBook : Form
    {
        /*change*/
        List<BookInfor> listBookInfors = new List<BookInfor>();
        BindingList<BookInfor> bookInfors;

        /*change*/
        public Form_ManageBook()
        {
            InitializeComponent();
            listBookInfors = CSDL_OOP.Instance.GetBookInfor("");
            bookInfors = new BindingList<BookInfor>(listBookInfors);

            dataGridView1.DataSource = bookInfors;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Remove("CategoryID"); //remove the property that not necessary when display to viewer
            dataGridView1.Columns.Remove("Cover"); //remove the property that not necessary when display to viewer
            dataGridView1.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.Automatic;
            vietnameseDatagridView();
            setCombobox();
            refreshGridView();
        }

        /*change*/
        public void refreshGridView()
        {
            txtbSearch.Text = "";
            cbbCategory.SelectedIndex = -1; //clear combobox

            dataGridView1.DataSource = null;
            listBookInfors = CSDL_OOP.Instance.GetBookInfor("");
            bookInfors = new BindingList<BookInfor>(listBookInfors);
            dataGridView1.DataSource = bookInfors;
/*            dataGridView1.Update();
            dataGridView1.Refresh();*/
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            Form_BookDetail formBookDetail = new Form_BookDetail(bookInfors[idx]);
            formBookDetail.ShowDialog();
            refreshGridView();
        }

        /*change*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "";
            cbbCategory.SelectedIndex = -1;
            name = txtbSearch.Text;

            listBookInfors = CSDL_OOP.Instance.GetBookInfor(name); ;
            bookInfors = new BindingList<BookInfor>(listBookInfors);
            dataGridView1.DataSource = bookInfors;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Form_AddBookPic test = new Form_AddBookPic();
            test.ShowDialog();
            //refresh after add book
            refreshGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<int> listBookInforID = new List<int>();
                    foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    {
                        listBookInforID.Add(Convert.ToInt32(i.Cells["BookInforID"].Value));
                    }
                    BookInfor_BLL.Instance.DeleteBookInfor_BLL(listBookInforID);
                    //refresh after delete book
                    refreshGridView();
                }
            }
            else
            {
                MessageBox.Show("Chọn một sách để xóa!");
            }
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
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            Form_BookDetail formBookDetail = new Form_BookDetail(bookInfors[idx]);
            formBookDetail.ShowDialog();
        }

        public void vietnameseDatagridView()
        {
            DataGridViewColumn bookInforID = dataGridView1.Columns["BookInforID"];
            bookInforID.HeaderText = "Mã sách";
            DataGridViewColumn Title = dataGridView1.Columns["Title"];
            Title.HeaderText = "Tên sách";
            DataGridViewColumn PublishYear = dataGridView1.Columns["PublishYear"];
            PublishYear.HeaderText = "Năm xb";
            DataGridViewColumn Category = dataGridView1.Columns["Category"];
            Category.HeaderText = "Thể loại";
            DataGridViewColumn Author = dataGridView1.Columns["Author"];
            Author.HeaderText = "Tác giả";
            DataGridViewColumn Publisher = dataGridView1.Columns["Publisher"];
            Publisher.HeaderText = "NXB";
            DataGridViewColumn Translator = dataGridView1.Columns["Translator"];
            Translator.HeaderText = "Người dịch";
            DataGridViewColumn SalePrice = dataGridView1.Columns["SalePrice"];
            SalePrice.HeaderText = "Giá bán";
            DataGridViewColumn Quantity = dataGridView1.Columns["Quantity"];
            Quantity.HeaderText = "Số lượng";
        }

        List<Category> listCategory = new List<Category>();
        public void setCombobox()
        {
            listCategory = Category_BLL.Instance.GetCategoryInfor("");
            cbbCategory.DataSource = listCategory;
            cbbCategory.DisplayMember = "CategoryName";
            cbbCategory.SelectedIndex = -1; //clear combobox
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            refreshGridView();
        }

        Category category = new Category();

        /*change*/
        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            category = (Category)cbbCategory.SelectedItem;
            if (category != null)
            {
                dataGridView1.DataSource = null;
                listBookInfors = CSDL_OOP.Instance.GetBookInforsByCategoryID_BLL(category.CategoryID);
                bookInfors = new BindingList<BookInfor>(listBookInfors);
                dataGridView1.DataSource = bookInfors;
            }

        }

        private int sortColumnIndex = -1;
        private ListSortDirection sortDirection = ListSortDirection.Ascending;

        /*change*/
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // If the same column header was clicked twice, reverse the sort direction
            if (e.ColumnIndex == sortColumnIndex)
            {
                sortDirection = sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            else // Otherwise, sort by the new column header
            {
                sortColumnIndex = e.ColumnIndex;
                sortDirection = ListSortDirection.Ascending;
            }

            // Sort the list using the appropriate property and sort direction
            string propertyName = dataGridView1.Columns[sortColumnIndex].DataPropertyName;
            PropertyInfo propInfo = typeof(BookInfor).GetProperty(propertyName);


            listBookInfors = listBookInfors = CSDL_OOP.Instance.GetBookInfor("");
            if (sortDirection == ListSortDirection.Ascending)
            {
                bookInfors = new BindingList<BookInfor>(listBookInfors.OrderBy(x => propInfo.GetValue(x, null)).ToList());
            }
            else
            {
                bookInfors = new BindingList<BookInfor>(listBookInfors.OrderByDescending(x => propInfo.GetValue(x, null)).ToList());
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bookInfors;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
    }
}
