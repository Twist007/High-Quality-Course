using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Orders.Models;

namespace Orders
{
    class OrdersMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            DataMapper dataMapper = new DataMapper();
            IEnumerable<Category> categories = dataMapper.GetAllCategories();
            IEnumerable<Product> products = dataMapper.GetAllProducts();
            IEnumerable<Order> orders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            IEnumerable<string> expesiveProducts = products
                .OrderByDescending(product => product.UnitPrice)
                .Take(5)
                .Select(product => product.Name);
            Console.WriteLine(string.Join(Environment.NewLine, expesiveProducts));

            Console.WriteLine(new string('-', 10));

            // Number of products in each Category
            var inEachCategory = products
                .GroupBy(product => product.CategoryId)
                .Select(grp => new
                {
                    Category = categories.First(c => c.Id == grp.Key).Name,
                    Count = grp.Count()
                })
                .ToList();
            foreach (var product in inEachCategory)
            {
                Console.WriteLine("{0}: {1}", product.Category, product.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by Order quantity)
            var topProducts = orders
                .GroupBy(order => order.ProductId)
                .Select(grp => new
                {
                    Product = products.First(product => product.Id == grp.Key).Name,
                    Quantities = grp.Sum(groupOrder => groupOrder.Quant)
                })
                .OrderByDescending(quantity => quantity.Quantities)
                .Take(5);
            foreach (var product in topProducts)
            {
                Console.WriteLine("{0}: {1}", product.Product, product.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable Category
            var category = orders
                .GroupBy(order => order.ProductId)
                .Select(group => new
                {
                    categoryId = products.First(product => product.Id == group.Key).CategoryId,
                    price = products.First(product => product.Id == group.Key).UnitPrice,
                    quantity = group.Sum(product => product.Quant)
                })
                .GroupBy(categoryGroup => categoryGroup.categoryId)
                .Select(grp => new
                {
                    categoryName = categories.First(cat => cat.Id == grp.Key).Name,
                    totalQuantity = grp.Sum(group => group.quantity * group.price)
                })
                .OrderByDescending(group => group.totalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", category.categoryName, category.totalQuantity);
        }
    }
}
