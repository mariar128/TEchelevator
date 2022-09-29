namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {

        }

        public override decimal Withdraw (decimal amountToWithdraw)
        {
            if (Balance - amountToWithdraw < 150)
            { return base.Withdraw(amountToWithdraw + 2); }
            
        if(amountToWithdraw > Balance )
            {
                return base.Balance;
            }
            return base.Balance;

            } 
        }
   

    }
