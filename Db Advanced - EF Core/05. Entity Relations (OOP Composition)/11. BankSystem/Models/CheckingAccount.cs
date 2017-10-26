namespace _11._BankSystem.Models
{
    using Interfaces;

    public class CheckingAccount : Account, ICheckingable
    {
        public decimal Fee { get; protected set; }

        public void DeductFee()
        {
            this.Balance -= this.Fee;
        }
    }
}