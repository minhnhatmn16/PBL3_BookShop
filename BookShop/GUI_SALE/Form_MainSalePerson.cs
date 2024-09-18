using BookShop.BLL_ST;
using BookShop.Controls;
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

namespace BookShop.GUI_Sale
{
    public partial class Form_MainSalePerson : Form
    {
        static public Account accountSalePerson = new Account();
        public Form_MainSalePerson()
        {
            InitializeComponent();
            timer1.Start();
            accountSalePerson = Account_BLL.Instance.getAccountByID(Account_BLL.Instance.UserID);
            lbUserName.Text = accountSalePerson.UserName;
            lbRole.Text = accountSalePerson.RoleName;
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

        private void but_BookManage_Click(object sender, EventArgs e)
        {
            Move_Slide(btnFindBook.Location.Y);
            Add_Control(new Form_FindBook());
        }

        private void but_CreateInvoice_Click(object sender, EventArgs e)
        {
            Move_Slide(btnCreateSaleInvoice.Location.Y);
            Add_Control(new Form_CreateSaledInvoice());
        }

        private void but_ViewInvoice_Click(object sender, EventArgs e)
        {
            Move_Slide(but_ViewInvoice.Location.Y);
            Add_Control(new Form_ViewSaleInvoice());
        }
        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            Move_Slide(btnManageCustomer.Location.Y);
            Add_Control(new Form_ManageCustomer());
        }
        private void btnManagePersonalAccount_Click(object sender, EventArgs e)
        {
            Move_Slide(btnManagePersonalAccount.Location.Y);
            Add_Control(new Form_AccountInformation(accountSalePerson));
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
        
    }
}
