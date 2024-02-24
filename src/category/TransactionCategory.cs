using Tracker.Interface;
namespace Tracker.Category
{
    class TransactionCategory : ITransactionCategory
    {
        public string CategoryName { get; set; }


        public TransactionCategory(string categoryName)
        {
            CategoryName = categoryName;
        }

    }
}
