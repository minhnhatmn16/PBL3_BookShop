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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.GUI_ST
{
    public partial class Form_AddImportBook : Form
    {
        //int numberProperty = 11;
        List<BookInfor> bookInfors = new List<BookInfor>(); //save all property of bookInfor. bcuz when we double click on a row
                                                            //we need to pass all property and the datagridview just display some necessary infor to
                                                            //viewer.
        public List<ImportBook> importBooks;
        public int TotalQuantity = 0;
        public int TotalAmount = 0;
        public Form_AddImportBook()
        {
            InitializeComponent();
            importBooks = new List<ImportBook>();

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
            Form_BookDetail formBookDetail = new Form_BookDetail(bookInfors[idx]);
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

        
        ImportBook tempImportBook;
        List<int> listID = new List<int>();
        int rowIndex = -1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the row index of the clicked cell
            rowIndex = e.RowIndex;

            // Make sure that the row index is valid
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                tempImportBook = new ImportBook();
                txtbQuantityUnit.Text = "";
                txtbPriceUnit.Text = "";
                txtbTotalUnit.Text = "";
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // Get the values of each column in the row
                ImportBook temp = importBooks.FirstOrDefault(x => x.BookInforID == Convert.ToInt32(row.Cells["BookInforID"].Value));
                if (temp == null)
                {
                    tempImportBook.BookInforID = Convert.ToInt32(row.Cells["BookInforID"].Value);
                    lbAddImportBook.Text = "Thêm sách vào hóa đơn";
                    btnAddBookToInvoice.Text = "+";
                }
                else
                {
                    tempImportBook.BookInforID = Convert.ToInt32(row.Cells["BookInforID"].Value);
                    takeDataToText(temp);
                    lbAddImportBook.Text = "Sửa thông tin sách nhập";
                    btnAddBookToInvoice.Text = "edit";
                }
                


                // Do something with the values

            }
        }

        public void takeDataToText(ImportBook temp)
        {
            txtbPriceUnit.Text = Convert.ToString(temp.ImportPrice);
            txtbQuantityUnit.Text = Convert.ToString(temp.Quantity);
            txtbTotalUnit.Text = Convert.ToString(temp.ImportPrice * temp.Quantity);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            Form_BookDetail formBookDetail = new Form_BookDetail(bookInfors[idx]);
            formBookDetail.ShowDialog();
            refreshGridView();
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
            if (Convert.ToInt32(txtbTotalBook.Text) > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Dữ liệu sẽ bị hủy, Bạn có chắc muốn thoát", "Xác nhận thoát", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    importBooks = null;
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

        private void txtbTotalUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtbTotalUnit.Enabled == false)
                {
                    return;
                }
                if (txtbTotalUnit.Text != "")
                {
                    if (Convert.ToDouble(txtbTotalUnit.Text) < 0)
                    {
                        throw new Exception("Giá phải lớn hơn hoặc bằng 0");
                    }
                    txtbPriceUnit.Enabled = false;
                    txtbPriceUnit.Text = Convert.ToString(Convert.ToDouble(txtbTotalUnit.Text) / tempImportBook.Quantity);
                    tempImportBook.ImportPrice = Convert.ToDouble(txtbPriceUnit.Text);
                }
                else
                {
                    txtbPriceUnit.Text = "";
                    txtbPriceUnit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtbTotalUnit.Text = "";
            }
            
        }

        private void txtbPriceUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtbPriceUnit.Enabled == false)
                {
                    return;
                }
                if (txtbPriceUnit.Text != "")
                {
                    if(Convert.ToDouble(txtbPriceUnit.Text) < 0)
                    {
                        throw new Exception("Giá phải lớn hơn hoặc bằng 0");
                    }
                    txtbTotalUnit.Enabled = false;
                    tempImportBook.ImportPrice = Convert.ToDouble(txtbPriceUnit.Text);
                    txtbTotalUnit.Text = Convert.ToString(tempImportBook.Quantity * tempImportBook.ImportPrice);

                    //MessageBox.Show(Convert.ToString(tempImportBook.ImportPrice));
                }
                else
                {
                    txtbTotalUnit.Text = "";
                    txtbTotalUnit.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtbPriceUnit.Text = "";
            }
            
        }

        private void txtbQuantityUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtbQuantityUnit.Text != "")
                {
                    if (tempImportBook == null) throw new Exception("Hãy chọn 1 sách để nhập thông tin");
                    tempImportBook.Quantity = Convert.ToInt32(txtbQuantityUnit.Text);
                    if(tempImportBook.Quantity <= 0)
                    {
                        throw new Exception("Số lượng phải lớn hơn 0");
                    }
                    
                    txtbPriceUnit.Enabled = true;
                    txtbTotalUnit.Enabled = true;
                }
                else
                {
                    txtbPriceUnit.Text = txtbTotalUnit.Text = "";
                    txtbPriceUnit.Enabled = false;
                    txtbTotalUnit.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtbQuantityUnit.Text = "";
            }
            
            
        }

        private void btnAddBookToInvoice_Click(object sender, EventArgs e)
        {
            if (txtbPriceUnit.Text != "" && txtbTotalUnit.Text != "" && txtbQuantityUnit.Text != "")
            {
                ImportBook temp = new ImportBook();
                temp = null;
                if (importBooks != null)
                {
                    temp = importBooks.FirstOrDefault(x => x.BookInforID == tempImportBook.BookInforID);
                }
                if (temp == null)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn Thêm vào hóa đơn nhập kho", "Xác nhận thêm", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        tempImportBook.ID = tempImportBook.ImportInvoiceID = 0;
                        importBooks.Add(tempImportBook);
                        txtbTotalBook.Text = Convert.ToString(Convert.ToInt32(txtbTotalBook.Text) + tempImportBook.Quantity);
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
                        double editPrice = Convert.ToDouble(txtbPriceUnit.Text) * Convert.ToInt32(txtbQuantityUnit.Text) - temp.ImportPrice * temp.Quantity;
                        temp.Quantity = Convert.ToInt32(txtbQuantityUnit.Text);
                        temp.ImportPrice = Convert.ToDouble(txtbPriceUnit.Text);

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
            if(dialogResult == DialogResult.Yes)
            {
                if (importBooks != null)
                {
                    importBooks.Clear();
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
                coloredRow.Add(colorRow);
                dataGridView1.Rows[colorRow].DefaultCellStyle.BackColor = Color.LightBlue;
            }
            if (colorRow == -2)
            {
                for(int i = 0; i < coloredRow.Count; i++)
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
