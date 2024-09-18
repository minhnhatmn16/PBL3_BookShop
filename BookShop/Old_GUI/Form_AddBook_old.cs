using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
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
    public partial class Form_AddBook_old : Form
    {
        String gridContent = "";
        Category category;
        public Form_AddBook_old()
        {
            InitializeComponent();
        }

/*        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (gridContent == "Category")
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    txtbCategory.Text = selectedRow.Cells[1].Value.ToString();
                    category.CategoryID = Convert.ToInt32(selectedRow.Cells[0].Value);
                    category.CategoryName = txtbCategory.Text;
                }
            }
        }*/

        /*private void btnFindCategory_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Category_BLL.Instance.GetCategoryInfor("");
            gridContent = "Category";
        }*/

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtbBookInforID.Text == "") || (txtbAuthor.Text == "") || (txtbCategory.Text == "") ||
                (txtbPublisher.Text == "") || (txtbQuantity.Text == "") || (txtbSalePrice.Text == "") ||
                (txtbTitle.Text == "") || (txtbPublishYear.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if (GetBookInforFromTxtb() != null)
                {
                    //execute add new book
                    if (BookInfor_BLL.Instance.ExecuteAddOrUpdate_BLL(GetBookInforFromTxtb()))
                    {
                        MessageBox.Show("Bạn đã thêm sách thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm sách không thành công");
                    }
                    //d("", "All", "All");
                    this.Close();
                }
            }
        }

        private BookInfor GetBookInforFromTxtb()
        {
            try
            {
                BookInfor bookInfor = new BookInfor();
                if (txtbBookInforID.Text != "") //if specify ID then take that infor (should check if that id has match any current id)
                {
                    bookInfor.BookInforID = Convert.ToInt32(txtbBookInforID.Text.ToString());
                }
                bookInfor.Title = txtbTitle.Text.ToString();
                bookInfor.CategoryID = category.CategoryID;
                bookInfor.Category = txtbCategory.Text.ToString();
                bookInfor.Author = txtbAuthor.Text.ToString();
                bookInfor.Publisher = txtbPublisher.Text.ToString();
                bookInfor.PublishYear = Convert.ToInt32(txtbPublishYear.Text.ToString());
                bookInfor.Quantity = Convert.ToInt32(txtbQuantity.Text.ToString());
                bookInfor.SalePrice = Convert.ToInt32(txtbSalePrice.Text.ToString());

                return bookInfor;
            }
            catch (Exception e)
            {
                MessageBox.Show("entered wrong format!! Error " + e.Message);
                return null;
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lbAddBookInfor_Click(object sender, EventArgs e)
        {

        }
    }
}
