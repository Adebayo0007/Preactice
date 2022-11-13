namespace SMS.interfaces
{
    public interface ITransactionManager
    {
        void CreateTransaction(string barCode, int quantity, string customerId, double cashTender);
        // void GetTransaction(string receiptNo);
        // Transaction UpdateTransaction();
        // void DeleteTransaction(string receiptNo);
        void GetAllTransactions();
        double GetAllTransactionsAdmin();
        double CalculateTotalSales();
        void ReadFromFile();
        void ReWriteToFile();
    }
}