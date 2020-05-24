using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Bankprogram_lokalt
{
    class Account
    {
        private double balance;
        private String owner;
        private long accountNumber;

        public Account(String o, int n)     //Ger unika kontonummer
        {
            owner = o;
            accountNumber = long.Parse("8000" + (100000 + n));
        }

        public String getName()
        {
            return owner;
        }

        public long getAccountNumber()
        {
            return accountNumber;
        }

        public double getBalance()
        {
            return balance;
        }

        public void deposit(double amount)       //Metod för att kunna sätta in pengar
        {
            if (amount > 0)      //Krav för att sätta in pengar
            {
                balance += amount;
            }
            else
            {
                Console.WriteLine("Deposits of negative values are not allowed.\n");
            }
        }

        public void withdraw(double amount)       //Metod för att ta ut pengar
        {
            if (amount > 0 && amount <= balance)       //Krav för att ta ut pengar
            {
                balance -= amount;
            }
            else if (!(amount <= balance))
            {
                Console.WriteLine("Account overdrawn.\n");
            }
            else
            {
                Console.WriteLine("Negative values cannot be withdrawn.\n");
            }

        }
    }
}
