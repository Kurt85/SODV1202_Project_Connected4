using System;
namespace ConsoleApp96
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Balance { get; protected set; } = 0.0;
        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public virtual void Withdraw(double amount)
        {
            Balance -= amount;
        }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}\nBalance: {Balance}";
        }
    }

    public class SavingsAccount : Account
    {
        public double interestRate { get; set; }
        public void MonthEnd()
        {
            Balance += (Balance * interestRate / 100);
        }
    }

    public class ChequingAccount : Account
    {
        public double MonthlyMaintenanceFees { get; set; }
        public double OverTransectionFees { get; set; }
        public int CurrentFreeTransectionCount { get; set; }
        private int _FreeMonthlyTotalTransectionCount { get; set; }

        public ChequingAccount(int id, string name, double maintenanceFees, int freeTransectionCount, double overTransectionFees)
        {
            ID = id;
            Name = name;
            MonthlyMaintenanceFees = maintenanceFees;
            CurrentFreeTransectionCount = freeTransectionCount;
            _FreeMonthlyTotalTransectionCount = CurrentFreeTransectionCount;
            OverTransectionFees = overTransectionFees;
        }

        public void MonthEnd()
        {

            Balance -= MonthlyMaintenanceFees;
            if (CurrentFreeTransectionCount < 0)
                Balance += CurrentFreeTransectionCount * OverTransectionFees;
            CurrentFreeTransectionCount = _FreeMonthlyTotalTransectionCount;
        }
        public override void Withdraw(double amount)
        {
            CurrentFreeTransectionCount--;
            //base.Withdraw(amount);
            Balance -= amount;
        }


    }

    public class Program
    {
        public static void Main(string[] args)
        {
            SavingsAccount sa = new SavingsAccount
            {
                ID = 12345,
                Name = "Alex Whatmore",
                interestRate = 1.5,
            };
            sa.Deposit(1000);
            sa.MonthEnd();
            Console.WriteLine(sa);

            ChequingAccount ca = new ChequingAccount(12346, "Susan Harper", 5.0, 5, 1.5);
            ca.Deposit(1000);
            ca.Withdraw(100);
            ca.Withdraw(100);
            ca.Withdraw(100);
            ca.Withdraw(100);
            ca.Withdraw(100);
            ca.Withdraw(100);
            ca.Withdraw(100);
            ca.MonthEnd();
            Console.WriteLine(ca);

            ca.Withdraw(100);
            Console.WriteLine(ca);

        }
    }


}