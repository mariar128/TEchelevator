using System.Collections.Generic;

namespace BankTellerExercise
{
    public class BankCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        private List<IAccountable> accounts = new List<IAccountable>();

        public bool IsVip {
            get
            {
                decimal total = 0;
                foreach (IAccountable account in accounts)
                {
                    total += account.Balance;
                }
                return total >= 25000;
            }
        }

        public IAccountable[] GetAccounts()
        {
            return accounts.ToArray();
        }

        public void AddAccount(IAccountable newAccount)
        {
            accounts.Add(newAccount);
        }
    }
}
