using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
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
    public partial class Form_Supplier : Form
    {
        Supplier supplier = new Supplier();
        List<Supplier> suppliers = new List<Supplier>();
        public Form_Supplier()
        {
            InitializeComponent();
            suppliers = Supplier_BLL.Instance.GetSupplierInfor("");
            dataGridView1.DataSource = suppliers;
            vietnameseDatagridView();
            txtbID.Text = Supplier_BLL.Instance.getNextSupplierID_BLL().ToString();
        }
        public void refreshGridView()
        {
            txtbSearch.Text = "";
            dataGridView1.DataSource = null;
            suppliers = Supplier_BLL.Instance.GetSupplierInfor("");
            dataGridView1.DataSource = suppliers;
            vietnameseDatagridView();
            txtbName.Text = txtbAddress.Text = txtbPhoneNumber.Text = "";
            txtbID.Text = Supplier_BLL.Instance.getNextSupplierID_BLL().ToString();
            btnEdit.Text = "Sửa";
            btnAddSupplier.Text = "Thêm";
            lblAddSupplier.Text = "Thêm nhà cung cấp";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "";
            name = txtbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = suppliers = Supplier_BLL.Instance.GetSupplierInfor(name);
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

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if(txtbName.Text == "" || txtbPhoneNumber.Text == "" || txtbAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                supplier.SupplierName = txtbName.Text;
                supplier.PhoneNumber = txtbPhoneNumber.Text;
                supplier.Address = txtbAddress.Text;
                if(btnAddSupplier.Text == "Thêm")
                {
                    Supplier_BLL.Instance.AddSupplier_BLL(supplier);
                    MessageBox.Show("Bạn đã thêm thành công!");
                }
                else
                {
                    supplier.SupplierID = Convert.ToInt32(txtbID.Text);
                    Supplier_BLL.Instance.UpdateSupplier_BLL(supplier);
                    MessageBox.Show("Bạn đã sửa thành công!");
                }
                refreshGridView();
            }
        }

        public void vietnameseDatagridView()
        {
            DataGridViewColumn supplierID = dataGridView1.Columns["SupplierID"];
            supplierID.HeaderText = "Mã nhà cung";
            DataGridViewColumn supplierName = dataGridView1.Columns["SupplierName"];
            supplierName.HeaderText = "Tên";
            DataGridViewColumn phoneNumber = dataGridView1.Columns["PhoneNumber"];
            phoneNumber.HeaderText = "SĐT";
            DataGridViewColumn address = dataGridView1.Columns["Address"];
            address.HeaderText = "Địa chỉ";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            PropertyInfo propInfo = typeof(Supplier).GetProperty(propertyName);
            if (sortDirection == ListSortDirection.Ascending)
            {
                suppliers = suppliers.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                suppliers = suppliers.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = suppliers;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
            vietnameseDatagridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(btnEdit.Text == "Sửa")
            {
                if(dataGridView1.SelectedRows.Count > 0)
                {
                    foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                    {
                        txtbID.Text = (i.Cells["SupplierID"].Value).ToString();
                        txtbName.Text = (i.Cells["SupplierName"].Value).ToString();
                        txtbPhoneNumber.Text = (i.Cells["PhoneNumber"].Value).ToString();
                        txtbAddress.Text = (i.Cells["Address"].Value).ToString();
                    }
                    btnEdit.Text = "Reset";
                    btnAddSupplier.Text = "OK";
                    lblAddSupplier.Text = "Sửa nhà cung cấp";
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp để sửa!");
                }
            }
            else
            {
                txtbID.Text = Supplier_BLL.Instance.getNextSupplierID_BLL().ToString();
                txtbName.Text = txtbPhoneNumber.Text = txtbAddress.Text = "";
                btnEdit.Text = "Sửa";
                btnAddSupplier.Text = "Thêm";
                lblAddSupplier.Text = "Thêm nhà cung cấp";
            }
        }
    }
}
