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

                Console.WriteLine("8. Count and list book borrowings");
                
                Console.WriteLine("9. List all books");


                Console.WriteLine("10. Average of number of days all books are borrowed");

                Console.WriteLine("11. Check overdue books");
                Console.WriteLine("12. Return back book");

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


                    case 6:
                        Console.WriteLine("Which Book? Type in Isbn");
                        string isbnOfBookToBorrow = Console.ReadLine();

                        Console.WriteLine("Input idcard of the user borrowing the book:");
                        string idcard = Console.ReadLine();

                        Transaction transaction = new Transaction();
                        transaction.MemberFK = idcard;
                        transaction.IsbnFK = isbnOfBookToBorrow;

                        transaction.DateBorrowed = DateTime.Now;

                        try
                        {
                            br.BorrowABook(transaction);
                            Console.WriteLine($"Book with isbn {isbnOfBookToBorrow} has been borrowed successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                            Console.WriteLine(" or isbn is incorrect or idcard incorrect");
                        }

                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();
                        break;

                    case 7:

                        Console.WriteLine("Which Book to delete? Type in Isbn");
                        string isbnOfBookToDelete = Console.ReadLine();

                        try
                        {
                            br.DeleteBook(isbnOfBookToDelete);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();


                        break;

                    case 8:
                        Console.WriteLine("Which Book? Type in Isbn");
                        string isbnOfBookToCountTransactions = Console.ReadLine();

                        Book b1 = br.GetBook(isbnOfBookToCountTransactions);

                        Console.WriteLine("No of transactions: " + b1.Transactions.Count);
                        Console.WriteLine();
                        Console.WriteLine("Transactions:");
                        foreach(var t in b1.Transactions)
                        {
                            Console.WriteLine($"Id: {t.Id}");
                            Console.WriteLine($"Date Borrowed: {t.DateBorrowed.ToString("dd/MM/yyyy")}");
                            if(t.DateReturned == null)
                            {
                                Console.WriteLine("Book is still out");
                            }
                            else
                            {
                                Console.WriteLine($"Date Returned: {t.DateReturned.Value.ToString("dd/MM/yyyy")}");
                            }
                            
                            Console.WriteLine($"User: {t.MemberFK} | {t.Member.FirstName} | {t.Member.LastName}");
                        }
                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();
                        break;


                    case 9:

                        var listofallbooks = br.GetBooks().ToList();

                        for (int i = 0; i <= listofallbooks.Count()-1; i+=3)
                        {
                            var currentBooksInPage = listofallbooks.Skip(i).Take(3);
                            foreach (var b in currentBooksInPage)
                            {
                                Console.WriteLine($"Isbn: {b.Isbn}");
                                Console.WriteLine($"Author: {b.Author}");
                                Console.WriteLine($"Name: {b.Name}");
                                Console.WriteLine($"Year: {b.PublishedYear}");
                                Console.WriteLine($"Vol {b.Volume} Issue No. {b.Issue}");
                                Console.WriteLine($"Category: {b.Category.Title}");
                                Console.WriteLine("----------------------------------------------------");
                                Console.WriteLine();
                            }

                            Console.WriteLine($"Press a key to  go to page {(i / 3)+2}...");
                            Console.ReadKey();
                            Console.Clear();

                        }

                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();
                        break;
                    
                    case 10:
                        Console.WriteLine("Avg no of days any book is borrowed is: " +
                            br.GetAvgDaysForBorrowingABook());

                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();

                        break;

                    case 11:

                        var listOfOverdueBooks = br.GetOverdueBooks(7);
                        if (listOfOverdueBooks.Count() > 0)
                        {
                            Console.WriteLine("Here's a list of overdue books:");
                            foreach (var overdueBook in listOfOverdueBooks)
                            {
                                Console.WriteLine($"Isbn: {overdueBook.Isbn}");
                                Console.WriteLine($"Author: {overdueBook.Author}");
                                Console.WriteLine($"Name: {overdueBook.Name}");
                                Console.WriteLine($"Year: {overdueBook.PublishedYear}");
                                Console.WriteLine($"Vol {overdueBook.Volume} Issue No. {overdueBook.Issue}");
                                Console.WriteLine($"Category: {overdueBook.Category.Title}");

                                Transaction overDueTransaction = overdueBook.Transactions.SingleOrDefault(x => x.DateReturned == null);

                                Console.WriteLine($"Date Borrowed: {overDueTransaction.DateBorrowed.ToString("dd/MM/yyyy")}");
                                Console.WriteLine($"Days Overdue: { DateTime.Now.Subtract(overDueTransaction.DateBorrowed).Days - 7}");

                                Console.WriteLine("------------------------------------");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no overdue books!");
                        }

                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();

                        break;

                    case 12:
                        Console.WriteLine("Which Book? Type in Isbn");
                        string isbnOfBookReturned = Console.ReadLine();

                        br.ReturnBook(isbnOfBookReturned, DateTime.Now);
                        
                        Console.WriteLine("Book was returned succesfully");

                        Console.WriteLine("Press a key to return to main menu");
                        Console.ReadKey();

                        break;


                }


            } while (choice != 999);

        }
    }
}
