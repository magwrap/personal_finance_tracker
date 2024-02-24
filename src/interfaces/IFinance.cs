using Tracker.Finance;
using Tracker.Category;

namespace Tracker.Interface
{
    interface IFinance
    {
        void AddTransaction(Transaction transaction);
        void ViewTransaction(Transaction transaction);
        void CategorizeTransaction(Guid transactionId, TransactionCategory transactionCategory);
    }
}
