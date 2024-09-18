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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookShop.GUI
{
    public partial class Form_BookDetail : Form
    {
        Category category = new Category();
        List<Category> listCategory = new List<Category>();
        BookInfor originBookInfor;

        public Form_BookDetail(BookInfor bookInfor)
        {
            InitializeComponent();
            listCategory = Category_BLL.Instance.GetCategoryInfor("");
            cbbCategory.DataSource = listCategory;
            cbbCategory.DisplayMember = "CategoryName";

            pictureboxBookCover.SizeMode = PictureBoxSizeMode.Zoom;
            txtbBookInforID.ReadOnly = true;
            lockTxtb(true);
            originBookInfor = bookInfor;
            resetOrigin();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtbAuthor.Text == "") || (cbbCategory.SelectedIndex == -1) ||
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
                        MessageBox.Show("Bạn đã chỉnh sửa sách thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa sách không thành công");
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
                bookInfor.BookInforID = Convert.ToInt32(txtbBookInforID.Text.ToString());
                bookInfor.Cover = txtbPathPicture.Text;
                bookInfor.Title = txtbTitle.Text.ToString();
                /*bookInfor.CategoryID = category.CategoryID;
                bookInfor.Category = txtbCategory.Text.ToString();*/
                category = (Category)cbbCategory.SelectedItem;
                bookInfor.CategoryID = category.CategoryID;
                bookInfor.Category = cbbCategory.SelectedItem.ToString();
                bookInfor.Author = txtbAuthor.Text.ToString();
                bookInfor.Publisher = txtbPublisher.Text.ToString();
                bookInfor.Translator = txtbTranslator.Text.ToString();
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

        private void btnBrowsePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"D:\Picture_PBL_3\";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureboxBookCover.ImageLocation = openFileDialog1.FileName;
                txtbPathPicture.Text = openFileDialog1.FileName;
            }
        }

        public void lockTxtb(bool edit)
        {
            txtbTitle.ReadOnly = edit;
            txtbPublishYear.ReadOnly = edit;
            cbbCategory.Enabled = !edit;
            txtbAuthor.ReadOnly = edit;
            txtbPublisher.ReadOnly = edit;
            txtbTranslator.ReadOnly = edit;
            txtbSalePrice.ReadOnly = edit;
            txtbQuantity.ReadOnly = edit;
            txtbPathPicture.ReadOnly = edit;

            btnBrowsePicture.Enabled = !edit;
            btnManageCategory.Enabled = !edit;
        }

        public void resetOrigin()
        {
            txtbBookInforID.Text = Convert.ToString(originBookInfor.BookInforID);
            txtbTitle.Text = originBookInfor.Title;
            txtbPublishYear.Text = Convert.ToString(originBookInfor.PublishYear);

            int selectedIndex = -1;
            for (int i = 0; i < cbbCategory.Items.Count; i++)
            {
                if (((Category)cbbCategory.Items[i]).CategoryName == originBookInfor.Category)
                {
                    selectedIndex = i;
                    break;
                }
            }
            cbbCategory.SelectedIndex = selectedIndex;

            txtbAuthor.Text = originBookInfor.Author;
            txtbPublisher.Text = originBookInfor.Publisher;
            txtbTranslator.Text = originBookInfor.Translator;
            txtbSalePrice.Text = Convert.ToString(originBookInfor.SalePrice);
            txtbQuantity.Text = Convert.ToString(originBookInfor.Quantity);
            txtbPathPicture.Text = originBookInfor.Cover;
            pictureboxBookCover.ImageLocation = originBookInfor.Cover;

            category.CategoryID = originBookInfor.CategoryID;
            category.CategoryName = originBookInfor.Category;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                lockTxtb(false);
                btnEdit.Text = "Reset";
            }
            else if (btnEdit.Text == "Reset")
            {
                resetOrigin();
                lockTxtb(true);
                btnEdit.Text = "Edit";
            }
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            Form_ManageCategory form = new Form_ManageCategory();
            form.ShowDialog();
            listCategory = Category_BLL.Instance.GetCategoryInfor("");
            cbbCategory.DataSource = listCategory;
            cbbCategory.DisplayMember = "CategoryName";
            cbbCategory.SelectedIndex = -1; //clear combobox
        }
    }
}
