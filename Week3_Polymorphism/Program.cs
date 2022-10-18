using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {

            int mainMenuChoice = 0;
            List<Book> books = new List<Book>();
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add a book");
                    Console.WriteLine("2. Borrow a book");
                    Console.WriteLine("3. Return a book");
                    Console.WriteLine("4. Check charge");
                    Console.WriteLine("5. Quit");
                    
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (mainMenuChoice)
                    {
                        case 1:
                        int subMenuChoice = 0;
                            Console.WriteLine("1. Add a traditional book");
                            Console.WriteLine("2. Add a journal");
                        subMenuChoice = Convert.ToInt32(Console.ReadLine()); ;
                        
                        if (subMenuChoice ==1)
                        {
                            Book b = new Book();
                            Console.WriteLine("Input isbn");
                            b.Isbn = Console.ReadLine();

                            Console.WriteLine("Input name");
                            b.Name = Console.ReadLine();

                            Console.WriteLine("Input author");
                            b.Author = Console.ReadLine();

                            b.Available = true;

                            Console.WriteLine("Input published year");
                            b.PublishedYear = Convert.ToInt32(Console.ReadLine());

                            string[] enumNames = Enum.GetNames(typeof(Genre)); //converted the enum names into a string array
                            for (int i = 0; i < enumNames.Length; i++)
                            {
                                Console.WriteLine($"{i}. {enumNames[i]}");
                            }
                            Console.WriteLine("Type in the number next to the value");
                            b.Category = (Genre) Convert.ToInt32(Console.ReadLine()); //to check

                            books.Add(b);

                            Console.WriteLine("Book added successfully. Press a key to continue");
                            Console.ReadKey();
                            
                        }
                        else if (subMenuChoice==2)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Press a key to continue...");
                            Console.ReadKey();
                        }

                        break;

                        case 2:
                            break;

                        case 3:
                             break;

                        case 4:
                            break;
                    }
            } while (mainMenuChoice != 5);

            Console.WriteLine("Hit a button to terminate the application...");
            Console.ReadKey();









 


            /*Journal j = new Journal();
            j.Isbn = "21412344234";
            j.Name = "Gratitude Journal";
            j.Author = "Sujatha Lalgudi";
            j.Category = Genre.Biography;
            j.IssueNo = 1;
            j.PublishedYear = 2022;
            j.PublishedMonth = 5;
            j.Available = true;
            


            books.Add(b);
            books.Add(j); //yes because journal inherits from book and book is the base class.
                          //i.e. anything which inherits from book can be added to the same list

            DateTime testFutureDate = new DateTime(2022, 10, 26);
            foreach (Book myBook in books)
            {
                myBook.Borrow();
                Console.WriteLine(myBook.Print());
                Console.WriteLine("Charge: " + myBook.Return(testFutureDate));
                Console.WriteLine("------------------------");
            }

            Console.ReadKey();
            */








        }
    }
}
