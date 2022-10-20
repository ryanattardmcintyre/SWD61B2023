using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Polymorphism
{
    class Program
    { 
      //static: makes the object live in memory as long as the application is running
            //  when you make an object as static, it means that you are sharing it among all "requests"/"calls"

        static void Main(string[] args)
        {    List<Book> books = new List<Book>();
            
            int mainMenuChoice = 0;
           
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add a book");
                    Console.WriteLine("2. Borrow a book");
                    Console.WriteLine("3. Return a book");
                    Console.WriteLine("4. Check charge");
                    Console.WriteLine("5. Quit");
                try
                {
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine()); 

                    //Difference between ReadKey() vs ReadLine()
                    //ReadKey >>> gives you a code representing the key from the keyboard that was pressed;
                    //ReadLine >>> gives you the actual letter/number/symbol that was typed; to continue the execution you need to hit ENTER 

                    Console.Clear();
                    switch (mainMenuChoice)
                    {
                        case 1:
                            int subMenuChoice = 0;
                            Console.WriteLine("1. Add a traditional book");
                            Console.WriteLine("2. Add a journal");
                            subMenuChoice = Convert.ToInt32(Console.ReadLine()); ;

                            if (subMenuChoice == 1)
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
                                b.Category = (Genre)Convert.ToInt32(Console.ReadLine()); //to check

                                books.Add(b);

                                Console.WriteLine("Book added successfully. Press a key to continue");
                                Console.ReadKey();

                            }
                            else if (subMenuChoice == 2)
                            {

                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Press a key to continue...");
                                Console.ReadKey();
                            }

                            break;

                        case 2:
                            //1. which book?
                            Console.WriteLine("Write the Isbn:");
                            string isbn = Console.ReadLine();

                            //2. search
                            bool found = false; int counter = 0;
                            Book foundBook = null;
                            do
                            {
                                if (isbn == books[counter].Isbn)
                                {
                                    found = true;
                                    foundBook = books[counter];
                                }
                                counter = counter + 1;

                            } while (found == false && counter < books.Count);

                            //3. call the Borrow on the found book
                            if (foundBook != null)
                            {
                                if (foundBook.Available == false)
                                {
                                    Console.WriteLine("Book is already borrowed! Press a key to continue...");
                                }
                                else
                                {
                                    foundBook.Borrow();
                                    Console.WriteLine("Book is borrowed! Press a key to continue...");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Book does not exist in library.  Press a key to continue...");

                            }
                            Console.ReadKey();

                            break;

                        case 3:
                            //1. identify which book you would like to check how much is the charge /fine

                            //2. get the book/search for it

                            //3. call the Return method after you make sure that it is actually borrowed

                            //1. which book?
                            Console.WriteLine("Write the Isbn:");
                            string isbn2 = Console.ReadLine();

                            //2. search
                            bool found2 = false; int counter2 = 0;
                            Book foundBook2 = null;
                            do
                            {
                                if (isbn2 == books[counter2].Isbn)
                                {
                                    found2 = true;
                                    foundBook2 = books[counter2];
                                }
                                counter2 = counter2 + 1;

                            } while (found2 == false && counter2 < books.Count);

                            //3. call the Borrow on the found book
                            if (foundBook2 != null)
                            {
                                if (foundBook2.Available == false) //it was borrowed
                                {
                                    double charge = foundBook2.Return();
                                    if (charge > 0)
                                    {
                                        Console.WriteLine($"There is a Eur{charge} charge. Please pay and press a key to continue...");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Book returned and press a key to continue...");
                                    }
                                }
                                else
                                {

                                    Console.WriteLine("Charge cannot be worked because book is available! Press a key to continue...");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Book does not exist in library.  Press a key to continue...");

                            }
                            Console.ReadKey();


                            break;

                        case 4:

                            //1. identify which book you would like to check how much is the charge /fine

                            //2. get the book/search for it

                            //3. call the Return method after you make sure that it is actually borrowed

                            //1. which book?
                            Console.WriteLine("Write the Isbn:");
                            string isbn3 = Console.ReadLine();

                            //3. search
                            bool found3 = false; int counter3 = 0;
                            Book foundBook3 = null;
                            do
                            {
                                if (isbn3 == books[counter3].Isbn)
                                {
                                    found3 = true;
                                    foundBook3 = books[counter3];
                                }
                                counter3 = counter3 + 1;

                            } while (found3 == false && counter3 < books.Count);

                            //3. call the Borrow on the found book
                            if (foundBook3 != null)
                            {
                                if (foundBook3.Available == false) //it was borrowed
                                {
                                    Console.WriteLine("Input the date:");
                                    DateTime futureDate = Convert.ToDateTime(Console.ReadLine());

                                    double charge = foundBook3.Return(futureDate);
                                    if (charge > 0)
                                    {
                                        Console.WriteLine($"There is a Eur{charge} charge and press a key to continue...");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Book has no charge and press a key to continue...");
                                    }
                                }
                                else
                                {

                                    Console.WriteLine("Charge cannot be worked because book is available! Press a key to continue...");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Book does not exist in library.  Press a key to continue...");

                            }
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wrong input...");
                    Console.ReadKey();
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
