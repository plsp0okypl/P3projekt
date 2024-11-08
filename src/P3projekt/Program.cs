using System;
using Domain.Entities;



    class Program
    {
        static void Main(string[] args)
        {
            // Tworzymy instancję katalogu produktów
            var catalog = new ProductCatalog();

            // Dodajemy produkty do katalogu
            catalog.AddProduct(new Product(1, "Chleb", 3.99m, 0.08m));
            catalog.AddProduct(new Product(2, "Mleko", 2.50m, 0.08m));
            catalog.AddProduct(new Product(3, "Ser", 5.99m, 0.08m));

            // Wyświetlamy wszystkie produkty w katalogu
            catalog.DisplayAllProducts();

            // Znajdujemy i wyświetlamy produkt po jego ID
            var product = catalog.FindProduct(2);
            Console.WriteLine("\nWyszukany produkt:");
            Console.WriteLine(product);

            // Usuwamy produkt i wyświetlamy pozostałe
            catalog.RemoveProduct(1);
            Console.WriteLine("\nKatalog po usunięciu produktu:");
            catalog.DisplayAllProducts();
        }
    }

