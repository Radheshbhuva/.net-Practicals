using System;
using System.Collections.Generic;

namespace ExpenseTracker
{
    class expense
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

            Console.Write("Enter Expense Category: ");
            Category = Console.ReadLine();

            Console.Write("Enter Expense Amount: ");
            Amount = Convert.ToDouble(Console.ReadLine());

            if (Amount <= 0)
            {
                throw new Exception("Expense Amount Must be Greater than Zero");
            }

            Console.Write("Enter Payment Mode: ");
            PaymentMode = Console.ReadLine();

            Console.Write("Enter Expense Date (dd/MM/yyyy): ");
            ExpenseDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }

        public void DisplayExpense()
        {
            Console.WriteLine("\n------------- Expense Details ----------------");
            Console.WriteLine("Expense ID       : " + ExpenseId);
            Console.WriteLine("Category         : " + Category);
            Console.WriteLine("Amount           : " + Amount);
            Console.WriteLine("Payment Mode     : " + PaymentMode);
            Console.WriteLine("Expense Date     : " + ExpenseDate.ToString("dd/MM/yyyy"));
        }

        public void UpdateExpense()
        {
            Console.Write("\nEnter Expense ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id == ExpenseId)
            {
                Console.Write("Enter New Category: ");
                Category = Console.ReadLine();

                Console.Write("Enter New Amount: ");
                Amount = Convert.ToDouble(Console.ReadLine());

                if (Amount <= 0)
                {
                    throw new Exception("Expense Amount Must be Greater than Zero");
                }

                Console.Write("Enter New Payment Mode: ");
                PaymentMode = Console.ReadLine();

                Console.Write("Enter New Expense Date (dd/MM/yyyy): ");
                ExpenseDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.WriteLine("Expense Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Expense ID Not Found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<expense> expenses = new List<expense>();

            Console.Write("How many expenses do you want to add? ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                expense exp = new expense();

                try
                {
                    Console.WriteLine("\nEnter Details of Expense " + (i + 1));
                    exp.AddExpense();
                    expenses.Add(exp);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input! Please Enter Correct Data.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\n========== All Expense Details ==========");

            foreach (expense exp in expenses)
            {
                exp.DisplayExpense();
            }

            Console.Write("\nDo you want to update an expense? (Y/N): ");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "Y")
            {
                foreach (expense exp in expenses)
                {
                    try
                    {
                        exp.UpdateExpense();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine("\n===== Updated Expense Details =====");

                foreach (expense exp in expenses)
                {
                    exp.DisplayExpense();
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}