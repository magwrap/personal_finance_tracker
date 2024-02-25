using Tracker.Interface;
using Tracker.Finance;
using Tracker.Category;

namespace Tracker
{
    class Program
    {
        IFinance financeTracker = new FinanceTracker();

        public static void Main()
        {
            Program program = new();
        }

        public Program()
        {
            Console.WriteLine("Welcome in your personal finance tracker!");

            string[] options = new string[] {
                "1. Add Transaction",
                "2. View all Transactions",
                "3. Add category",
                "4. View all categories",
                "5. Add/change category to a transaction",
                "6. Quit and Save."
            };

            while (true)
            {
                int userChoice = Utils.GetUserOption(options, "DASHBOARD");

                switch (userChoice)
                {
                    case 0:
                        AddTransactionWizard();
                        break;
                    case 1:
                        ListTransactions();
                        break;
                    case 2:
                        AskToAddCategory();
                        break;
                    case 3:
                        TransactionCategories.ViewCategories();
                        break;
                    case 4:
                        ChangeCategory();
                        break;
                    case 5:
                        Quit();
                        return;
                    default:
                        Console.WriteLine("something is not working...");
                        break;
                }
            }
        }


        void AddTransactionWizard()
        {
            decimal amount;
            DateTime date;


            Decimal.TryParse(
              Utils.GetInput("Insert Amount:"),
              out amount
            );

            DateTime.TryParse(
              Utils.GetInput("Insert Date:"),
              out date
            );

            string desc = Utils.GetInput("Insert Description:");

            Transaction transaction = new Transaction(
                amount,
                TransactionCategories.Categories["unassigned"],
                desc,
                date
            );

            financeTracker.AddTransaction(transaction);
            AskUserToCategorizeTransaction(transaction.TransactionId);

        }

        void AskUserToCategorizeTransaction(Guid transactionId)
        {
            Console.WriteLine("Do you want to assign/change the category to this transaction?");
            int option = Utils.GetUserOption(new string[] { "yes", "no" });
            if (option == 0)
            {
                TransactionCategory category = ChooseCategory();

                financeTracker.CategorizeTransaction(
                    transactionId,
                    category
                );
            }

        }

        void AskToAddCategory()
        {
            Console.WriteLine("Do you want to add new category?");
            int option = Utils.GetUserOption(new string[] { "yes", "no" });
            if (option == 0)
            {
                string categoryName = Utils.GetInput("Insert a name of category:");
                TransactionCategory category = new TransactionCategory(categoryName);
                TransactionCategories.AddCategory(category);
            }
        }

        void ChangeCategory()
        {
            Transaction selected = financeTracker.SelectTransaction();
            Console.WriteLine("You have selected:");
            IFinance.ViewTransaction(selected);
            AskUserToCategorizeTransaction(selected.TransactionId);

        }

        void ListTransactions()
        {
            Console.WriteLine("Do you want to filter list of transactions by category?");
            int option = Utils.GetUserOption(new string[] { "yes", "no" });
            TransactionCategory? category = null;
            if (option == 0)
            {
                category = ChooseCategory();
            }

            financeTracker.ViewTransactions(category);
        }

        TransactionCategory ChooseCategory()
        {
            string[] categories = TransactionCategories.GetCategories();
            int category = Utils.GetUserOption(categories);

            Console.WriteLine($"You chose: {categories[category]}");
            return TransactionCategories.GetCategory(categories[category]);

        }

        void Quit()
        {
            financeTracker.SaveTransactionData();
        }

    }
}


