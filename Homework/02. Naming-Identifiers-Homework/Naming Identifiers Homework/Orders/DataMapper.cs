using System.Collections.Generic;
using System.IO;
using System.Linq;
using Orders.Models;

namespace Orders
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
            IEnumerable<string> categories = ReadTextFromFile(this.categoriesFileName, true);
            return categories
                .Select(category => category.Split(','))
                .Select(category => new Category
                {
                    Id = int.Parse(category[0]),
                    Name = category[1],
                    Description = category[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<string> products = ReadTextFromFile(this.productsFileName, true);
            return products
                .Select(product => product.Split(','))
                .Select(product => new Product
                {
                    Id = int.Parse(product[0]),
                    Name = product[1],
                    CategoryId = int.Parse(product[2]),
                    UnitPrice = decimal.Parse(product[3]),
                    UnitsInStock = int.Parse(product[4]),
                });
        }

        public IEnumerable<Order> GetAllOrders()
        {
            IEnumerable<string> orders = ReadTextFromFile(this.ordersFileName, true);
            return orders
                .Select(ordeer => ordeer.Split(','))
                .Select(order => new Order
                {
                    Id = int.Parse(order[0]),
                    ProductId = int.Parse(order[1]),
                    Quant = int.Parse(order[2]),
                    Discount = decimal.Parse(order[3]),
                });
        }

        private static IEnumerable<string> ReadTextFromFile(string fileName, bool hasHeader)
        {
            List<string> text = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                if (hasHeader)
                {
                    reader.ReadLine();
                }
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    text.Add(currentLine);

                    currentLine = reader.ReadLine();
                }
            }

            return text;
        }
    }
}
