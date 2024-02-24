using Tracker.Interface;

namespace Tracker.Category
{
    static class TransactionCategories
    {
        private static List<TransactionCategory> _availableCategories = new()
        {
          new TransactionCategory("Rent"),
          new TransactionCategory("HouseKeep"),
          new TransactionCategory("EatingOut"),
          new TransactionCategory("Food"),
          new TransactionCategory("Utilities"),
    };

        public static List<TransactionCategory> Categories
        {
            get
            {
                return _availableCategories;
            }
        }

        public static void AddCategory(TransactionCategory transactionCategory)
        {
            if (TransactionCategories.Categories.Contains(transactionCategory))
            {
                Console.WriteLine("This category already exists!");
            }
            else
            {
                TransactionCategories.Categories.Add(transactionCategory);
                Console.WriteLine($"Category: '{transactionCategory}' has been successfully added!");
            }
        }
        public static void RemoveCategory(TransactionCategory category)
        {
            if (!TransactionCategories.Categories.Contains(category))
            {
                Console.WriteLine("This category does not exists!");
            }
            else
            {
                TransactionCategories.Categories.Remove(category);
                Console.WriteLine($"Category: '{category}' has been deleted!");
            }
        }

        public static void ViewCategories()
        {
            Console.WriteLine("Categories: \n");

            foreach (TransactionCategory category in _availableCategories)
            {
                Console.WriteLine(category);
            }
        }

    }
}
