using System;
using System.Collections.Generic;

namespace ExpenseTracker
{
    class Expense
    {
        public int ExpenseId;
        public string Category;
        public double Amount;
        public string PaymentMode;
        public DateTime ExpenseDate;

        public void AddExpense()
        {
            Console.Write("Enter Expense ID: ");
            ExpenseId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Category: ");
            Category = Console.ReadLine();

            Console.Write("Enter Amount: ");
            Amount = Convert.ToDouble(Console.ReadLine());

            if (Amount <= 0)
                throw new Exception("Amount must be greater than zero.");

            Console.Write("Enter Payment Mode: ");
            PaymentMode = Console.ReadLine();

            Console.Write("Enter Expense Date (dd/MM/yyyy): ");
            ExpenseDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }

        public void DisplayExpense()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Expense ID   : " + ExpenseId);
            Console.WriteLine("Category     : " + Category);
            Console.WriteLine("Amount       : " + Amount);
            Console.WriteLine("Payment Mode : " + PaymentMode);
            Console.WriteLine("Expense Date : " + ExpenseDate.ToString("dd/MM/yyyy"));
        }

        public void UpdateExpense()
        {
            Console.Write("Enter New Category: ");
            Category = Console.ReadLine();

            Console.Write("Enter New Amount: ");
            Amount = Convert.ToDouble(Console.ReadLine());

            if (Amount <= 0)
                throw new Exception("Amount must be greater than zero.");

            Console.Write("Enter New Payment Mode: ");
            PaymentMode = Console.ReadLine();

            Console.Write("Enter New Expense Date (dd/MM/yyyy): ");
            ExpenseDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.WriteLine("Expense Updated Successfully.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Expense> expenses = new List<Expense>();

            Console.Write("How many expenses do you want to add? ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Expense exp = new Expense();

                try
                {
                    Console.WriteLine("\nEnter Details of Expense " + (i + 1));
                    exp.AddExpense();
                    expenses.Add(exp);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input.");
                    i--;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            Console.WriteLine("\n===== Expense Details =====");

            foreach (Expense exp in expenses)
            {
                exp.DisplayExpense();
            }

            Console.Write("\nDo you want to update an expense? (Y/N): ");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "Y")
            {
                Console.Write("Enter Expense ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());

                bool found = false;

                foreach (Expense exp in expenses)
                {
                    if (exp.ExpenseId == id)
                    {
                        try
                        {
                            exp.UpdateExpense();
                            found = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Expense ID Not Found.");
                }

                Console.WriteLine("\n===== Updated Expense Details =====");

                foreach (Expense exp in expenses)
                {
                    exp.DisplayExpense();
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}