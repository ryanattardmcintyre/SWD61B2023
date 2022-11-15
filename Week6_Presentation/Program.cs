using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_BusinessLogic.Models;
using Week6_BusinessLogic.Repositories;

namespace Week6_Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            SWD61B_OOPEntities context = new SWD61B_OOPEntities(); //an object representing an abstraction of the database
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. List Members");
                Console.WriteLine("3. Search for Member");

                Console.WriteLine("999. Quit");

                choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        MembersRepository mr = new MembersRepository(context);

                        Member m = new Member();
                        Console.WriteLine("Input first name");
                        m.FirstName = Console.ReadLine();

                        Console.WriteLine("Input last name");
                        m.LastName = Console.ReadLine();

                        Console.WriteLine("Input idcard");
                        m.IdCard = Console.ReadLine();

                        Console.WriteLine("Input mobile");
                        m.Mobile =  Console.ReadLine();
                        
                        Console.WriteLine("Input day from date of birth"); // 10th october 1990
                        int day = Convert.ToInt32( Console.ReadLine());
                        Console.WriteLine("Input month (number) from date of birth"); // 10th october 1990
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input year from date of birth"); // 10th october 1990
                        int year = Convert.ToInt32(Console.ReadLine());

                        m.DOB = new DateTime(year, month, day);

                        mr.AddMember(m);

                        Console.WriteLine("Member added successfully");
                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();

                        break;

                    case 2:
                        break;

                }


            } while (choice != 999);

        }
    }
}
