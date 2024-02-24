using Tracker.Interface;
using Tracker.Category;

namespace Tracker.Finance
{
    class FinanceTracker : IFinance
    {
        private decimal _totalIncome;
        private List<Transaction> _transactions = new();

        public decimal TotalExpenses
        {
            get
            {
                decimal _totalExpenses = 0;
                foreach (Transaction transaction in _transactions)
                {
                    _totalExpenses += transaction.Amount;
                }
                return _totalExpenses;
            }
        }

        public decimal TotalIncome
        {
            get
            {
                return _totalIncome;
            }
            set
            {
                _totalIncome = value;
            }
        }

        public List<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
        }

        public decimal Balance
        {
            get
            {
                return _totalIncome - TotalExpenses;
            }
        }

        public IFinanceStorage financeStore = new JsonFinanceStore();

        public FinanceTracker()
        {
            _transactions = financeStore.LoadTransactionData();
        }

        void IFinance.CategorizeTransaction(Guid transactionId, TransactionCategory category)
        {
            var transaction = _transactions.Find(transaction => transaction.TransactionId == transactionId);

            if (transaction != null)
            {
                transaction.Category = category;
            }
        }

        void ViewTransaction(Transaction transaction)
        {
            IFinance.ViewTransaction(transaction);
        }

        void IFinance.ViewTransactions(TransactionCategory? categoryFilter)
        {
            foreach (Transaction transaction in Transactions)
            {
                if (categoryFilter == null)
                {
                    Console.WriteLine("--------------------------");
                    IFinance.ViewTransaction(transaction);
                }
                else if (categoryFilter.CategoryName == transaction.Category.CategoryName)
                {
                    Console.WriteLine("--------------------------");
                    IFinance.ViewTransaction(transaction);
                }
            }

            Utils.GetEnterConfirmation();
        }

        void IFinance.AddTransaction(Tracker.Finance.Transaction transaction)
        {
            if (_transactions.Contains((transaction)))
            {
                Console.WriteLine("Exact transaction already exists! Do you want to add it once more? [y/n]");
                int choice = Utils.GetUserOption(new string[] { "yes", "no" });

                if (choice == 0)
                {
                    Console.WriteLine("adding transaction");
                    _transactions.Add(transaction);
                }
            }
            else
            {
                _transactions.Add(transaction);
            }
        }

        void IFinance.ViewFinancialSummary()
        {
            //views overview of balance, income and expenses
            Console.WriteLine(@$"
                Income: {_totalIncome}
                Expenses: {TotalExpenses}
                Balance: {Balance}
                ");
        }

        void IFinance.SaveTransactionData()
        {
            financeStore.SaveTransactionData();
        }


        ~FinanceTracker()
        {
            financeStore.SaveTransactionData();
        }
    }
}


// Implements the IFinance interface, managing a list of Transaction objects.
// It includes functionality to add transactions, categorize them, and provide summaries (e.g., total income, total expenses, balance).
