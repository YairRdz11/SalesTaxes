namespace Models
{
    public class ShoppingBasketProduct
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
                ? $"{Product.Name}: {Product.Total * Quantity} ({Quantity} @ {Product.Total})/n" 
                : $"{Product.Name}: {Product.Total}/n";
        }
    }
}
