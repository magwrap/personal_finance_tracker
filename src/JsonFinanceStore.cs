using Tracker.Interface;
using Tracker.Finance;
using System.Text.Json;

namespace Tracker
{
    class JsonFinanceStore : IFinanceStorage
    {
        private List<Transaction> _storedTransactions = new();
        private const string FILE_PATH = "./transactions.json";


        List<Transaction> IFinanceStorage.LoadTransactionData()
        {
            TryToGetJSON<List<Transaction>>(FILE_PATH, ref _storedTransactions);
            return _storedTransactions;
        }

        void IFinanceStorage.SaveTransactionData()
        {
            var jsonData = JsonSerializer.Serialize(_storedTransactions);
            TryToSaveToJSON<List<Transaction>>(FILE_PATH, _storedTransactions);
        }

        private static void TryToGetJSON<T>(string filePath, ref T entity)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    entity = JsonSerializer.Deserialize<T>(jsonString)!;
                }
                else
                {
                    Console.WriteLine("File don't exist");
                }

            }
            catch (Exception err)
            {
                DisplayErrorMsg(filePath, err.Message, "trying to get");
            }
        }

        private static void TryToSaveToJSON<T>(string filePath, T _data)
        {
            try
            {
                using (FileStream file = File.OpenWrite(filePath))
                {
                    JsonSerializer.Serialize<T>(file, _data);
                }
            }
            catch (Exception err)
            {
                DisplayErrorMsg(filePath, err.Message, "trying to save");
            }
        }

        private static void DisplayErrorMsg(string path, string errorMessage, string extra = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"There was a problem getting a file: {path}\n{errorMessage}\n{extra}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ResetColor();
        }
    }
}
