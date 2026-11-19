using System;

namespace StudentAdmission
{
    // Student class
    class Student
    {
        // Private data members
        private int studentId;
        private string studentName;
        private string course;
        private double fees;

        // Default Constructor
        public Student()
        {
            studentId = 0;
            studentName = "";
            course = "";
            fees = 0;
        }

        // Parameterized Constructor
        public Student(int id, string name, string c, double f)
        {
            studentId = id;
            studentName = name;
            course = c;
            fees = f;
        }

        // Method to display student details
        public void Display()
        {
            Console.WriteLine("\n----- Student Admission Details -----");
            Console.WriteLine("Student ID   : " + studentId);
            Console.WriteLine("Student Name : " + studentName);
            Console.WriteLine("Course       : " + course);
            Console.WriteLine("Fees         : " + fees);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int id;
            string name;
            string course;
            double fees;

            Console.Write("Enter Student ID: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Course Name: ");
            course = Console.ReadLine();

            Console.Write("Enter Admission Fees: ");
            fees = Convert.ToDouble(Console.ReadLine());

            // Creating Object
            Student s1 = new Student(id, name, course, fees);

            // Display Details
            s1.Display();

            Console.ReadLine();
        }
    }
}