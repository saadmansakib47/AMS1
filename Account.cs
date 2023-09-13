using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS1
{
    public class Account
    {
        protected string AccountNumber { get ; set; } 
        protected string AccountHolderName { get ; set; } 
        protected decimal Balance { get ; set; } 
        protected string Signature { get ; set; } 

        public Account(string accountNumber, string accountHolderName, decimal balance, string signature)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
            Signature = signature;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance = Balance + amount;
            Console.WriteLine($"Deposited: {amount:C}. New balance: {Balance:C}");
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance = Balance - amount;
                Console.WriteLine($"Withdrawn: {amount:C}. New balance: {Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient Balance.");
                return false;
            }
        }

        public virtual void CalculateInterest()
        {
           
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}") ;
            Console.WriteLine($"Account Holder Name: {AccountHolderName}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }
}
