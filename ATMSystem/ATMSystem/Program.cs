using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public bool IsSuspended { get; set; }

    public User(string username, string password, string accountType, decimal initialBalance)
    {
        Username = username;
        Password = password;
        AccountType = accountType;
        Balance = initialBalance;
        IsSuspended = false;
    }

}

public class Transaction
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string AccountType { get; set; }
    public string TransactionType { get; set; }

    public Transaction(decimal amount, string accountType, string transactionType)
    {
        Date = DateTime.Now;
        Amount = amount;
        AccountType = accountType;
        TransactionType = transactionType;
    }
}

public class Admin
{
    public List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public List<User> GetUsers()
    {
        return users;
    }
    public void DeleteUser(string username)
    {
        users.RemoveAll(u => u.Username == username);
    }

    public void EditUser(string username, string newPassword, string newAccountType)
    {
        var user = users.Find(u => u.Username == username);
        if (user != null)
        {
            user.Password = newPassword;
            user.AccountType = newAccountType;
        }
    }

    public void SuspendUser(string username)
    {
        var user = users.Find(u => u.Username == username);
        if (user != null)
        {
            user.IsSuspended = true;
        }
    }

    public void UnsuspendUser(string username)
    {
        var user = users.Find(u => u.Username == username);
        if (user != null)
        {
            user.IsSuspended = false;
        }
    }

    public void ViewAllUsers()
    {
        foreach (var user in users)
        {
            Console.WriteLine($"Username: {user.Username}, Account Type: {user.AccountType}, Balance: {user.Balance}, Suspended: {user.IsSuspended}");
        }
    }
}

public class ATM
{
    private List<User> users = new List<User>();
    private List<Transaction> transactions = new List<Transaction>();
    private const decimal DailyLimit = 500000;
    public ATM(List<User> userList)
    {
        users = userList;
    }
    

    public void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        var user = users.Find(u => u.Username == username && u.Password == password);
        if (user != null && !user.IsSuspended)
        {
            Console.WriteLine("Login successful!");
            UserOperations(user);
        }
        else if(user != null && user.IsSuspended)
        {
            Console.WriteLine("Your account is suspended. Please contact the bank for assistance.");
        }
        else
        {
            Console.WriteLine("Invalid credentials or account suspended.");
        }
    }

    public void UserOperations(User user)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Select operation: \n1. Deposit \n2. Withdraw \n3. Transfer \n4. Check Balance \n5. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Deposit(user);
                    break;
                case "2":
                    Withdraw(user);
                    break;
                case "3":
                    Transfer(user);
                    break;
                case "4":
                    checkBalance(user);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public void checkBalance(User user)
    {
        Console.WriteLine($"Your balance is: {user.Balance}");
    }
    public void Deposit(User user)
    {
        Console.Write("Enter amount to deposit: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        user.Balance += amount;
        transactions.Add(new Transaction(amount, user.AccountType, "Deposit"));
        Console.WriteLine($"Deposited {amount} to {user.Username}'s account. \nBook Balance: {user.Balance}");
    }

    public void Withdraw(User user)
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        if (amount <= DailyLimit && user.Balance >= amount)
        {
            user.Balance -= amount;
            transactions.Add(new Transaction(amount, user.AccountType, "Withdrawal"));
            Console.WriteLine($"Withdrew {amount} from {user.Username}'s account. \nBook Balance: {user.Balance}");
        }
        else
        {
            Console.WriteLine("Withdrawal exceeds daily limit or insufficient funds.");
        }
    }

    public void Transfer(User fromUser)
    {
        Console.Write("Enter the username to transfer to: ");
        string toUsername = Console.ReadLine();
        User toUser = users.Find(u => u.Username == toUsername);
        Console.Write("Enter amount to transfer: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        if (amount <= DailyLimit && fromUser.Balance >= amount)
        {
            fromUser.Balance -= amount;
            toUser.Balance += amount;
            transactions.Add(new Transaction(amount, fromUser.AccountType, "Transfer"));
            Console.WriteLine($"Transferred {amount} from {fromUser.Username} to {toUser.Username}.");
        }
        else
        {
            Console.WriteLine("Transfer exceeds daily limit or insufficient funds.");
        }
    }

    public void ViewTransactionLogs()
    {
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"Date: {transaction.Date}, Amount: {transaction.Amount}, Account Type: {transaction.AccountType}, Transaction Type: {transaction.TransactionType}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Initialize ATM and Admin
        Admin admin = new Admin();
        ATM atm = new ATM(admin.GetUsers());

        // Sample users
        User user1 = new User("Admin", "123", "Savings", 10000);
        User user2 = new User("smith", "456", "Fixed Deposit", 20000);
        admin.AddUser(user1);
        admin.AddUser(user2);

        // atm.users = admin.GetUsers();
        // Admin operations
        admin.ViewAllUsers();

        // User login
        atm.Login();
    }
}
