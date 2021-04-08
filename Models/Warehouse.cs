using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Warehouse
    {
        public IList<Product> ProductList { get; }

        public Warehouse()
        {
            ProductList = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if(ProductList.Any(x=> x.Equals(product))) return;
            ProductList.Add(product);
        }

        public string PrintList()
        {
            var cad = string.Empty;
            foreach (var product in ProductList)
            {
                cad += product.ToString();
                Console.WriteLine(product.ToString());
            }

            return cad;
        }
    }
}
