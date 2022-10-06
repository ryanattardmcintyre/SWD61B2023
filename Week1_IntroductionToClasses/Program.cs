using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroductionToClasses
{
    class Program
    {
        //1st thing that will run in my application
        static void Main(string[] args) //this is compulsory in a Console type of Application
        {
            //Person is the class; in the class you cannot store the data
            //p is an identifier which represents an object (instance); in the object you can store the data
        
            //the intellisense guides and facilitates coding
            
            Person p1 = new Person();

            Console.WriteLine("Input your name");
            p1.FirstName = Console.ReadLine();


            Console.WriteLine("Input your surname");
            p1.LastName = Console.ReadLine();


            Console.WriteLine("Input your password");
            string pwd= Console.ReadLine();

            Console.WriteLine("Input your confirmation password");
            string confirmationpwd = Console.ReadLine();

            switch( p1.ResetPassword(pwd, confirmationpwd))
            {
                case Reason.Ok: 
                    Console.WriteLine("Password was changed");
                    break;

                case Reason.NoMatch:
                    Console.WriteLine("Passwords do not match");

                    break;

                case Reason.WeakPassword:
                    Console.WriteLine("password is weak");
                    break;
            }
             


            //  Console.WriteLine("Input your password");
            //  p1.Password = Console.ReadLine();

            Console.WriteLine(p1.FullName);
            Console.WriteLine("Please press any key to terminate program");
            Console.ReadKey();

            Person p2 = new Person();



            Person p3 = new Person();













            Console.ReadLine(); //waits for the user to input something and presses enter
        }
    }
}
