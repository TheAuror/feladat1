using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dyntell1Beadando
{
    public partial class NewItemForm : Form
    {
        public Product Product { get; set; }

        public NewItemForm()
        {
            InitializeComponent();
        }

        private void NewItemForm_Load(object sender, EventArgs e)
        {
            Product = new Product();
            bindingSource1.DataSource = Product;
        }

        private void NewItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                bindingSource1.EndEdit();
                if(Product.Error != null)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
