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
            return cad;
        }

        private void CreateShoppingBasketProcuctList()
        {
            foreach (var producti in ProductList)
            {
                producti.Check();
                var count = ProductList.Where(productj => !productj.Checked)
                    .Count(productj => producti.Equals(productj));
                ShoppingBasketProductList.Add(new ShoppingBasketProduct(count + 1, producti));
            }
        }
    }
}
