using BookShop.BLL;
using BookShop.Controls;
using BookShop.DTO;
using BookShop.GUI;
using BookShop.GUI_SALE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.GUI_ADMIN
{
    public partial class Form_ManageRevenue : Form
    {
        Account account = new Account();
        public Form_ManageRevenue()
        {
            InitializeComponent();
        }
        private void but_ChangeAccount_Click(object sender, EventArgs e)
        {
            Form_ChangePassword form = new Form_ChangePassword(account);
            form.ShowDialog();
        }



        private void label4_Click(object sender, EventArgs e)
        {
        }
        void Load_Data()
        {
            DateTime date_begin = dateTimePicker1.Value;
            DateTime date_end = dateTimePicker2.Value;
            DateTime temp = DateTime.Now;
            if (date_end > temp) { date_end = temp; }
            DateTime begin = new DateTime(date_begin.Year, date_begin.Month, date_begin.Day, 0, 0, 0);
            DateTime end = new DateTime(date_end.Year, date_end.Month, date_end.Day, 23, 59, 59);
            string b = begin.ToString("yyyy/MM/dd hh:mm:ss");
            string e = end.ToString("yyyy/MM/dd hh:mm:ss");
            if (begin > end)
            {
                MessageBox.Show("Khoảng ngày không hợp lí");
            }
            else
            {
                SqlConnection connection = new SqlConnection(Connect.constr);
                string query_Capital = "select Sum(Purchase) from ImportInvoice where  '" + b + "' <=ImportTime AND ImportTime<= '" + e + "'";
                string query_Revenue = "select Sum(Payment) from SaledInvoice where  '" + b + "' <=SaleTime AND SaleTime<= '" + e + "'";
                string query_Profit = "select Sum(Quantity*(SalePrice - ImportPrice)) from SaledBook inner join SaledInvoice on SaledBook.SaledInvoiceID = SaledInvoice.SaledInvoiceID where '" + b + "' <=SaleTime AND SaleTime<= '" + e + "'";
                string query_Total = "select Sum(Quantity) as quantity from SaledBook inner join SaledInvoice on SaledBook.SaledInvoiceID = SaledInvoice.SaledInvoiceID where '" + b + "' <=SaleTime AND SaleTime<= '" + e + "'";
                string query_data = "select BookInformation.BookInforID IDBook, BookInformation.Title Tensach,BookInformation.Quantity,Sum(SaledBook.Quantity) as Total_Quantity,Sum(SaledBook.Quantity*SaledBook.SalePrice) as Revenue, Sum(SaledBook.Quantity *(SaledBook.SalePrice - SaledBook.ImportPrice)) as Profit" +
                    " from SaledBook " +
                    " inner join BookInformation on SaledBook.BookInforID = BookInformation.BookInforID" +
                    " inner join SaledInvoice on SaledBook.SaledInvoiceID =  SaledInvoice.SaledInvoiceID" +
                    " where  '" + b + "' <=SaledInvoice.SaleTime and SaledInvoice.SaleTime<= '" + e + "'" +
                    " group by BookInformation.BookInforID, BookInformation.Title, BookInformation.Quantity" +
                    " order by Total_Quantity desc";
                connection.Open();

                SqlCommand cmd1 = new SqlCommand(query_Capital, connection);
                object result1 = cmd1.ExecuteScalar();
                if (result1 != DBNull.Value)
                {
                    txtbCapital.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(Convert.ToInt32(result1).ToString());
                }
                else
                {
                    txtbCapital.Text = "0";
                }

                SqlCommand cmd2 = new SqlCommand(query_Revenue, connection);
                object result2 = cmd2.ExecuteScalar();
                if (result2 != DBNull.Value)
                {
                    txtbRevenue.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(Convert.ToInt32(result2).ToString());
                }
                else
                {
                    txtbRevenue.Text = "0";
                }


                SqlCommand cmd3 = new SqlCommand(query_Profit, connection);
                object result3 = cmd3.ExecuteScalar();
                if (result2 != DBNull.Value)
                {
                    //txtbProfit.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(Convert.ToInt32(result3).ToString());
                    txtbProfit.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat((Convert.ToInt32(result2) - Convert.ToInt32(result1)).ToString());
                }
                else
                {
                    txtbProfit.Text = "0";
                }

                SqlCommand cmd4 = new SqlCommand(query_Total, connection);
                object result4 = cmd4.ExecuteScalar();
                if (result4 != DBNull.Value)
                {
                    txtbTotal.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(Convert.ToInt32(result4).ToString());
                }
                else
                {
                    txtbTotal.Text = "0";
                }

                SqlCommand cmd5 = new SqlCommand(query_data, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd5);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;


                connection.Close();
            }
            dataGridView1.Columns[0].HeaderText = "ID Book";
            dataGridView1.Columns[1].HeaderText = "Tên sách";
            dataGridView1.Columns[2].HeaderText = "Số lượng còn";
            dataGridView1.Columns[3].HeaderText = "Số lượng bán";
            dataGridView1.Columns[4].HeaderText = "Doanh thu";
            dataGridView1.Columns[5].HeaderText = "Tổng lợi nhuận";
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            Load_Data();
        }

        private void date_End(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void date_Begin(object sender, EventArgs e)
        {
            Load_Data();
        }
    }
}
