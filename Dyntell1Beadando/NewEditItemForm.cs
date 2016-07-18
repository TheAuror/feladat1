using System;
using System.Windows.Forms;

namespace Dyntell1Beadando
{
    public partial class NewEditItemForm : Form
    {
        public Product _product { get; set; } = new Product();

        public NewEditItemForm(Product editedProduct = null)
        {
            InitializeComponent();
            amountComboBox.DataSource = Enum.GetValues(typeof(AmountType));
            amountComboBox.DataBindings.Add("SelectedItem", bindingSource1, "Amount", true);
            if (editedProduct != null)
            {
                _product.DeepCopy(editedProduct);
                Text = "Elem szerkesztése";
            }
        }

        private void NewItemForm_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _product;
        }

        private void NewItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult == DialogResult.OK)
            {
                bindingSource1.EndEdit();
                if(_product.Error != null)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                e.Cancel = false;
                return;
            }
        }
    }
}
