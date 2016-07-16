using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dyntell1Beadando
{
    public partial class Form1 : Form
    {
        private BindingList<Product> _products = new BindingList<Product>();
        private BindingList<Product> _searchResult = new BindingList<Product>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _products;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int percentage = 0;
            using (StreamReader reader = (new StreamReader((string)e.Argument, Encoding.GetEncoding("iso-8859-1"))))
            {
                
                var csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.CultureInfo = CultureInfo.CurrentUICulture;
                while(csv.Read())
                {
                    Product temp = new Product();
                    temp.ProductName = csv.GetField<string>(0);
                    temp.ProductNumber = csv.GetField<string>(1);
                    temp.BarCode = csv.GetField<string>(2);
                    temp.Amount = csv.GetField<AmountType>(3);
                    Invoke(new Action(() =>
                    {
                        _products.Add(temp);
                    }));
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            bindingSource1.CancelEdit();
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.CheckFileExists = true;
                open.Multiselect = false;
                open.Filter = "Csv fájlok (.csv)|*.csv|Minden fájl|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync(open.FileName);
                }
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            _searchResult.Clear();
            foreach(Product product in _products)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                if((product.ProductName).Contains(productNameSearchBox.Text) && 
                   (product.ProductNumber).Contains(productNumberSearchBox.Text) &&
                   (product.BarCode).Contains(barCodeSearchBox.Text) &&
                   (product.Amount.ToString()).Contains(amountSearchBox.Text))
                {
                    _searchResult.Add(product);
                }
            }
            bindingSource1.DataSource = _searchResult;
        }
    }
}
