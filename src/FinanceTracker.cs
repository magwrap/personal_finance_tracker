using Tracker.Interface;
using Tracker.Category;

namespace Tracker.Finance
{
    class FinanceTracker : IFinance
    {
        private decimal _totalIncome;
        private decimal _totalExpenses;
        public decimal Balance
        {
            get
            {
                return _totalIncome - _totalExpenses;
            }
        }

        public FinanceTracker()
        { }

        void IFinance.CategorizeTransaction(Guid transactionId, TransactionCategory category)
        { }

        void IFinance.ViewTransaction(Tracker.Finance.Transaction transaction)
        { }

        void IFinance.AddTransaction(Tracker.Finance.Transaction transaction)
        { }


    }
}


// Implements the IFinance interface, managing a list of Transaction objects.
// It includes functionality to add transactions, categorize them, and provide summaries (e.g., total income, total expenses, balance).
