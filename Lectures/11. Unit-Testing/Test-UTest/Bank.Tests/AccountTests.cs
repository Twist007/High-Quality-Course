namespace Bank.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTransferFunds()
        {
            var account= new Account();
            account.TransferFunds(account,100);
        }

    }
}