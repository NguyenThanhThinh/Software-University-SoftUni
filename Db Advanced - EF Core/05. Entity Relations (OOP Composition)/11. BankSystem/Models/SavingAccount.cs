namespace _11._BankSystem.Models
{
    using Interfaces;

    public class SavingAccount : Account, ISavingable
    {
        public decimal InterestRate { get; protected set; }

        public void AddInterest()
        {
            this.Balance += this.Balance * this.InterestRate;
        }
    }
}