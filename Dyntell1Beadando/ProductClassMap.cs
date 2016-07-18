using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyntell1Beadando
{
    public sealed class ProductClassMap : CsvClassMap<Product>
    {
        public ProductClassMap()
        {
            Map(m => m.ProductName).Name("Cikknev");
            Map(m => m.ProductNumber).Name("Cikkszam");
            Map(m => m.BarCode).Name("Vonalkod");
            Map(m => m.Amount).Name("MennyisegiEgyseg");
        }
    }
}
