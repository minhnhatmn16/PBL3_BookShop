using BookShop.BLL;
using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI;
using BookShop.GUI_ST;
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

namespace BookShop.Controls
{
    public partial class Form_ViewImportInvoice : Form
    {
        List<ImportInvoice> listImportInvoice = new List<ImportInvoice>();
        bool initiateDate = true;
        public Form_ViewImportInvoice()
        {
            InitializeComponent();
            listImportInvoice = ImportInvoice_BLL.Instance.GetImportInvoiceInfor("");
            dataGridView1.DataSource = listImportInvoice;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Remove("SupplierID");
            dataGridView1.Columns.Remove("StaffID");
            vietnameseDatagridView();
            initiateDate = false;
        }
        
        public void refreshGridView()
        {
            txtbSearch.Text = "";
            listImportInvoice = ImportInvoice_BLL.Instance.GetImportInvoiceInfor("");
            dataGridView1.DataSource = listImportInvoice;
            initiateDate = true;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value= DateTime.Now;
            initiateDate = false;
        }
        public void vietnameseDatagridView()
        {
            DataGridViewColumn importInvoiceID = dataGridView1.Columns["ImportInvoiceID"];
            importInvoiceID.HeaderText = "Mã hóa đơn";
            DataGridViewColumn importTime = dataGridView1.Columns["ImportTime"];
            importTime.HeaderText = "Thời gian";
            DataGridViewColumn supplierName = dataGridView1.Columns["SupplierName"];
            supplierName.HeaderText = "Nhà cung cấp";
            DataGridViewColumn staffName = dataGridView1.Columns["StaffName"];
            staffName.HeaderText = "Nhân viên";
            DataGridViewColumn purchase = dataGridView1.Columns["Purchase"];
            purchase.HeaderText = "Tổng trả";
            DataGridViewColumn numberOfBook = dataGridView1.Columns["NumberOfBook"];
            numberOfBook.HeaderText = "Tổng sách";
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int importInvoiceID = Convert.ToInt32(selectedRow.Cells["ImportInvoiceID"].Value);
            ImportInvoice importInvoice = ImportInvoice_BLL.Instance.getImportInvoiceByID_BLL(importInvoiceID);
            Form_DetailImportInvoice formDetailImportInvoice = new Form_DetailImportInvoice(importInvoice);
            formDetailImportInvoice.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            refreshGridView();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (initiateDate) return;
            if(dateTimePicker1.Value != dateTimePicker2.Value)
            {
                listImportInvoice = ImportInvoice_BLL.Instance.GetImportInvoiceByInterval(dateTimePicker1.Value, dateTimePicker2.Value);
                dataGridView1.DataSource = listImportInvoice;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (initiateDate) return;
            if (dateTimePicker1.Value != dateTimePicker2.Value)
            {
                listImportInvoice = ImportInvoice_BLL.Instance.GetImportInvoiceByInterval(dateTimePicker1.Value, dateTimePicker2.Value);
                dataGridView1.DataSource = listImportInvoice;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "";
            name = txtbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ImportInvoice_BLL.Instance.GetImportInvoiceInfor(name);
        }

        private void txtbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }

        private void txtbSearch_TextChanged(object sender, EventArgs e)
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
            PropertyInfo propInfo = typeof(ImportInvoice).GetProperty(propertyName);
            if (sortDirection == ListSortDirection.Ascending)
            {
                listImportInvoice = listImportInvoice.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                listImportInvoice = listImportInvoice.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listImportInvoice;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

        }

        private void Load_Data(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(2000, 1, 1, 0, 0, 0); 
        }
    }
}
