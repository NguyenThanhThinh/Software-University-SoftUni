namespace _11._BankSystem.Interfaces
{
    public interface ICheckingable : IBankAccount, IMoneyOperations
    {
        void DeductFee();

        decimal Fee { get; }
    }
}