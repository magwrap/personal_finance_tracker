using Tracker.Finance;
namespace Tracker.Interface
{
    interface IFinanceStorage
    {
        public List<Transaction> LoadTransactionData();
        public void SaveTransactionData();

    }
}
