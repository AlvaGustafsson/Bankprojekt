using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Bankprogram_lokalt
{
    class Program
    {
        static List<Account> accounts = new List<Account>();

        static void Main(string[] args)
        {
            String choice;
            int numberOfAccounts = 0;

            while (true)
            {
                printMenu();     //Skriver ut de olika valen
                choice = Console.ReadLine();

                if (choice == "1")    //Skapar nytt konto
                {
                    Console.WriteLine("Enter owner name: ");
                    String name = Console.ReadLine();
                    Account a = new Account(name, numberOfAccounts);
                    accounts.Add(a);

                    Console.WriteLine("Account created with account number: " + accounts[accounts.Count -1].getAccountNumber() + "\n");

                    numberOfAccounts++;
                }
                else if (choice == "2")      //Tar bort konto
                {
                    Console.WriteLine("Enter account number: ");
                    long nr = long.Parse(Console.ReadLine());

                    int index = search(nr);
                    if (index != -1)
                    {
                        accounts.RemoveAt(index);
                        Console.Write("\n");
                    }
                    else
                    {
                        Console.WriteLine("\nAccount not found.\n");
                    }

                }
                else if (choice == "3")       //Sätter in pengar
                {
                    Console.WriteLine("Enter account number: ");
                    long nr = long.Parse(Console.ReadLine());

                    int index = search(nr);
                    if (index != -1)     //Returneras -1 av search är det fel.
                    {
                        Console.WriteLine("Enter amount: ");
                        double amount = double.Parse(Console.ReadLine());
                        Console.Write("\n");

                        accounts[index].deposit(amount);
                    }
                    else
                    {
                        Console.WriteLine("\nAccount not found.\n");
                    }

                }
                else if (choice == "4")       //Tar ut pengar
                {
                    Console.WriteLine("Enter account number: ");
                    long nr = long.Parse(Console.ReadLine());

                    int index = search(nr);
                    if (index != -1)
                    {
                        Console.WriteLine("Enter amount: ");
                        double amount = double.Parse(Console.ReadLine());
                        Console.Write("\n");

                        accounts[index].withdraw(amount);
                    }
                    else
                    {
                        Console.WriteLine("\nAccount not found.\n");

                    }
                   
                }
                else if (choice == "5")       //Utför transaktioner
                {
                    Console.WriteLine("Enter sender number: ");
                    long sender = long.Parse(Console.ReadLine());

                    Console.WriteLine("Enter reciever number: ");
                    long reciever = long.Parse(Console.ReadLine());

                    int senderIndex = search(sender);
                    int recieverIndex = search(reciever);
                    if (senderIndex != -1 || recieverIndex != -1)
                    {
                        Console.WriteLine("Enter amount: ");
                        double amount = double.Parse(Console.ReadLine());
                        Console.Write("\n");

                        accounts[search(sender)].withdraw(amount);
                        accounts[search(reciever)].deposit(amount);
                    }
                    else
                    {
                        Console.WriteLine("\nAccount not found.\n");

                    }
                }
                else if (choice == "6")       //Söker efter konto via namn
                {
                    bool found = false;

                    Console.WriteLine("Enter owner name: ");
                    String name = Console.ReadLine();

                    for (int i = 0; i < accounts.Count; i++)
                    {
                        if (accounts[i].getName() == name)
                        {
                            Console.WriteLine("Ägare: " + accounts[i].getName() + ", kontonummer: " + accounts[i].getAccountNumber() + ", saldo: " + accounts[i].getBalance() + "\n");
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("\nThis person does not have an account.\n");
                    }
                }
                else if (choice == "7")     //Skriver ut alla konton sorterade efter namn
                {
                    for (int i = 0; i < accounts.Count - 1; i++)
                    {
                        for (int j = 0; j < accounts.Count - 1; j++)
                        {
                            if (accounts[j].getName().CompareTo(accounts[j + 1].getName()) > 0)
                            {
                                Account temp = accounts[j];
                                accounts[j] = accounts[j + 1];
                                accounts[j + 1] = temp;
                            }
                        }
                    }

                    for (int i = 0; i < accounts.Count; i++)
                    {
                        Console.WriteLine("Ägare: " + accounts[i].getName() + ", kontonummer: " + accounts[i].getAccountNumber() + ", saldo: " + accounts[i].getBalance());
                    }
                    Console.Write("\n");
                }
                else if (choice == "8")
                {
                    Console.WriteLine("\nExiting...");
                    return;
                }
            }
        }

        static void printMenu()     //Metod som skriver ut menyvalen
        {
            Console.Write("Welcome to Alva's banking program: \n" +
                "1. Add account\n" +
                "2. Remove account\n" +
                "3. Deposit\n" +
                "4. Withdraw\n" +
                "5. Transfer\n" +
                "6. Search for account by name\n" +
                "7. Print all accounts sorted by name\n" +
                "8. Exit\n" +
                "Enter choice: ");
        }

        static int search (long nr)      //Metod som returnerar ett kontos plats i listan. Tar ett kontonummer som argument
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].getAccountNumber() == nr)
                    return i;
            }

            return -1;   //Om misslyckas
        }
    }
}
