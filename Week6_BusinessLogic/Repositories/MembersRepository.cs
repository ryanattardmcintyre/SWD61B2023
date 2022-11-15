using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_BusinessLogic.Models;

namespace Week6_BusinessLogic.Repositories
{
    //note: these repository classes will contain methods that will allow "the developer"
    //to manage data within the database

    //Rules: DO NOT place any code that manages/updates the interface (e.g. Console.WriteLine should not
    //be placed here
    public class MembersRepository
    {
        //this property will give me access to the database
        public SWD61B_OOPEntities Context { get; set; }

        //in the constructor i am assuming that the instance which will allow me to access the database
        //has already been initializaed
        //when this is going to happen? - the initialization will have to take place somewhere centralized
        //i.e. somewhere where it will be called only one time i.e. in the Presentation layer, when 
        //the console application will start
        public MembersRepository(SWD61B_OOPEntities _context)
        {
            Context = _context;
        }

        
        //IQueryable is more efficient than a List. Why? because when you make a database call, it doesn't immediately
        //open a connection with the database and executes the query statement, but it waits until at some point
        //you call .ToList

        
        //This method will get a full list of members from the database 
        //Select * from Members
        public IQueryable<Member> GetMembers()
        {
            //approach 1:
            return Context.Members;

            //LINQ version, approach 2:
            //var list = from m in Context.Members //start with from
            //           select m;                 //always end with select
            //return list;

        
        }

        //Select * from members where FirstName Like '%'+ keyword +'%'
        public IQueryable<Member> GetMembers(string keyword)
        {
            //a lambda expression
            //return GetMembers().Where(m => m.FirstName.StartsWith(keyword)).Where(m => m.LastName.StartsWith(keyword));
            return GetMembers().Where(m => m.FirstName.StartsWith(keyword) || m.LastName.StartsWith(keyword));

            //linq version:
            //var list = from m in GetMembers()
            //           where m.FirstName.StartsWith(keyword) || m.LastName.StartsWith(keyword)
            //           select m;
            //return list;

        }

        public IQueryable<Member> SortMembersBySurname(IQueryable<Member> membersToBeSorted)
        {
            return membersToBeSorted.OrderBy(m => m.LastName);

            //linq version:
            //var list = from m in membersToBeSorted
            //           orderby m.LastName ascending
            //           select m;
            //return list;
        }

        public void AddMember(Member m)
        {
            Context.Members.Add(m);
            Context.SaveChanges(); //this is needed if you want to commit permanently the changes into the database
        }

    }
}
