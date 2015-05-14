using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// <summary> 
    /// Bank Account demo class. 
    /// </summary> 
    public class BankAccount
    {
        private string m_customerName;
        private double m_balance;
        private bool m_frozen = false;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";
        public const string AccountIsFrozen = "Account frozen";

        /*private BankAccount()
        {
        }*/

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception(AccountIsFrozen);
            }

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // intentionally incorrect code
        }

        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        public void FreezeAccount()
        {
            m_frozen = true;
        }

        public void UnfreezeAccount()
        {
            m_frozen = false;
        }
    }
}
