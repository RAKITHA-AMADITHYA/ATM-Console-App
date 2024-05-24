using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{
    string cardId;
    int pin;
    string firstName;
    string lastName;
    decimal balance;

    public CardHolder(string cardId, int pin, string firstName, string lastName, decimal balance)
    {
        this.cardId = cardId;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getCardId()
    {
        return cardId;
    }

    public void setCardId(string cardId)
    {
        this.cardId = cardId;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public void setFirstName(string firstName)
    {
        this.firstName = firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public void setLastName(string lastName)
    {
        this.lastName = lastName;
    }

    public int getPin()
    {
        return pin;
    }

    public void setPin(string pin)
    {
        this.pin = int.Parse(pin);
    }

    public decimal getBalance()
    {
        return balance;
    }

    public void setBalance(decimal balance)
    {
        this.balance = balance;
    }

    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Please choose one of the following options ....");
            Console.WriteLine("[1]. Deposit");
            Console.WriteLine("[2]. Withdraw");
            Console.WriteLine("[3]. Show Balance");
            Console.WriteLine("[4]. Exit");
        }

        void Deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much LKR would you like to deposit?");

            try
            {
                decimal deposit = decimal.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }

        void Withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much LKR would you like to withdraw?");

            try
            {
                decimal withdrawal = decimal.Parse(Console.ReadLine());

                if (currentUser.getBalance() >= withdrawal)
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("Withdrawal successful. Your new balance is: " + currentUser.getBalance());
                }
                else
                {
                    Console.WriteLine("Insufficient balance :(");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }

        void ShowBalance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        // Main program logic
        List<CardHolder> list = new List<CardHolder>();
        list.Add(new CardHolder("123456789", 1234, "John", "Doe", 1000m));
        list.Add(new CardHolder("987654321", 4321, "Jane", "Smith", 1500m));
        list.Add(new CardHolder("112233445", 2233, "Alice", "Johnson", 1200m));
        list.Add(new CardHolder("556677889", 5566, "Bob", "Brown", 2000m));
        list.Add(new CardHolder("998877665", 9988, "Charlie", "Davis", 1800m));

        // Prompt user
        Console.WriteLine("Welcome to Simple ATM");
        Console.WriteLine("Please insert your debit card:");

        string debitcardNum = "";
        CardHolder currentUser = null;

        while (true)
        {
            try
            {
                debitcardNum = Console.ReadLine();
                currentUser = list.FirstOrDefault(a => a.getCardId() == debitcardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card is not recognized. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Card is not recognized. Please try again.");
            }
        }

        Console.WriteLine("Please enter your pin:");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Pin. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again.");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;

        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                option = 0;
            }

            switch (option)
            {
                case 1:
                    Deposit(currentUser);
                    break;
                case 2:
                    Withdraw(currentUser);
                    break;
                case 3:
                    ShowBalance(currentUser);
                    break;
                case 4:
                    Console.WriteLine("Thank you! Have a nice day.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (option != 4);
    }
}
