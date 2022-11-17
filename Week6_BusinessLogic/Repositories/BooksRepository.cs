using System;
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

            //2. check whether there are any transactions with DateReturned null
            int howMany= bookThatIsGoingToBeBorrowed.Transactions.Count(x =>
             x.DateReturned == null);

            //3. if there is Transaction with returned date null
            if (howMany == 1)
            {
                //book is borrowed
                throw new Exception("Book cannot be borrowed");
            }
            else
            {
                //book is available to be borrowed
                Context.Transactions.Add(t);
                Context.SaveChanges();
            }
            //3.i you cannot borrow book
            //3.ii else you can, add a transaction


        
        }

    }
}
