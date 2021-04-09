using System;
using Models;

namespace SalesTaxes
{
    class Program
    {
        public static Warehouse warehouse;
        public static ShoppingBasket shoppingBasket;
        static void Main(string[] args)
        {
            var finished = false;
            warehouse = new Warehouse();
            FillWarehouseDefault();
            do
            {
                Console.WriteLine("*** Sales Taxes ***");
                PrintMainMenu();
                var key = Console.ReadLine();
                if (key is null) continue;
                if (key.ToLower() == "e") finished = true;
                if (int.TryParse(key, out var option))
                {
                    switch (option)
                    {
                        case 1:
                            PrintWarehouse();
                            break;
                        case 2:
                            AddProduct();
                            break;
                        case 3:
                            ChargeProduct();
                            Console.WriteLine(shoppingBasket.GetReceipt());
                            break;
                    }
                }
            } while (!finished);
            Console.ReadKey();
        }

        private static void ChargeProduct()
        {
            var finished = false;
            shoppingBasket = new ShoppingBasket();
            Console.WriteLine("*** Purchases items ***");
            Console.WriteLine("id - name");
            PrintWarehouse();
            Console.WriteLine("*** Press any key to continue ***");
            Console.ReadKey();
            Console.WriteLine("*** Add product to shopping basket ***");
            Console.WriteLine("Insert id product for adding to basket");
            Console.WriteLine("Press f to finish purchase");
            do
            {
                var key = Console.ReadLine();
                if (key is null) continue;
                if (key.ToLower() == "f")
                    finished = true;
                if (int.TryParse(key, out var option))
                {
                    var position = option - 1;
                    if (position < 0 || position >= warehouse.ProductList.Count)
                    {
                        Console.Error.WriteLine("*** Product not found ***");
                        continue;
                    }

                    var product = warehouse.ProductList[position];
                    shoppingBasket.Add(product);
                    Console.Error.WriteLine();
                    Console.WriteLine($"The product {product.Name} was added to basket");
                    Console.Error.WriteLine();
                }

            } while (!finished);
        }

        private static void AddProduct()
        {
            var finished = false;
            Console.WriteLine("*** Add product ***");
            do
            {
                Console.WriteLine("*** Choose the type of product ***");
                Console.WriteLine("1 - Basic (10% taxes)");
                Console.WriteLine("2 - Exempt (free taxes)");
                Console.WriteLine("3 - Imported basic (15% taxes)");
                Console.WriteLine("4 - Imported Exempt (5% taxes)");
                Console.WriteLine("e - Exit");
                var key = Console.ReadLine();
                if (key is null) continue;
                if (key.ToLower() == "e")
                    finished = true;
                if (!int.TryParse(key, out var option)) continue;

                Console.WriteLine("Insert name");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.Error.WriteLine("Name is requeried");
                    break;
                }


                Console.WriteLine("Insert cost");
                var costCad = Console.ReadLine();
                if (!double.TryParse(costCad, out var cost))
                {
                    Console.Error.WriteLine("Cost not valid");
                    break;
                }

                if (cost <= 0)
                {
                    Console.Error.WriteLine("Cost not valid");
                    break;
                }
                switch (option)
                {
                    case 1:
                        warehouse.AddProduct(new Basic(name, cost));
                        break;
                    case 2:
                        warehouse.AddProduct(new Exempt( name, cost));
                        break;
                    case 3:
                        warehouse.AddProduct(new ImportedBasic( name, cost));
                        break;
                    case 4:
                        warehouse.AddProduct(new ImportedExcent( name, cost));
                        break;
                }
                Console.WriteLine($"{name} inserted success");

            } while (!finished);
        }

        private static void PrintWarehouse()
        {
            Console.WriteLine("*** Product list ***");
            warehouse.PrintList();
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("1 - View store stock");
            Console.WriteLine("2 - Add product to stock");
            Console.WriteLine("3 - Charge products");
            Console.WriteLine("e - Exit");
        }

        private static void FillWarehouseDefault()
        {
            var book = new Exempt("Book", 12.49);
            var musicCD = new Basic("Music CD", 14.99);
            var chocolateBar = new Exempt(" Chocolate bar", 0.85);

            var importedChocolate1 = new ImportedExcent("Imported box of chocolates 1", 10.00);
            var importedPerfume1 = new ImportedBasic("Imported bottle of perfume 1", 47.50);

            var importedPerfume2 = new ImportedBasic("Imported bottle of perfume 2", 27.99);
            var perfume = new Basic("Bottle of perfume", 18.99);
            var headachePills = new Exempt("Packet of headache pills", 9.75);
            var importedChocolate2 = new ImportedExcent("Imported box of chocolates 2", 11.25);

            warehouse.AddProduct(book);
            warehouse.AddProduct(musicCD);
            warehouse.AddProduct(chocolateBar);
            warehouse.AddProduct(importedChocolate1);
            warehouse.AddProduct(importedPerfume1);
            warehouse.AddProduct(importedPerfume2);
            warehouse.AddProduct(perfume);
            warehouse.AddProduct(headachePills);
            warehouse.AddProduct(importedChocolate2);
        }
    }
}
