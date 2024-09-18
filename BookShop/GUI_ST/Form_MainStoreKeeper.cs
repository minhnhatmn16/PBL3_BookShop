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

namespace BookShop.Storekeeper
{
    public partial class Form_MainStoreKeeper : Form
    {
        static public Account accountStoreKeeper = new Account();
        public Form_MainStoreKeeper()
        {
            InitializeComponent();
            timer1.Start();
            accountStoreKeeper = Account_BLL.Instance.getAccountByID(Account_BLL.Instance.UserID);
            lbUserName.Text = accountStoreKeeper.UserName;
            lbRole.Text = accountStoreKeeper.RoleName;
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
            Move_Slide(but_Personal.Location.Y);
            Add_Control(new Form_AccountInformation(accountStoreKeeper));
        }

        private void but_BookManage_Click(object sender, EventArgs e)
        {
            Move_Slide(but_BookManage.Location.Y);
            Add_Control(new Form_ManageBook());
        }

        private void but_CreateInvoice_Click(object sender, EventArgs e)
        {
            Move_Slide(but_CreateInvoice.Location.Y);
            Add_Control(new Form_CreateImportInvoice());
        }

        private void but_ViewInvoice_Click(object sender, EventArgs e)
        {
            Move_Slide(but_ViewInvoice.Location.Y);
            Add_Control(new Form_ViewImportInvoice());
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
    }
}
