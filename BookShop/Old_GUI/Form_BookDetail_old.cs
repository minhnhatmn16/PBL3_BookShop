using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.Controls
{
    public partial class Form_BookDetail_old : Form
    {
        public Form_BookDetail_old()
        {
            InitializeComponent();
        }

        public void takeData(String[] data)
        {
            txtbIDBookInfor.Text = data[0];
            txtbTitle.Text = data[1];
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
