using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS1
{
    internal class IslamicAccount : Account 
    {
        private const decimal MinimumBalance = 200;
        private const decimal MaximumWithdrawalAmount = 10000;

        public IslamicAccount(string accountNumber, string accountHolderName, decimal initialBalance, string signature)
            : base(accountNumber, accountHolderName, initialBalance, signature)
        {
        }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }

            Balance += amount;
            Console.WriteLine($"Deposited: {amount:C}. New balance: {Balance}");
        }

        /*I cannot withdraw if : 
         * Withdrawal limit exceeds 
         * Balance is less than minimum balance requirement after the transaction 
         */


        /*Argument exception when one of the arguments provided is not valid 
         * Unsupported Op exception when invoked method is not supported*/

        public override bool Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            if (amount > MaximumWithdrawalAmount || (Balance - amount) < MinimumBalance)
            {
                throw new UnsupportedOperationException("Withdrawal limit exceeded or minimum balance requirement not met.");
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawn: {amount:C}. New balance: {Balance}");
            return true;
        }


        public override void CalculateInterest()
        {
            throw new UnsupportedOperationException("Islam prohibits Interest.");
        }
    }
}
