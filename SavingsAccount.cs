using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS1
{
    internal class SavingsAccount: Account 
    {
        private const decimal MinimumBalance = 1000; //for Savings Account
        private const decimal MaximumWithdrawalAmount = 15000; //for Savings Account

        public SavingsAccount(string accountNumber, string accountHolderName, decimal initialBalance, string signature)
            : base(accountNumber, accountHolderName, initialBalance, signature)
        {

        }

        public override void Deposit(decimal amount)
        {
            base.Deposit(amount);
        }

        /*I cannot withdraw if : 
         * Withdrawal limit exceeds 
         * Balance is less than minimum balance requirement after the transaction 
         */

        public override bool Withdraw(decimal amount)
        {
            if (amount <= MaximumWithdrawalAmount && (Balance - amount) >= MinimumBalance)
            {
                return base.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Withdrawal limit exceeded or minimum balance requirement not met."); 
                return false;
            }
        }

        public override void CalculateInterest()
        {
            //10% interest 
            decimal Interest = Balance * 0.10m;
            Balance = Balance + Interest; 
            Console.WriteLine($"Interest calculated: {Interest:C}. New balance: {Balance}");
        }
    }
}
