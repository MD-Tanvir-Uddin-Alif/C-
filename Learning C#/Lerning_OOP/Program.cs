using System;

namespace Name
{
    public class BankAccount
    {
        private string accountHolderName;
        private string accountNumber;
        private int balance;

        public BankAccount(string accountHolderName, int balance)
        {
            this.accountHolderName = accountHolderName;
            accountNumber = "ACC" + new Random().Next(1000, 9999).ToString();

            if (balance > 0)
            {
                this.balance = balance;
            }
            else
            {
                this.balance = 0;
            }

        }

        public string AccountHolderName
        {
            get { return accountHolderName; }
            private set { accountHolderName = value; }
        }

        public int Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public void Deposite(int ammount)
        {

            if (ammount > 0)
            {
                balance += ammount;
                Console.WriteLine($"{ammount} is deposited in account No {AccountNumber} and total balance is {Balance}");
            }
            else Console.WriteLine("ammpunt should be a positive number");
        }

        public void Withdrawl(int ammount)
        {
            if (ammount < balance && ammount > 0)
            {
                balance -= ammount;
                Console.Write($"{ammount} is withdrawl from account No {AccountNumber} and total balance is {Balance}");
            } else {
                Console.WriteLine("insifient balance");
            }
        }

        public void Show_status()
        {
            Console.WriteLine($"Accoutn Holder name is {AccountHolderName}");
            Console.WriteLine($"Account number is {AccountNumber}");
            Console.WriteLine($"Total balance is {Balance}");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter you name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the initial ammount");
            int ammount = int.Parse(Console.ReadLine());

            BankAccount user1 = new BankAccount(name, ammount);

            Console.WriteLine("Enter the ammount you want to deposite");
            int money = int.Parse(Console.ReadLine());

            user1.Deposite(money);

            Console.WriteLine("Enter the ammount you want to withdrawl");
            int wmoney = int.Parse(Console.ReadLine());

            user1.Withdrawl(wmoney);

            user1.Show_status();
            
        }
    }
}