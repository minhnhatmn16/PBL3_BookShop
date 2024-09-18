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

namespace BookShop.GUI_SALE
{
    public partial class Form_ViewDetailedBook : Form
    {
        Category category = new Category();
        List<Category> listCategory = new List<Category>();
        BookInfor originBookInfor;
        public Form_ViewDetailedBook(BookInfor bookInfor)
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

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
            pictureboxBookCover.ImageLocation = originBookInfor.Cover;

            category.CategoryID = originBookInfor.CategoryID;
            category.CategoryName = originBookInfor.Category;
        }
    }
}
