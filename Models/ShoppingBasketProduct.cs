namespace Models
{
    internal class ShoppingBasketProduct
    {
        public int Quantity { get; }
        public Product Product { get; }

        public ShoppingBasketProduct(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }

        public string GetRow()
        {
            return Quantity > 1
                ? $"{Product.Name}: {Product.Total * Quantity:0.00} ({Quantity} @ {Product.Total:0.00})\n" 
                : $"{Product.Name}: {Product.Total:0.00}\n";
        }
    }
}
