namespace SMS.model
{
    public class Wallet
    {
        public int Id { get; set; }
        public double WalletRemainingBalance { get; set; }
        public double WalletTotal { get; set; }
        public double WalletWithdrawal { get; set; }

        public Wallet(int id, double walletTotal, double walletWithdrawal, double walletRemainingBalance)
        {
            Id = id;
            WalletTotal = walletTotal;
            WalletWithdrawal = walletWithdrawal;
            WalletRemainingBalance = WalletWithdrawal;
        }
    }
}