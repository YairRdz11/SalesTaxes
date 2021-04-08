using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class ShoppingBasket
    {
        private readonly IList<Product> ProductList;
        private IList<ShoppingBasketProduct> ShoppingBasketProductList;

        public ShoppingBasket()
        {
            ProductList = new List<Product>();
            ShoppingBasketProductList = new List<ShoppingBasketProduct>();
        }

        public int GetProductListLength()
        {
            return ProductList.Count();
        }

        public void Add(Product product)
        {
            ProductList.Add(product);
        }

        public double GetSalesTaxes()
        {
            return Math.Ceiling(ProductList.Sum(x => x.Taxes) * 20) /20;
        }

        public double GetTotal()
        {
            return Math.Round(ProductList.Sum(x => x.Total), 2);
        }

        public string GetReceipt()
        {
            var row = string.Empty;
            ShoppingBasketProductList = new List<ShoppingBasketProduct>();
            CreateShoppingBasketProcuctList();

            var cad = ShoppingBasketProductList.Aggregate(row,
                (current, shoppingBasketProduct) => current + shoppingBasketProduct.GetRow());
            cad += $"Sales Taxes: {GetSalesTaxes():0.00}/n";
            cad += $"Total: {GetTotal():0.00}/n";
            return cad;
        }

        private void CreateShoppingBasketProcuctList()
        {
            foreach (var producti in ProductList)
            {
                if(producti.Checked) continue;
                producti.Check();
                var count = 1;
                foreach (var productj in ProductList)
                {
                    if (productj.Checked) continue;
                    if (!producti.Equals(productj)) continue;
                    count++;
                    productj.Check();
                }
                ShoppingBasketProductList.Add(new ShoppingBasketProduct(count, producti));
            }
        }
    }
}
