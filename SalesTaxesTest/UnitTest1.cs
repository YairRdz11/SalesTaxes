using Models;
using NUnit.Framework;

namespace SalesTaxesTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void ttp_applyTaxesToBasicProduct()
        {
            var basic = new Basic(1,"Music CD", 14.99);

            Assert.AreEqual(1.5, basic.Taxes);
        }
        [Test]
        public void ttp_GetTotalToBasicProduct()
        {
            var basic = new Basic(1, "Music CD", 14.99);

            Assert.AreEqual(16.49, basic.Total);
        }

        [Test]
        public void ttp_applyTaxesToImportedExcentProduct()
        {
            var imported = new ImportedExcent(1, "Imported box of chocolates", 10);

            Assert.AreEqual(0.5, imported.Taxes);
        }
        [Test]
        public void ttp_GetTotalToImportedExcentProduct()
        {
            var imported = new ImportedExcent(1, "Imported box of chocolates", 10);

            Assert.AreEqual(10.50, imported.Total);
        }
        [Test]
        public void ttp_applyTaxesToImportedBasicProduct()
        {
            var imported = new ImportedBasic(1, "Imported bottle of perfume", 47.50);

            Assert.AreEqual(7.15, imported.Taxes);
        }
        [Test]
        public void ttp_GetTotalToImportedBasicProduct()
        {
            var imported = new ImportedBasic(1, "Imported bottle of perfume", 47.50);

            Assert.AreEqual(54.65, imported.Total);
        }
        [Test]
        public void ttp_applyTaxesExemptProduct()
        {
            var exempt = new Exempt(1, "Book", 12.49);

            Assert.AreEqual(0, exempt.Taxes);
        }
        [Test]
        public void ttp_GetTotalToExemptProduct()
        {
            var exempt = new Exempt(1, "Book", 12.49);

            Assert.AreEqual(12.49, exempt.Total);
        }
        [Test]
        public void ttp_addExceptProductToBasket()
        {
            var shoppingBasket = new ShoppingBasket();
            var exempt = new Exempt(1, "Book", 12.49);
            shoppingBasket.Add(exempt);
            Assert.AreEqual(1, shoppingBasket.GetProductListLength());
        }
        [Test]
        public void ttp_addBasicProductToBasket()
        {
            var shoppingBasket = new ShoppingBasket();
            var basic = new Basic(1, "Music CD", 14.99);
            shoppingBasket.Add(basic);
            Assert.AreEqual(1, shoppingBasket.GetProductListLength());
        }
        [Test]
        public void ttp_addImporteBasicProductToBasket()
        {
            var shoppingBasket = new ShoppingBasket();
            var imported = new ImportedBasic(1, "Imported bottle of perfume", 47.50);
            shoppingBasket.Add(imported);
            Assert.AreEqual(1, shoppingBasket.GetProductListLength());
        }
        [Test]
        public void ttp_addImporteExemptProductToBasket()
        {
            var shoppingBasket = new ShoppingBasket();
            var imported = new ImportedExcent(1, "Imported box of chocolates", 10);
            shoppingBasket.Add(imported);
            Assert.AreEqual(1, shoppingBasket.GetProductListLength());
        }
        [Test]
        public void ttp_GetSalesTaxesFromProductToBasket()
        {
            var shoppingBasket = new ShoppingBasket();

            var importedBasic = new ImportedBasic(1, "Imported bottle of perfume", 27.99);
            var basic = new Basic(1, "Bottle of perfume", 18.99);
            var exempt = new Exempt(1, "Packet of headache", 12.49);
            var importedExcept = new ImportedExcent(1, "Imported box of chocolates", 11.25);
            var importedExcept2 = new ImportedExcent(1, "Imported box of chocolates", 11.25);

            shoppingBasket.Add(importedBasic);
            shoppingBasket.Add(basic);
            shoppingBasket.Add(exempt);
            shoppingBasket.Add(importedExcept);
            shoppingBasket.Add(importedExcept2);

            Assert.AreEqual(7.30, shoppingBasket.GetSalesTaxes());
        }

        [Test]
        public void ttp_GetTotalFromProductToBasket()
        {
            var shoppingBasket = new ShoppingBasket();

            var importedBasic = new ImportedBasic(1, "Imported bottle of perfume", 27.99);
            var basic = new Basic(2, "Bottle of perfume", 18.99);
            var exempt = new Exempt(3, "Packet of headache", 9.75);
            var importedExcept = new ImportedExcent(4, "Imported box of chocolates", 11.25);
            var importedExcept2 = new ImportedExcent(4, "Imported box of chocolates", 11.25);

            shoppingBasket.Add(importedBasic);
            shoppingBasket.Add(basic);
            shoppingBasket.Add(exempt);
            shoppingBasket.Add(importedExcept);
            shoppingBasket.Add(importedExcept2);

            Assert.AreEqual(86.53, shoppingBasket.GetTotal());
        }

        [Test]
        public void ttp_GetReceiptFromBasket()
        {
            var shoppingBasket = new ShoppingBasket();

            var importedBasic = new ImportedBasic(1, "Imported bottle of perfume", 27.99);
            var basic = new Basic(2, "Bottle of perfume", 18.99);
            var exempt = new Exempt(3, "Packet of headache pills", 9.75);
            var importedExcept = new ImportedExcent(4, "Imported box of chocolates", 11.25);
            var importedExcept2 = new ImportedExcent(4, "Imported box of chocolates", 11.25);

            shoppingBasket.Add(importedBasic);
            shoppingBasket.Add(basic);
            shoppingBasket.Add(exempt);
            shoppingBasket.Add(importedExcept);
            shoppingBasket.Add(importedExcept2);

            Assert.AreEqual(
                "Imported bottle of perfume: 32.19/n" +
                "Bottle of perfume: 20.89/n" +
                "Packet of headache pills: 9.75/n" +
                "Imported box of chocolates: 23.70 (2 @ 11.85)/n" +
                "Sales Taxes: 7.30/n" +
                "Total: 86.53/n", shoppingBasket.GetReceipt());
        }
    }
}