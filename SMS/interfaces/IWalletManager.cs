namespace SMS.interfaces
{
    public interface IWalletManager
    {
        void CreateWallet();
        void GetTotalWalletTransaction();
        double CalculateRemainingBalance(); 
    }
}