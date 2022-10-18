using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Polymorphism
{
    public enum Genre {Biography=0, History=1, Fiction=2, Kids=3, Science=4}

    public class Book
    {
        public Book()
        { }

        public Book(string isbn, string name)
        { Isbn = isbn;
            Name = name;
        }

        public Book(string isbn, string name, Genre category)
        {
            Isbn = isbn;
            Name = name;
            Category = category;
        }

        public string Name { get; set; }
        public int PublishedYear { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }

        public Genre Category { get; set; }

        public virtual string Print()
        {
            return $"{Isbn}, {Name}, {Author}, {Category}, {PublishedYear}";
        }

        public bool Available { get; set; }

        public void Borrow()
        {
            if (Available)
            {
                Available = false;
                BorrowedDate = DateTime.Now;
            }
        }

        public DateTime ReturnedDate { get; set; }
        public DateTime BorrowedDate { get; set; }
        //if book is returned after more than 30 days you will have to pay 
        //a charge of 1eur per day extra
        
        
        //static polymorphism is when you overload the method/constructor (by adding parameters
        // to the method signature
        
       /// <summary>
       /// Method is to be called when library member is returning a book
       /// </summary>
       /// <returns></returns>
        public virtual double Return()
        {
            double charge = 0;
            Available = true;
            ReturnedDate = DateTime.Now;
            if (DateTime.Now.Subtract(BorrowedDate).TotalDays > 30)
            {
                double extraDays = DateTime.Now.Subtract(BorrowedDate).TotalDays-30;
                charge = 1 * extraDays;
            }
            return charge;
        }

        /// <summary>
        /// Method is to be called when library member wishes to know how much the charge will
        /// be on a future date
        /// </summary>
        /// <param name="futureReturnDate">Future date used to calculate charge</param>
        /// <returns></returns>
        public virtual double Return(DateTime futureReturnDate)
        {
            double charge = 0;
         
           
            if (futureReturnDate.Subtract(BorrowedDate).TotalDays > 30)
            {
                double extraDays = futureReturnDate.Subtract(BorrowedDate).TotalDays - 30;
                charge = 1 * extraDays;
            }
            return charge;
        }
    }
}
