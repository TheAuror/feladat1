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
            int percentage = 1;
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

        private void productNameSearchBox_TextChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                if(!((string)row.Cells[0].Value).Contains(productNameSearchBox.Text))
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();
                }
                else
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = true;
                    currencyManager1.ResumeBinding();
                }
            }
        }

        private void productNumberSearchBox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                if (!((string)row.Cells[1].Value).Contains(productNumberSearchBox.Text))
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();
                }
                else
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = true;
                    currencyManager1.ResumeBinding();
                }
            }
        }

        private void barCodeSearchBox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                if (!((string)row.Cells[2].Value).Contains(barCodeSearchBox.Text))
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();
                }
                else
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = true;
                    currencyManager1.ResumeBinding();
                }
            }
        }

        private void amountSearchBox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                if (!((string)row.Cells[3].Value).Contains(amountSearchBox.Text))
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();
                }
                else
                {
                    currencyManager1.SuspendBinding();
                    row.Visible = true;
                    currencyManager1.ResumeBinding();
                }
            }
        }
    }
}
