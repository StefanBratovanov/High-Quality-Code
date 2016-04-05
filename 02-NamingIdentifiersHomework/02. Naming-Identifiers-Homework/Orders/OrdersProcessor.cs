
namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Collections.Generic;
    using Orders.Models;

    public class OrdersProcessor
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var mapper = new DataMapper();
            var categories = mapper.GetAllCategories();
            var products = mapper.GetAllProducts();
            var orders = mapper.GetAllOrders();

            DisplayTopFiveProductsByPrice(products);

            DisplayCategoriesAndNumberOfProducts(products, categories);

            DisplayTopFiveProductsByQuantity(orders, products);

            DisplayTheMostProfitableCategory(orders, products, categories);
        }

        private static void DisplayTheMostProfitableCategory(IEnumerable<Order> orders, IEnumerable<Product> products, IEnumerable<Category> categories)
        {
            var category = orders
                .GroupBy(o => o.ProductId)
                .Select(group => new
                {
                    CategoryId = products.First(p => p.Id == @group.Key).CatId,
                    Price = products.First(p => p.Id == @group.Key).UnitPrice,
                    Quantity = @group.Sum(p => p.Quantity)
                })
                .GroupBy(order => order.CategoryId)
                .Select(group => new
                {
                    CategoryName = categories.First(c => c.Id == @group.Key).Name,
                    TotalQuantity = @group.Sum(g => g.Quantity * g.Price)
                })
                .OrderByDescending(group => @group.TotalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", category.CategoryName, category.TotalQuantity);
        }

        private static void DisplayTopFiveProductsByQuantity(IEnumerable<Order> orders, IEnumerable<Product> products)
        {
            var topFiveProductsByQuantity = orders
                .GroupBy(o => o.ProductId)
                .Select(group => new
                {
                    Product = products.First(p => p.Id == @group.Key).Name,
                    Quantities = @group.Sum(p => p.Quantity)
                })
                .OrderByDescending(o => o.Quantities)
                .Take(5);
            foreach (var item in topFiveProductsByQuantity)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));
        }

        private static void DisplayCategoriesAndNumberOfProducts(IEnumerable<Product> products, IEnumerable<Category> categories)
        {
            var productsByCategories = products
                .GroupBy(p => p.CatId)
                .Select(group => new
                {
                    Category = categories.First(c => c.Id == @group.Key).Name,
                    Count = @group.Count()
                })
                .ToList();
            foreach (var item in productsByCategories)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));
        }

        private static void DisplayTopFiveProductsByPrice(IEnumerable<Product> products)
        {
            var topFiveProductsByPrice = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, topFiveProductsByPrice));

            Console.WriteLine(new string('-', 10));
        }
    }
}
