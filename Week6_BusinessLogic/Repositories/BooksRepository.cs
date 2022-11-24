﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_BusinessLogic.Models;

namespace Week6_BusinessLogic.Repositories
{
    public class BooksRepository
    {
        public SWD61B_OOPEntities Context { get; set; }

        public BooksRepository(SWD61B_OOPEntities _context)
        {
            Context = _context;
        }

        public IQueryable<Book> GetBooks() {
            return Context.Books;
        }
        public IQueryable<Book> GetBooks(string keyword) {

            return GetBooks().Where(m => m.Name.StartsWith(keyword));
        }

        public void AddBook(Book b) {

            Context.Books.Add(b);
            Context.SaveChanges();
        }


        public Book GetBook(string isbn) {

            return GetBooks().SingleOrDefault(x => x.Isbn == isbn);
        }
        public void BorrowABook(Transaction t) {
            //validation

            //1. Get the book
            Book bookThatIsGoingToBeBorrowed = GetBook(t.IsbnFK);

            if (bookThatIsGoingToBeBorrowed != null)
            {//if book is found
             //2. check whether there are any transactions with DateReturned null
                int howMany = bookThatIsGoingToBeBorrowed.Transactions.Count(x =>
                  x.DateReturned == null);

                //3. if there is Transaction with returned date null
                //3.i you cannot borrow book
                if (howMany == 1)
                {
                    //book is borrowed
                    throw new Exception("Book cannot be borrowed");
                }
                else
                {                 //3.ii else you can, add a transaction
                                  //book is available to be borrowed
                    Context.Transactions.Add(t);
                    Context.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Book does not exist. Wrong isbn");
            }
        }


        public void DeleteBook(string isbn)
        {
            Book bookToDelete = GetBook(isbn);
            if (bookToDelete != null)
            {
                int howMany = bookToDelete.Transactions.Count(x =>
                         x.DateReturned == null);

                if (howMany == 1)
                {
                    throw new Exception("Book cannot be deleted because book is being borrowed");
                }
                else
                {
                    Context.Books.Remove(bookToDelete);
                    Context.SaveChanges(); //SaveChanges commits changes in the database permanently
                }
            }
            else
            {
                throw new Exception("Book does not exist. Wrong isbn");
            }
        }


        //Book 1, 10
        //Book 2, 1

        public IQueryable<TransactionsViewModel> ListBookBorrowings()
            {
            var list = from b in Context.Books
                       orderby b.Transactions.Count descending
                       select new TransactionsViewModel()
                       {
                           BookName = b.Name,
                           Isbn = b.Isbn,
                           Borrowings = b.Transactions.Count
                       };
            return list;

            }


        public void ReturnBook(string isbn, DateTime returnedDate)
        {
            Book b = GetBook(isbn);
            Transaction t = b.Transactions.SingleOrDefault(x => x.DateReturned == null);
            t.DateReturned = returnedDate;
            Context.SaveChanges();
        }

        public double GetAvgDaysForBorrowingABook()
        {
         /*   var result = (from t in Context.Transactions
                          where t.DateReturned != null
                          select new  //creating a new anonymous object on-the-fly
                          {
                              Days = t.DateReturned.Value.Subtract(t.DateBorrowed).Days
                          }).Average(x => x.Days);
         */

            double sum = 0;
            foreach (var t in Context.Transactions.Where(x=>x.DateReturned!= null))
            {
                sum = t.DateReturned.Value.Subtract(t.DateBorrowed).Days;
            }

            return sum / (Context.Transactions.Count());

           
        }

    }
}
