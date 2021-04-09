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
            if (ProductList.Any(x => x.Equals(product)))
            {
                Console.Error.WriteLine($"{product.Name} already exists");
                return;
            }
            ProductList.Add(product);
        }

        public void PrintList()
        {
            var count = 1;
            foreach (var product in ProductList)
            {
                Console.WriteLine($"{count} - {product}");
                count++;
            }
        }
    }
}
