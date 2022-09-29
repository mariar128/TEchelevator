using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    class BankCustomer
    { 
        public string Name { get; set; }
    public string Address { get; set; }
     
    public string PhoneNumber { get; set; }

    private List<IAccountable> accountsList { get; set; } = new List<IAccountable>();

    public bool IsVip 
        { 
            get
            {
                decimal runningTotal = 0;
                foreach (IAccountable account in accountsList)
                {
                    runningTotal += account.Balance;
                }
                if(runningTotal >= 25000)
                { 
                    return true;
                }
                return false;
            }
        }
        public void AddAccount(IAccountable newAccount)
        {
            accountsList.Add(newAccount);
        }
        public IAccountable[] GetAccounts()
        {
            IAccountable[] newStuff = accountsList.ToArray();
            return newStuff;
        }
    }
}

