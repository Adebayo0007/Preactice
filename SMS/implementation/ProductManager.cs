using System;
using System.Collections.Generic;
using System.IO;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class ProductManager : IProductManager
    {
        public static List<Product> ListOfProduct = new List<Product>();
        public string ProductFilePath = @"./Files/product.txt";
        public void CreateProduct(string barCode, string productName, double price, int productQuantity)
        {
            var id = ListOfProduct.Count + 1;
            var product = new Product(id, barCode, productName, price, productQuantity);
            if (GetProduct(barCode) == null)
            {
                ListOfProduct.Add(product);
                using (var streamWriter = new StreamWriter(ProductFilePath, append: true))
                {
                    streamWriter.WriteLine(product.WriteToFIle());
                }

                Console.WriteLine($"Product Added Successfully. \nThere are total of {id} product's in the store.");
            }
            else
            {
                Console.WriteLine("Product already exist. \nKindly Go to Update to Update Available Quantity");
            }
        }
        public void DeleteProduct(string barCode)
        {
            var product = GetProduct(barCode);
            if (product != null)
            {
                Console.WriteLine($"{product.ProductName} Successfully deleted. ");
                ListOfProduct.Remove(product);
                ReWriteToFile();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public Product GetProduct(string barCode)
        {
            foreach (var item in ListOfProduct)
            {
                if (item.BarCode == barCode)
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateProduct(string barCode, string productName, double price)
        {
            var product = GetProduct(barCode);
            if (product != null)
            {
                product.BarCode = barCode;
                product.ProductName = productName;
                product.Price = price;
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        public void ViewAllProduct()
        {
            foreach (var item in ListOfProduct)
            {
                Console.WriteLine($"{item.Id}\t{item.ProductName}\t{item.BarCode}\t{item.Price}\t{item.ProductQuantity}");
            }
        }
        public void ReWriteToFile()
        {
            File.WriteAllText(ProductFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(ProductFilePath, append: true))
            {
                foreach (var item in ListOfProduct)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }
        public void ReadFromFile()
        {
            if (!File.Exists(ProductFilePath))
            {
                var fileStream = new FileStream(ProductFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(ProductFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var productManager = streamReader.ReadLine();
                    ListOfProduct.Add(Product.ConvertToProduct(productManager));
                }
            }
        }
    }
}