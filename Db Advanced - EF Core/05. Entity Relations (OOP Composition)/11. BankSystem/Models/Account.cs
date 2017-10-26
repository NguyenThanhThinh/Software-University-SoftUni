namespace _11._BankSystem.Models
{
    using Interfaces;
    public abstract class Account : IBankAccount, IMoneyOperations
    {
        private string accountNumber;
        private decimal balance;

        public int Id { get; set; }

        public string AccountNumber
        {
            get { return this.accountNumber; }
            protected set { this.accountNumber = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }

            protected set { this.balance = value; }
        }

        public void DepositMoney(string money)
        {
            decimal parsedMoney = ParseToDoubleOrReturnZero(money);
            this.Balance += parsedMoney;
        }

        public void WithdrawMoney(string money)
        {
            decimal parsedMoney = ParseToDoubleOrReturnZero(money);
            this.Balance -= parsedMoney;
        }

        private static decimal ParseToDoubleOrReturnZero(string money)
        {
            decimal parsedMoney = 0;
            bool hasMoneyParsed = decimal.TryParse(money, out parsedMoney);
            return parsedMoney;
        }
    }
}