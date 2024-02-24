using Tracker.Finance;
using Tracker.Category;

namespace Tracker.Interface
{
    interface IFinance
    {
        void AddTransaction(Transaction transaction);
        void ViewTransactions(TransactionCategory? categoryFilter = null);
        void CategorizeTransaction(Guid transactionId, TransactionCategory transactionCategory);
        void ViewFinancialSummary();
        void SaveTransactionData();
        static void ViewTransaction(Transaction transaction)
        {
            Console.WriteLine(@$"
                Id: {transaction.TransactionId}
                Amount: {transaction.Amount}
                Category: {transaction.Category.CategoryName} 
                Date: {transaction.Date}
                Description: {transaction.Description}
                ");
        }
    }
}
