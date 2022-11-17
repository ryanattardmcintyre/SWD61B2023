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

            //creating an object of MembersRepository so we could call the methods
            //inside that class
            MembersRepository mr = new MembersRepository(context);

            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. List Members");
                Console.WriteLine("3. Search for Member");

                Console.WriteLine("4. Add Book");
                Console.WriteLine("5. Search for Book");
                Console.WriteLine("6. Reserve a book");




                Console.WriteLine("999. Quit");

                choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
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

                        var list = mr.GetMembers();
                        string suffix = "th";
                        foreach(var member in list)
                        {
                            Console.WriteLine($"Id card: {member.IdCard}");
                            Console.WriteLine($"First name: {member.FirstName}");
                            Console.WriteLine($"Second name: {member.LastName}");

                            if (member.DOB.Day.ToString().EndsWith("1"))
                            {
                                suffix = "st";
                            }
                            else if (member.DOB.Day.ToString().EndsWith("2"))
                            {
                                suffix = "nd";
                            }
                            else if (member.DOB.Day.ToString().EndsWith("3"))
                            {
                                suffix = "rd";
                            }
                            else
                            {
                                suffix = "th";
                            }
                            Console.WriteLine($"Date of Birth: {member.DOB.Day} {suffix} {member.DOB.ToString("MMMM")} {member.DOB.Year}"); //https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=net-7.0

                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();

                        break;

                    case 3:
                        Console.WriteLine("Write a search keyword (name/ surname)");
                        string search = Console.ReadLine();

                        var list1 = mr.GetMembers(search);
                        foreach (var member in list1)
                        {
                            Console.WriteLine($"Id card: {member.IdCard}");
                            Console.WriteLine($"First name: {member.FirstName}");
                            Console.WriteLine($"Second name: {member.LastName}");

                            if (member.DOB.Day.ToString().EndsWith("1"))
                            {
                                suffix = "st";
                            }
                            else if (member.DOB.Day.ToString().EndsWith("2"))
                            {
                                suffix = "nd";
                            }
                            else if (member.DOB.Day.ToString().EndsWith("3"))
                            {
                                suffix = "rd";
                            }
                            else
                            {
                                suffix = "th";
                            }
                            Console.WriteLine($"Date of Birth: {member.DOB.Day} {suffix} {member.DOB.ToString("MMMM")} {member.DOB.Year}"); //https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=net-7.0

                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();

                        break;
                }


            } while (choice != 999);

        }
    }
}
