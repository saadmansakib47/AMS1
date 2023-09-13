using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AMS1;

namespace AMS1Test
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void TestSavingsAccountWithdrawalWithinLimit()
        {
            SavingsAccount savingsAccount = new SavingsAccount("A12345", "Saadman Sakib", 4747, "sign1");
            bool result = savingsAccount.Withdraw(3747);
            Assert.IsTrue(result);
            Assert.AreEqual(1000, savingsAccount.Balance);
        }
        [TestMethod]
        public void TestSavingAccountWithdrawalCrossesMinimumBalanceLimit()
        {
            SavingsAccount savingsAccount = new SavingsAccount("A23456", "Abid Shahriar", 5000, "sign2");
            bool result = savingsAccount.Withdraw(4001);
            Assert.IsFalse(result);
            Assert.AreEqual(5000, savingsAccount.Balance);
        }
        [TestMethod]
        public void TestSavingAccountWithdrawalCrossesUpperLimit()
        {
            SavingsAccount savingsAccount = new SavingsAccount("A34567", "Nusrat Siddique", 50000, "sign3");
            bool result = savingsAccount.Withdraw(15001);
            Assert.IsFalse(result);
            Assert.AreEqual(50000, savingsAccount.Balance);
        }

        [TestMethod]
        public void TestCurrentAccountWithdrawalWithinLimit()
        {
            CurrentAccount currentAccount = new CurrentAccount("B12345", "Abu Noman Haider", 3500, "sign4");
            bool result = currentAccount.Withdraw(3000);
            Assert.IsTrue(result);
            Assert.AreEqual(500, currentAccount.Balance);
        }
        [TestMethod]
        public void TestCurrentAccountWithdrawalCrossesLimit()
        {
            CurrentAccount currentAccount = new CurrentAccount("B23456", "Irfan Hakim", 3500, "sign5");
            bool result = currentAccount.Withdraw(3001);
            Assert.IsFalse(result);
            Assert.AreEqual(3500, currentAccount.Balance);
        }
        [TestMethod]
        public void TestSavingAccountCalculateInterest()
        {
            SavingsAccount savingsAccount = new SavingsAccount("A12345", "Saadman Sakib", 5000, "sign1");
            savingsAccount.CalculateInterest();
            Assert.AreEqual(5500, savingsAccount.Balance);
        }
        [TestMethod]
        public void TestCurrentAccountCalculateInterest()
        {
            CurrentAccount currentAccount = new CurrentAccount("B12345", "Abu Noman Haider", 3500, "sign4");
            currentAccount.CalculateInterest();
            Assert.AreEqual(3780, currentAccount.Balance);
        }

        [TestMethod]
        public void TestIslamicAccountWithdrawalWithinLimit()
        {
            IslamicAccount islamicAccount = new IslamicAccount("I12345", "Yasir Raiyan", 2000, "sign5");
            bool result = islamicAccount.Withdraw(1800);
            Assert.IsTrue(result);
            Assert.AreEqual(200, islamicAccount.Balance);
        }

        [TestMethod]
        public void TestIslamicAccountWithdrawalCrossesLimit()
        {
            IslamicAccount islamicAccount = new IslamicAccount("I23456", "Mainul Hasan", 3000, "sign6");
            Assert.ThrowsException<UnsupportedOperationException>(() => islamicAccount.Withdraw(2801));
        }

        [TestMethod]
        public void TestIslamicAccountCalculateInterestThrowsException()
        {
            IslamicAccount islamicAccount = new IslamicAccount("I34567", "Khalid Hassan", 5000, "sign7");
            Assert.ThrowsException<UnsupportedOperationException>(() => islamicAccount.CalculateInterest());
        }
    }
}