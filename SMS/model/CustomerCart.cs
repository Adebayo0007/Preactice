namespace SMS.model
{
    public class CustomerCart
    {
        public int Quantity { get; set; }
        public string BarCode { get; set; }
        public CustomerCart(string barCode, int quantity)
        {
            BarCode = barCode;
            Quantity = quantity;
        }
    }
}