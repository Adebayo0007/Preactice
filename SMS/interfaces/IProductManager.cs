using SMS.model;

namespace SMS.interfaces
{
    public interface IProductManager
    {
        void CreateProduct(string barCode, string productName, double price, int productQuantity);
        Product GetProduct(string barCode);
        void UpdateProduct(string barCode, string productName, double price);
        void DeleteProduct(string barCode);
        void ViewAllProduct();
        void ReadFromFile();
        void ReWriteToFile();
    }
}