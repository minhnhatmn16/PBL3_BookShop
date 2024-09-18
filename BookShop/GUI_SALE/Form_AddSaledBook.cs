using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI;
using BookShop.GUI_SALE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.GUI_Sale
{
    public partial class Form_AddSaledBook : Form
    {
        //int numberProperty = 11;
        List<BookInfor> bookInfors = new List<BookInfor>(); //save all property of bookInfor. bcuz when we double click on a row
        public List<SaledBook> SaledBooks;
        public int TotalQuantity = 0;
        public int TotalAmount = 0;
        public Form_AddSaledBook()
        {
            InitializeComponent();
            SaledBooks = new List<SaledBook>();

            dataGridView1.DataSource = CSDL_OOP.Instance.GetBookInfor("");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Remove("CategoryID"); //remove the property that not necessary when display to viewer
            dataGridView1.Columns.Remove("Cover"); //remove the property that not necessary when display to viewer

            txtbPriceUnit.Enabled = false;
            txtbTotalUnit.Enabled = false;
            txtbTotal.Enabled = false;
            txtbTotalBook.Enabled = false;

            txtbTotal.Text = txtbTotalBook.Text = "0";

            vietnameseDatagridView();
            refreshGridView();
        }
        public void refreshGridView()
        {
            dataGridView1.DataSource = null;
            bookInfors = CSDL_OOP.Instance.GetBookInfor("");
            dataGridView1.DataSource = bookInfors;

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            Form_ViewDetailedBook formBookDetail = new Form_ViewDetailedBook(bookInfors[idx]);
            formBookDetail.ShowDialog();
            refreshGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "";
            name = txtbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL_OOP.Instance.GetBookInfor(name);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Form_AddBookPic test = new Form_AddBookPic();
            test.ShowDialog();
            //refresh after add book
            refreshGridView();
        }


        SaledBook tempSaledBook; //use for add to list invoice
        List<int> listID = new List<int>();
        int rowIndex = -1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the row index of the clicked cell
            rowIndex = e.RowIndex;

            // Make sure that the row index is valid
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                // Get the values of each column in the row

                tempSaledBook = new SaledBook();
                txtbQuantityUnit.Text = "";
                txtbPriceUnit.Text = "";
                txtbTotalUnit.Text = "";

                SaledBook temp = SaledBooks.FirstOrDefault(x => x.BookInforID == Convert.ToInt32(row.Cells["BookInforID"].Value)); //use for save data then display to gui
                if (temp == null)
                {
                    temp = new SaledBook();
                    temp.Quantity = 0;
                    txtbQuantityUnit.ReadOnly = false;
                    tempSaledBook.BookInforID = Convert.ToInt32(row.Cells["BookInforID"].Value);
                    /*lbAddSaledBook.Text = "Thêm sách vào hóa đơn";
                    btnAddBookToInvoice.Text = "+";*/
                }
                else
                {
                    txtbQuantityUnit.ReadOnly = true;
                    tempSaledBook.BookInforID = Convert.ToInt32(row.Cells["BookInforID"].Value);
                    /*lbAddSaledBook.Text = "Sửa thông tin sách";
                    btnAddBookToInvoice.Text = "edit";*/
                }
                temp.BookInforID = bookInfors[row.Index].BookInforID;
                temp.SaledPrice = bookInfors[row.Index].SalePrice;
                takeDataToText(temp);

                // Do something with the values

            }
        }

        public void takeDataToText(SaledBook temp)
        {
            txtbPriceUnit.Text = Convert.ToString(temp.SaledPrice);
            if (temp.Quantity > 0)
            {
                txtbQuantityUnit.Text = Convert.ToString(temp.Quantity);
            }
            txtbTotalUnit.Text = Convert.ToString(temp.SaledPrice * temp.Quantity);
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

        private void btnX_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtbTotalBook.Text) > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Dữ liệu sẽ bị hủy, Bạn có chắc muốn thoát", "Xác nhận thoát", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    SaledBooks = null;
                    TotalQuantity = 0;
                    TotalAmount = 0;
                }
                else
                {
                    return;
                }
            }
            this.Dispose();
        }

        private void txtbQuantityUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtbQuantityUnit.Text != "")
                {
                    if (tempSaledBook == null) throw new Exception("Hãy chọn 1 sách để nhập thông tin");
                    tempSaledBook.Quantity = Convert.ToInt32(txtbQuantityUnit.Text);
                    tempSaledBook.SaledPrice = Convert.ToInt32(txtbPriceUnit.Text);
                    if (tempSaledBook.Quantity <= 0)
                    {
                        throw new Exception("Số lượng phải lớn hơn 0");
                    }
                    foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    {
                        if (tempSaledBook.Quantity > Convert.ToInt32(i.Cells["Quantity"].Value))
                        {
                            throw new Exception("Số lượng sách thêm vượt quá số lượng trong kho!");
                        }
                    }
                    txtbTotalUnit.Text = Convert.ToString(tempSaledBook.Quantity * tempSaledBook.SaledPrice);
                }
                else
                {
                    txtbTotalUnit.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtbQuantityUnit.Text = "";
            }
        }

        private void btnAddBookToInvoice_Click(object sender, EventArgs e)
        {
            if (txtbPriceUnit.Text != "" && txtbTotalUnit.Text != "" && txtbQuantityUnit.Text != "")
            {
                SaledBook temp = new SaledBook();
                temp = null;
                if (SaledBooks != null)
                {
                    temp = SaledBooks.FirstOrDefault(x => x.BookInforID == tempSaledBook.BookInforID);
                }
                if (temp == null)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn Thêm vào hóa đơn bán hàng", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        tempSaledBook.ID = tempSaledBook.SaledInvoiceID = 0;
                        SaledBooks.Add(tempSaledBook);
                        txtbTotalBook.Text = Convert.ToString(Convert.ToInt32(txtbTotalBook.Text) + tempSaledBook.Quantity);
                        txtbTotal.Text = Convert.ToString(Convert.ToDouble(txtbTotal.Text) + Convert.ToDouble(txtbTotalUnit.Text));

                        TotalQuantity = Convert.ToInt32(txtbTotalBook.Text);
                        TotalAmount = Convert.ToInt32(txtbTotal.Text);
                        colorRow = rowIndex;
                    }
                }
                else //update
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn chỉnh sửa sách nhập kho", "Xác nhận thêm", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int editQuantity = Convert.ToInt32(txtbQuantityUnit.Text) - temp.Quantity;
                        double editPrice = Convert.ToDouble(txtbPriceUnit.Text) * Convert.ToInt32(txtbQuantityUnit.Text) - temp.SaledPrice * temp.Quantity;
                        temp.Quantity = Convert.ToInt32(txtbQuantityUnit.Text);
                        temp.SaledPrice = Convert.ToDouble(txtbPriceUnit.Text);

                        txtbTotalBook.Text = Convert.ToString(Convert.ToInt32(txtbTotalBook.Text) + editQuantity);
                        txtbTotal.Text = Convert.ToString(Convert.ToDouble(txtbTotal.Text) + editPrice);
                    }
                }
            }
            else
            {
                MessageBox.Show("Xin hãy điền đầy đủ thông tin!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Dữ liệu sẽ bị hủy, Bạn có chắc muốn reset!", "Xác nhận reset", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (SaledBooks != null)
                {
                    SaledBooks.Clear();
                }
                txtbQuantityUnit.Text = txtbPriceUnit.Text = txtbTotalUnit.Text = "";
                txtbTotal.Text = "0";
                txtbTotalBook.Text = "0";
                TotalAmount = TotalQuantity = 0;
                colorRow = -2;
                refreshGridView();
            }
                
        }

        int colorRow = -1;
        List<int> coloredRow = new List<int>();
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Set the background color of the row based on some condition
            if (colorRow >= 0)
            {
                dataGridView1.Rows[colorRow].DefaultCellStyle.BackColor = Color.LightBlue;
            }
            if (colorRow == -2)
            {
                for (int i = 0; i < coloredRow.Count; i++)
                {
                    dataGridView1.Rows[coloredRow[i]].DefaultCellStyle.BackColor = Color.White;
                }
                coloredRow.Clear();
            }
        }

        private int sortColumnIndex = -1;
        private ListSortDirection sortDirection = ListSortDirection.Ascending;
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
            if (sortDirection == ListSortDirection.Ascending)
            {
                bookInfors = bookInfors.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                bookInfors = bookInfors.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bookInfors;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
