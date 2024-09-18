using BookShop.BLL;
using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI;
using BookShop.GUI_ST;
using BookShop.InHoaDon;
using BookShop.Storekeeper;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookShop.Controls
{
    public partial class Form_CreateImportInvoice : Form
    {
        Supplier supplier = new Supplier();
        List<Supplier> listSupplier = new List<Supplier>();
        List<ImportBook> importBooks = new List<ImportBook>();
        ImportInvoice importInvoice = new ImportInvoice();
        DateTime dateTimeValue = DateTime.Now;
        public Form_CreateImportInvoice()
        {
            InitializeComponent();
            resetForm();
            txtbTime.Text = dateTimeValue.ToString();
        }

        void refreshForm()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = importBooks;
            if (!isRemoved)
            {
                dataGridView1.DataSource = importBooks;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Remove("ID");
                isRemoved = true;
            }
        }

        public void resetForm()
        {
            listSupplier = Supplier_BLL.Instance.GetSupplierInfor("");
            cbbSupplier.DataSource = listSupplier;
            cbbSupplier.DisplayMember = "SupplierName";
            cbbSupplier.SelectedIndex = -1; //clear combobox

            txtbAddress.ReadOnly = true;
            txtbPhoneNumber.ReadOnly = true;
            txtbTotal.ReadOnly = true;
            txtbTotalBook.ReadOnly = true;
            txtbUserID.Enabled = false;
            txtbUserName.Enabled = false;
            txtbImportInvoiceID.Enabled = false;

            txtbPhoneNumber.Text = "";
            txtbAddress.Text = "";
            txtbUserID.Text = Convert.ToString(Account_BLL.Instance.UserID);
            txtbUserName.Text = Convert.ToString(Account_BLL.Instance.GetAccountName(Account_BLL.Instance.UserID));
            txtbImportInvoiceID.Text = Convert.ToString(ImportInvoice_BLL.Instance.getNextImportInvoiceID_BLL());

            txtbTotalBook.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(TotalQuantity.ToString());
            txtbTotal.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(TotalAmount.ToString());
        }

        public int TotalQuantity = 0;
        public int TotalAmount = 0;
        bool isRemoved = false;
        private void but_ImportBook_Click(object sender, EventArgs e)
        {
            Form_AddImportBook form = new Form_AddImportBook();
            form.ShowDialog();

            foreach (ImportBook i in form.importBooks)
            {
                importBooks.Add(i);
            }

            TotalQuantity += form.TotalQuantity;
            TotalAmount += form.TotalAmount;
            txtbTotalBook.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(TotalQuantity.ToString());
            txtbTotal.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(TotalAmount.ToString());

            if (importBooks != null)
            {
                foreach(var i in importBooks)
                {
                    i.ImportInvoiceID = Convert.ToInt32(txtbImportInvoiceID.Text);
                }
                refreshForm();

                vietnameseDatagridView();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int bookInforID = Convert.ToInt32(selectedRow.Cells["BookInforID"].Value);
            BookInfor bookInfor = BookInfor_BLL.Instance.getBookInforByID_BLL(bookInforID);
            Form_BookDetail formBookDetail = new Form_BookDetail(bookInfor);
            formBookDetail.ShowDialog();
        }

        private void cbbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbSupplier.SelectedIndex != -1)
            {
                string selectedItem = cbbSupplier.SelectedItem.ToString();
                supplier = (Supplier)cbbSupplier.SelectedItem;
                txtbPhoneNumber.Text = Convert.ToString(supplier.PhoneNumber);
                txtbAddress.Text = Convert.ToString(supplier.Address);
                // Do something with the selected item
                Console.WriteLine("Selected item: " + selectedItem);
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void vietnameseDatagridView()
        {
            DataGridViewColumn ImportInvoiceID = dataGridView1.Columns["ImportInvoiceID"];
            ImportInvoiceID.HeaderText = "Mã hóa đơn nhập sách";
            DataGridViewColumn bookInforID = dataGridView1.Columns["bookInforID"];
            bookInforID.HeaderText = "Mã thông tin sách";
            DataGridViewColumn Title = dataGridView1.Columns["Title"];
            Title.HeaderText = "Tên sách";
            DataGridViewColumn ImportPrice = dataGridView1.Columns["ImportPrice"];
            ImportPrice.HeaderText = "Giá nhập";
            DataGridViewColumn PublishYear = dataGridView1.Columns["Quantity"];
            PublishYear.HeaderText = "Số lượng";
            
        }

        public void CreateImportInvoice()
        {
            importInvoice.ImportTime = dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss");
            importInvoice.ImportInvoiceID = Convert.ToInt32(txtbImportInvoiceID.Text);

            supplier = (Supplier)cbbSupplier.SelectedItem;
            importInvoice.SupplierID = supplier.SupplierID;
            importInvoice.Purchase = Convert.ToDouble(txtbTotal.Text);
            importInvoice.StaffID = Convert.ToInt32(txtbUserID.Text);

            ImportInvoice_BLL.Instance.AddImportInvoice_BLL(importInvoice);
        }

        private void btnCreateImportInvoice_Click(object sender, EventArgs e)
        {
            if(cbbSupplier.SelectedIndex == -1 || importBooks.Count == 0)
            {
                MessageBox.Show("Xin nhập đầy đủ thông tin!");
            }
            else
            {
                DialogResult dialogResult1 = MessageBox.Show("Xác nhận tạo hóa đơn!", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    CreateImportInvoice();
                    foreach (var obj in importBooks)
                    {
                        if (ImportBook_BLL.Instance.ExecuteAddOrUpdate_BLL(obj))
                        {
                            continue;
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Sách '" + obj.Title + "' không thêm vào được hóa đơn! Bạn có muốn tiếp tục thêm sách", "Lỗi thêm sách", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                continue;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    Report_Import f = new Report_Import(importInvoice.ImportInvoiceID, cbbSupplier.Text, txtbPhoneNumber.Text, txtbAddress.Text, txtbTotalBook.Text, txtbTotal.Text, txtbUserID.Text, txtbUserName.Text);
                    f.ShowDialog();

                    MessageBox.Show("Tạo hóa đơn thành công!");
                    TotalQuantity = 0;
                    TotalAmount = 0;
                    importBooks.Clear();
                    dataGridView1.DataSource = null;
                }
                else
                {
                    return;
                }
                    
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Form_Supplier form = new Form_Supplier();
            form.ShowDialog();
            listSupplier = Supplier_BLL.Instance.GetSupplierInfor("");
            cbbSupplier.DataSource = listSupplier;
            cbbSupplier.DisplayMember = "SupplierName";
            cbbSupplier.SelectedIndex = -1; //clear combobox
            txtbAddress.Text = txtbPhoneNumber.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            DialogResult dialogResult1 = MessageBox.Show("Xác nhận xóa sách trong hóa đơn!", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes && idx >= 0)
            {
                ImportBook Temp = importBooks[idx];
                importBooks.RemoveAt(idx);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = importBooks;

                TotalQuantity -= Temp.Quantity;
                TotalAmount -= (int)Temp.ImportPrice * Temp.Quantity;
                txtbTotalBook.Text = TotalQuantity.ToString();
                txtbTotal.Text = TotalAmount.ToString();
            }
            else
            {
                return;
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
            PropertyInfo propInfo = typeof(ImportBook).GetProperty(propertyName);
            if (sortDirection == ListSortDirection.Ascending)
            {
                importBooks = importBooks.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                importBooks = importBooks.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = importBooks;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

        }
    }
}
