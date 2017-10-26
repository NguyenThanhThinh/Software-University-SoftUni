namespace _11._BankSystem.Interfaces
{
    public interface ISavingable : IBankAccount, IMoneyOperations
    {
        void AddInterest();

        decimal InterestRate { get; }
    }
}