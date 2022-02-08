using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{Id=1,Name="Bilgisayar"},
                new Category{Id=2,Name="Telefon"}

            };

            List<Product> products = new List<Product>
            {
                new Product{Id=1,CategoryId=1,Name = "Asus",UnitPrice =10000,UnitsInStock= 20},
                new Product{Id=2,CategoryId=1,Name = "Lenova",UnitPrice =15000,UnitsInStock= 15},
                new Product{Id=1,CategoryId=2,Name = "IPhone",UnitPrice =11000,UnitsInStock= 20},
                new Product{Id=2,CategoryId=2,Name = "Samsung",UnitPrice =7000,UnitsInStock= 15},

            };


            TestLinq testLinq = new TestLinq();
            //testLinq.GetHashCode();

            //TestAny(products);

            //TestFind(products);

            //TestOrderBy(products);

        }

        private static void TestOrderBy(List<Product> products)
        {
            var result = products.OrderByDescending(p => p.UnitPrice).ThenBy(p => p.Name);
            foreach (var product in result)
            {
                Console.WriteLine(product.Name);
            }
        }

        private static void TestFind(List<Product> products)
        {
            var result = products.Find(p => p.Id == 2);
            Console.WriteLine(result);
        }

        private static void TestAny(List<Product> products)
        {
            var result = products.Any(p => p.Name == "Asus");
            Console.WriteLine(result);
        }

    }

    class TestLinq
    {
        static List<Product> GetProduct(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 1000 && p.UnitsInStock > 15).ToList();

        }
    }
    class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }

}
