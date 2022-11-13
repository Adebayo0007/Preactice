namespace SMS.interfaces
{
    public interface ICustomerCartManager
    {
        void AddToCart(string barCode, int quantity);
        void RemoveFromCart(string barCode);
        void UpdateCart(string barCode, int quantity);

    }
}