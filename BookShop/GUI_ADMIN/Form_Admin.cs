using BookShop.BLL_ST;
using BookShop.Controls;
using BookShop.DTO;
using BookShop.GUI_Sale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.GUI_ADMIN
{
    public partial class Form_Admin : Form
    {
        static public Account accountAdmin = new Account();
        public Form_Admin()
        {
            InitializeComponent(); timer1.Start();
            accountAdmin = Account_BLL.Instance.getAccountByID(Account_BLL.Instance.UserID);
            lbUserName.Text = accountAdmin.UserName;
            lbRole.Text = accountAdmin.RoleName;
        }
        private void Move_Slide(int y)
        {
            panel_Slide.BackColor = Color.Blue;
            panel_Slide.Location = new Point(0, y);
        }
        private void Add_Control(Form form)
        {
            panel_Control.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            panel_Control.Controls.Add(form);
            form.Show();
        }
        private void but_Personal_Click(object sender, EventArgs e)
        {
            Move_Slide(btnManageAccount.Location.Y);
            Add_Control(new Form_ManageAccount(accountAdmin));
        }

        private void but_BookManage_Click(object sender, EventArgs e)
        {
            Move_Slide(btnManageBook.Location.Y);
            Add_Control(new Form_ManageBook());
        }

        private void but_CreateInvoice_Click(object sender, EventArgs e)
        {
            Move_Slide(btnViewImportInvoice.Location.Y);
            Add_Control(new Form_CreateImportInvoice());
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lbCurrentTime.Text = time.ToString("HH:mm:ss");
        }
        private void panel_Control_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnViewImportInvoice_Click(object sender, EventArgs e)
        {
            Move_Slide(btnViewImportInvoice.Location.Y);
            Add_Control(new Form_ViewImportInvoice());
        }
        private void btnViewSaledInvoice_Click(object sender, EventArgs e)
        {
            Move_Slide(btnViewSaledInvoice.Location.Y);
            Add_Control(new Form_ViewSaleInvoice());
        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            Move_Slide(btnManageCustomer.Location.Y);
            Add_Control(new Form_ManageCustomer());
        }

        private void btnManageRevenue_Click(object sender, EventArgs e)
        {
            Move_Slide(btnManageRevenue.Location.Y);
            Add_Control(new Form_ManageRevenue());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
