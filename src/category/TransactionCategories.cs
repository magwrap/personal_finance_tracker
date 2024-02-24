using Tracker.Interface;

namespace Tracker.Category
{
    static class TransactionCategories
    {
        private static Dictionary<string, TransactionCategory> _availableCategories = new()
        {
            ["Rent"] = new TransactionCategory("Rent"),
            ["HouseKeep"] = new TransactionCategory("HouseKeep"),
            ["EatingOut"] = new TransactionCategory("EatingOut"),
            ["Food"] = new TransactionCategory("Food"),
            ["Utilities"] = new TransactionCategory("Utilities"),
            ["unassigned"] = new TransactionCategory("unassigned"),
        };

        public static Dictionary<string, TransactionCategory> Categories
        {
            get
            {
                return _availableCategories;
            }
        }

        public static void AddCategory(TransactionCategory transactionCategory)
        {
            if (TransactionCategories.Categories.Values.Contains(transactionCategory))
            {
                Console.WriteLine("This category already exists!");
            }
            else
            {
                TransactionCategories.Categories.Add(transactionCategory.CategoryName, transactionCategory);
                Console.WriteLine($"Category: '{transactionCategory}' has been successfully added!");
            }
        }
        public static void RemoveCategory(TransactionCategory category)
        {
            if (!TransactionCategories.Categories.Values.Contains(category))
            {
                Console.WriteLine("This category does not exists!");
            }
            else
            {
                TransactionCategories.Categories.Remove(category.CategoryName);
                Console.WriteLine($"Category: '{category}' has been deleted!");
            }
        }

        public static void ViewCategories()
        {
            Console.WriteLine("Categories: \n");

            foreach ((string categoryName, TransactionCategory category) in _availableCategories)
            {
                Console.WriteLine(categoryName);
            }
        }

        public static string[] GetCategories()
        {
            string[] categories = new string[_availableCategories.Count];

            int i = 0;
            foreach ((string categoryName, TransactionCategory category) in _availableCategories)
            {
                categories[i] = categoryName;
                i++;
            }
            return categories;
        }

        public static TransactionCategory GetCategory(string categoryName)
        {
            return Categories[categoryName];
        }

    }
}
