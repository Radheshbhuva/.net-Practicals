using System;

namespace Practical_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();

            s1.AcceptDetails();
            s1.CheckScholarshipEligibility();
            s1.CheckAdmissionEligibility();
            s1.DisplayDetails();

            Console.ReadKey();
        }

        class Student
        {
            public int AdmissionNumber;
            public int EnrollmentNumber;
            public string StudentName;
            public string Course;
            public string Branch;
            public int Semester;
            public string HSCStream;
            public double Percentage;
            private double Fees;
            private bool IsScholarshipEligible;
            private bool IsAdmissionEligible;
            private const double ScholarshipRate = 0.30;
            public Student()
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("              STUDENT ADMISSION SYSTEM");
                Console.WriteLine("---------------------------------------------------");
                Course = "Computer Engineering";
                Semester = 5;

                Console.WriteLine("Student object Created Successfully....");
                Console.WriteLine();
            }
            public void AcceptDetails()
            {
                Console.Write("Enter Admission/GR Number : ");
                AdmissionNumber = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Enrollment Number : ");
                EnrollmentNumber = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student Name : ");
                StudentName = Console.ReadLine();

                Console.Write("Enter HSC Stream (Science/Commerce/Arts) : ");
                HSCStream = Console.ReadLine();

                Console.Write("Enter Percentage : ");
                Percentage = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Course : ");
                Course = Console.ReadLine();

                Console.Write("Enter Branch : ");
                Branch = Console.ReadLine();

                Console.Write("Enter Semester : ");
                Semester = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Admission Fees : ");
                Fees = Convert.ToDouble(Console.ReadLine());
            }
            public void CheckScholarshipEligibility()
            {
                if (Fees <= 62500)
                {
                    IsScholarshipEligible = true;
                }
                else
                {
                    IsScholarshipEligible = false;
                }
            }
            public void CheckAdmissionEligibility()
            {
                if (HSCStream.ToLower() != "science")
                {
                    IsAdmissionEligible = false;
                }
                else if (Percentage < 45)
                {
                    IsAdmissionEligible = false;
                }
                else
                {
                    IsAdmissionEligible = true;
                }
            }
            public void DisplayDetails()
            {
                double FinalFees = Fees;

                if (IsScholarshipEligible)
                {
                    FinalFees = Fees - (Fees * ScholarshipRate);
                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("              STUDENT ADMISSION DETAILS");
                Console.WriteLine("---------------------------------------------------");

                Console.WriteLine("Admission Number : " + AdmissionNumber);
                Console.WriteLine("Enrollment Number : " + EnrollmentNumber);
                Console.WriteLine("Student Name : " + StudentName);
                Console.WriteLine("HSC Stream : " + HSCStream);
                Console.WriteLine("Percentage : " + Percentage + "%");
                Console.WriteLine("Course Name : " + Course);
                Console.WriteLine("Branch Name : " + Branch);
                Console.WriteLine("Semester : " + Semester);
                Console.WriteLine("Actual Admission Fees : " + Fees);

                Console.WriteLine(
                    "Admission Status : " +
                    (IsAdmissionEligible ? "Eligible" : "Not Eligible")
                );

                Console.WriteLine(
                    "Scholarship : " +
                    (IsScholarshipEligible ? "Eligible" : "Not Eligible")
                );

                Console.WriteLine("Final Fees you have to be : " + FinalFees);

                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}
