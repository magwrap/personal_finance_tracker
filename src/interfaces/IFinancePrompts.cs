namespace Tracker.Finance
{
    interface IFinancePrompts
    {
        void AddTransactionWizard();
        void AskWhichTransactionToView();
        void AskWhichCategoryToView();
        void AskUserToCategorizeTransaction(Guid transactionId);
    }

}
