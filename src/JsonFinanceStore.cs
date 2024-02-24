using Tracker.Interface;

namespace Tracker
{
    class JsonFinanceStore : IFinanceStorage
    {
        public JsonFinanceStore()
        { }

        void IFinanceStorage.LoadTransactionData()
        {

        }

        void IFinanceStorage.SaveTransactionData()
        { }
    }
}

// Implementes the IFinanceStorage interface,
// focusing on handling persistence by reading from and writing to a transactions.json JSON file,
// managing serialization and deserialization of Transaction objects.
