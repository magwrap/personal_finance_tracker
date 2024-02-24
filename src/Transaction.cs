using Tracker.Category;

namespace Tracker.Finance
{
    class Transaction
    {
        public Guid TransactionId { get; private set; } = Guid.NewGuid();
        public DateTime Date { get; private set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionCategory Category { get; set; }

        public Transaction(decimal amount, TransactionCategory category, string description, DateTime date = new())
        {
            Amount = amount;
            Category = category;
            Description = description;
            Date = date;
        }

    }
}


// Properties: Transaction ID (Guid), Date (DateTime), Description (string), Amount (decimal), Category (string, e.g., "Income", "Groceries", "Utilities").
// ID should use the type Guid (i.e., public Guid ID {get; set; } = Guid.NewGuid();
// Constructor initializes a transaction with the provided details.
