using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            CategoriesRepository cr = new CategoriesRepository(context);
            BooksRepository br = new BooksRepository(context);

            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. List Members");
                Console.WriteLine("3. Search for Member");

                Console.WriteLine("4. Add Book");
                Console.WriteLine("5. Search for Book");
                Console.WriteLine("6. Reserve a book");
                Console.WriteLine("7. Delete a book");

                Console.WriteLine("8. Count the number of times a book was borrowed");
                Console.WriteLine("9. Average of number of days all books are borrowed");
               
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

                    case 4:
                        Book myNewBook = new Book();
                        try
                        {
                            Console.WriteLine("Input isbn:");
                            myNewBook.Isbn = Console.ReadLine();

                            Console.WriteLine("Input author:");
                            myNewBook.Author = Console.ReadLine();

                            Console.WriteLine("Input name:");
                            myNewBook.Name = Console.ReadLine();

                            bool correctInput = false;
                            int year1;
                            do
                            {
                                Console.WriteLine("Input year:");
                                correctInput = int.TryParse(Console.ReadLine(), out year1);
                                if (correctInput)
                                { myNewBook.PublishedYear = year1; }
                                else
                                {
                                    Console.WriteLine("Wrong input. Input only numbers");
                                }
                            } while (correctInput == false);


                            Console.WriteLine("Input Volume (if any - leave empty if no volume:");
                            string volume = Console.ReadLine();
                            if (string.IsNullOrEmpty(volume))
                                myNewBook.Volume = 0;
                            else myNewBook.Volume = Convert.ToInt32(volume);

                            Console.WriteLine("Input Issue no (if any - leave empty if no issue:");
                            string issue = Console.ReadLine();
                            if (string.IsNullOrEmpty(issue))
                                myNewBook.Issue = 0;
                            else myNewBook.Issue = Convert.ToInt32(issue);

                            Console.WriteLine();
                            Console.WriteLine("Categories:");
                            foreach (var c in cr.GetCategories())
                            {
                                Console.WriteLine($"{c.Id} - {c.Title}");
                            }
                            Console.WriteLine("Type the number next to the category for the book:");
                            myNewBook.CategoryFK = Convert.ToInt32(Console.ReadLine());
                            br.AddBook(myNewBook);
                            Console.WriteLine("Book was added successfully");
                        }
                        catch (FormatException ex) //catches only exceptions related when there's a conversion
                        {
                            Console.WriteLine("The year, the volume, the issue, and the category - they must all be numbers. Check your inputs");
                        }
                        catch (SqlException ex) //catches only exceptions raised by the database
                        {
                            Console.WriteLine("There was an error while adding your book. " +
                                "It might be that you have input an incorrect Category or perhaps you used very long names. Check again");
                        }
                        catch (Exception ex) //this catches all exceptions
                        {
                            //log the ex.Message
                            Console.WriteLine("Book wasn't added. Some inputs may be invalid. Check your inputs.");
                        }
                        
                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();

                        break;

                    case 5:

                        Console.WriteLine("Write a search keyword (name)");
                        string search2 = Console.ReadLine();

                        var list2 = br.GetBooks(search2);
                        if (list2.Count() == 0)
                            Console.WriteLine("No books found!!");
                        else
                        {
                                 foreach (var b in list2)
                                                        {
                                                            Console.WriteLine($"Isbn: {b.Isbn}");
                                                            Console.WriteLine($"Author: {b.Author}");
                                                            Console.WriteLine($"Name: {b.Name}");
                                                            Console.WriteLine($"Year: {b.PublishedYear}");
                                                            Console.WriteLine($"Vol {b.Volume} Issue No. {b.Issue}");
                                                            Console.WriteLine($"Category: {b.Category.Title}");
                            
                                                            Console.WriteLine("------------------------------------");
                                                            Console.WriteLine("");
                                                        }
                        }

                       
                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();


                        break;

                }


            } while (choice != 999);

        }
    }
}
