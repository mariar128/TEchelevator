namespace BankTellerExercise
{
    public class CreditCardAccount : IAccountable
    {
        public decimal Debt { get; private set; }
        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; }
        public decimal Balance
        {
            get { return -Debt; }
        }

        public CreditCardAccount(string accountHolder, string accountNumber)
        {
            AccountHolderName = accountHolder;
            AccountNumber = accountNumber;
        }

        public decimal Pay(decimal amountToPay)
        {
            Debt -= amountToPay;
            return Debt;
        }

        public decimal Charge(decimal amountToCharge)
        {
            Debt += amountToCharge;
            return Debt;
        }
    }
}
