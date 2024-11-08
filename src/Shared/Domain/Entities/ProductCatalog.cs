using System;


namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public decimal TaxRate { get; private set; }

        public Product(int productId, string name, decimal price, decimal taxRate)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            TaxRate = taxRate;
        }

        // Metoda oblicza podatek dla produktu
        public decimal CalculateTax()
        {
            return Price * TaxRate;
        }

        // Metoda oblicza cenę brutto (z podatkiem)
        public decimal TotalPrice()
        {
            return Price + CalculateTax();
        }

        public override string ToString()
        {
            return $"Product ID: {ProductId}, Name: {Name}, Price: {Price:C}, Tax Rate: {TaxRate:P}, Total Price: {TotalPrice():C}";
        }
    }
    public class ProductCatalog
    {
        private List<Product> products = new List<Product>();

        // Metoda dodaje produkt do katalogu
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Metoda usuwa produkt z katalogu na podstawie ProductId
        public bool RemoveProduct(int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        // Metoda wyszukuje produkt na podstawie ProductId
        public Product FindProduct(int productId)
        {
            return products.FirstOrDefault(p => p.ProductId == productId);
        }

        // Wyświetla wszystkie produkty w katalogu
        public void DisplayAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products in catalog.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}
