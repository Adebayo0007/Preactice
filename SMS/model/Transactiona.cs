using System;

namespace SMS.model
{
    public class Transactiona
    {
        public string ReceiptNo { get; set; }
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string BarCode { get; set; }
        public DateTime Datetime { get; set; }
        public double CashTender { get; set; }
        public Transactiona(int id, string receiptNo, string barCode, int quantity, double total, string customerId, DateTime datetime, double cashTender)
        {
            ReceiptNo = receiptNo;
            Id = id;
            CashTender = cashTender;
            BarCode = barCode;
            Quantity = quantity;
            CustomerId = customerId;
            Total = total;
            Datetime = datetime;
        }
        public string WriteToFIle()
        {
            return $"{Id}%%%%%{ReceiptNo}%%%%%{BarCode}%%%%%{Quantity}%%%%%{Total}%%%%%{CustomerId}%%%%%{Datetime}%%%%%{CashTender}";
        }

        public static Transactiona ConvertToTransaction(string transactionAllFromText)
        {
            var transactionConvert = transactionAllFromText.Split("%%%%%");
            return new Transactiona(int.Parse(transactionConvert[0]), transactionConvert[1], transactionConvert[2], int.Parse(transactionConvert[3]), double.Parse(transactionConvert[4]), transactionConvert[5], DateTime.Parse(transactionConvert[6]), double.Parse(transactionConvert[7]));
        }
    }
}