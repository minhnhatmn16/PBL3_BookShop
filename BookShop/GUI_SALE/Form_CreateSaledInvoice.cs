using BookShop.BLL;
using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI;
using BookShop.GUI_SALE;
using BookShop.GUI_ST;
using BookShop.InHoaDon;
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
    public partial class Form_CreateSaledInvoice : Form
    {
        List<SaledBook> saledBooks = new List<SaledBook>();
        SaledInvoice saledInvoice = new SaledInvoice();
        public Form_CreateSaledInvoice()
        {
            InitializeComponent();
            resetForm();
        }

        void refreshForm()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = saledBooks;
            if (!isRemoved)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Remove("ID");
                dataGridView1.Columns.Remove("ImportPrice");
                isRemoved = true;
            }
        }
        public void resetForm()
        {
            txtbPhoneNumber.ReadOnly = true;
            txtbTotal.ReadOnly = true;
            txtbTotalBook.ReadOnly = true;
            txtbUserID.Enabled = false;
            txtbUserName.Enabled = false;
            txtbSaledInvoiceID.Enabled = false;

            txtbCustomer.Text = "";
            txtbPhoneNumber.Text = "";
            dataGridView1.DataSource = null;
            txtbUserID.Text = Convert.ToString(Account_BLL.Instance.UserID);
            txtbUserName.Text = Convert.ToString(Account_BLL.Instance.GetAccountName(Account_BLL.Instance.UserID));
            txtbSaledInvoiceID.Text = Convert.ToString(SaledInvoice_BLL.Instance.getNextSaledInvoiceID_BLL());

            txtbTotalBook.Text = SaledInvoice_BLL.Instance.ConvertToMoneyFormat(TotalQuantity.ToString());
            txtbTotal.Text = SaledInvoice_BLL.Instance.ConvertToMoneyFormat(TotalAmount.ToString());
        }

        public int TotalQuantity = 0;
        public int TotalAmount = 0;
        bool isRemoved = false;
        private void btnSaledBook_Click(object sender, EventArgs e)
        {
            Form_AddSaledBook form = new Form_AddSaledBook();
            form.ShowDialog();

            foreach(SaledBook i in form.SaledBooks)
            {
                saledBooks.Add(i);
            }
            //saledBooks = form.SaledBooks;
            TotalQuantity += form.TotalQuantity;
            TotalAmount += form.TotalAmount;
            txtbTotalBook.Text = SaledInvoice_BLL.Instance.ConvertToMoneyFormat(TotalQuantity.ToString());
            txtbTotal.Text = SaledInvoice_BLL.Instance.ConvertToMoneyFormat(TotalAmount.ToString());

            if (saledBooks != null)
            {
                foreach (var i in saledBooks)
                {
                    i.SaledInvoiceID = Convert.ToInt32(txtbSaledInvoiceID.Text);
                }
                //add to datagridview

                refreshForm();
                vietnameseDatagridView();
            }
            btnSaledBook.Enabled = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int bookInforID = Convert.ToInt32(selectedRow.Cells["BookInforID"].Value);
            BookInfor bookInfor = BookInfor_BLL.Instance.getBookInforByID_BLL(bookInforID);
            Form_ViewDetailedBook formBookDetail = new Form_ViewDetailedBook(bookInfor);
            formBookDetail.ShowDialog();
        }

        public void vietnameseDatagridView()
        {
            DataGridViewColumn SaledBookID = dataGridView1.Columns["SaledInvoiceID"];
            SaledBookID.HeaderText = "Mã hóa đơn bán sách";
            DataGridViewColumn bookInforID = dataGridView1.Columns["BookInforID"];
            bookInforID.HeaderText = "Mã thông tin sách";
            DataGridViewColumn Title = dataGridView1.Columns["Title"];
            Title.HeaderText = "Tên sách";
            DataGridViewColumn SaledPrice = dataGridView1.Columns["SaledPrice"];
            SaledPrice.HeaderText = "Giá bán";
            DataGridViewColumn PublishYear = dataGridView1.Columns["Quantity"];
            PublishYear.HeaderText = "Số lượng";
            DataGridViewColumn TotalAmount = dataGridView1.Columns["TotalAmount"];
            TotalAmount.HeaderText = "Tổng giá";

        }

        public void CreateSaledInvoice()
        {
            DateTime dateTimeValue = DateTime.Now;
            saledInvoice.SaledTime = dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss");
            saledInvoice.SaledInvoiceID = Convert.ToInt32(txtbSaledInvoiceID.Text);

            //supplier = (Supplier)cbbSupplier.SelectedItem;
            saledInvoice.CustomerID = choosenCustomer.CustomerID;
            saledInvoice.Payment = Convert.ToDouble(txtbTotal.Text);
            saledInvoice.StaffID = Convert.ToInt32(txtbUserID.Text);

            SaledInvoice_BLL.Instance.AddSaledInvoice_BLL(saledInvoice);
        }

        private void btnCreateSaledInvoice_Click(object sender, EventArgs e)
        {
            if (txtbCustomer.Text == "" || saledBooks.Count == 0)
            {
                MessageBox.Show("Xin nhập đầy đủ thông tin!");
            }
            else
            {
                DialogResult dialogResult1 = MessageBox.Show("Xác nhận tạo hóa đơn!", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    CreateSaledInvoice();
                    foreach (var obj in saledBooks)
                    {
                        if (SaledBook_BLL.Instance.ExecuteAddOrUpdate_BLL(obj))
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

                    string s1 = txtbCustomer.Text;
                    string s2 = txtbPhoneNumber.Text;
                    string s3 = txtbUserID.Text;
                    string s4 = txtbUserName.Text;
                    string s5 = txtbTotalBook.Text;
                    string s6 = txtbTotal.Text;
                    Report_Sale f = new Report_Sale(saledInvoice.SaledInvoiceID, s1, s2, s3, s4, s5, s6);
                    f.ShowDialog();





                    MessageBox.Show("Tạo hóa đơn thành công!");
                    TotalQuantity = 0;
                    TotalAmount = 0;
                    saledBooks.Clear();
                    dataGridView1.DataSource = null;
                }
                else
                {
                    return;
                }

            }
        }
        Customer choosenCustomer = new Customer();
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Form_AddCustomer form = new Form_AddCustomer();
            form.ShowDialog();
            choosenCustomer = form.choosenCustomer;
            if(choosenCustomer != null)
            {
                txtbCustomer.Text = choosenCustomer.CustomerName;
                txtbPhoneNumber.Text = choosenCustomer.PhoneNumber;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            DialogResult dialogResult1 = MessageBox.Show("Xác nhận xóa sách trong hóa đơn!", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes && idx >= 0)
            {
                SaledBook Temp = saledBooks[idx];
                saledBooks.RemoveAt(idx);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = saledBooks;

                TotalQuantity -= Temp.Quantity;
                TotalAmount -= (int)Temp.TotalAmount;
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
            PropertyInfo propInfo = typeof(SaledBook).GetProperty(propertyName);
            if (sortDirection == ListSortDirection.Ascending)
            {
                saledBooks = saledBooks.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                saledBooks = saledBooks.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = saledBooks;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
