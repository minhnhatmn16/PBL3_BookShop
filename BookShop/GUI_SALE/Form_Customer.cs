using BookShop.BLL;
using BookShop.DTO;
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
    public partial class Form_Customer : Form
    {
        public Customer customer;
        public Form_Customer()
        {
            InitializeComponent();
            txtbID.Text = Convert.ToString(Customer_BLL.Instance.getNextCustomerID_BLL());
            cbbSex.Items.Add(Gender.ID[1]);
            cbbSex.Items.Add(Gender.ID[2]);
            cbbSex.Items.Add(Gender.ID[3]);
            cbbSex.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            customer = new Customer();
            try
            {
                if(txtbName.Text == "" || txtbPhoneNmber.Text == "" || cbbSex.SelectedIndex < 0)
                {
                    throw new Exception("Xin Nhập đầy đủ thông tin!");
                }
                customer.CustomerID = Convert.ToInt32(txtbID.Text);
                customer.CustomerName = Convert.ToString(txtbName.Text);
                customer.SexID = cbbSex.SelectedIndex+1;
                customer.PhoneNumber = Convert.ToString(txtbPhoneNmber.Text);
                Customer_BLL.Instance.AddCustomer_BLL(customer);
                MessageBox.Show("Đã thêm khách hàng thành công!");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi! Vui lòng kiểm tra lại định dạng nhập: " + ex.Message);
                customer = null;
            }
        }
    }
}
