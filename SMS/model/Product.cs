namespace SMS.model
{
    public class Product
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int ProductQuantity { get; set; }
        public Product(int id, string barCode, string productName, double price, int productQuantity)
        {
            Id = id;
            BarCode = barCode;
            ProductName = productName;
            Price = price;
            ProductQuantity = productQuantity;
        }
        public string WriteToFIle()
        {
            return $"{Id}%%%%%{BarCode}%%%%%{ProductName}%%%%%{Price}%%%%%{ProductQuantity}";
        }

        public static Product ConvertToProduct(string productAllFromText)
        {
            var productConvert = productAllFromText.Split("%%%%%");
            return new Product(int.Parse(productConvert[0]), productConvert[1], productConvert[2], int.Parse(productConvert[3]), int.Parse(productConvert[4]));
        }
    }
}