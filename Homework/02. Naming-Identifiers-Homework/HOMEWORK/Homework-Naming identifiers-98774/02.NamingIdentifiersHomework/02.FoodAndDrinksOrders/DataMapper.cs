using System.Collections.Generic;
using System.Linq;
using System.IO;
using _02.FoodAndDrinksOrders.Models;

namespace _02.FoodAndDrinksOrders
{
    public class DataMapper
    {
        private readonly string categoriesFileName;
        private readonly string productsFileName;
        private readonly string ordersFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public DataMapper()
            : this("../../Data/categories.txt", "../../Data/products.txt", "../../Data/orders.txt")
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = ReadFileToEnd(this.categoriesFileName, true);
            return categories
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    Id = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = ReadFileToEnd(this.productsFileName, true);
            return products
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    CategoryId = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = ReadFileToEnd(this.ordersFileName, true);
            return orders
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    Id = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quantity = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });
        }

        private List<string> ReadFileToEnd(string filename, bool hasHeader)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    lines.Add(currentLine);
                    currentLine = reader.ReadLine();
                }
            }

            return lines;
        }
    }
}
