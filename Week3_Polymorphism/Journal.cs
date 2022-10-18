using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Polymorphism
{
    public class Journal: Book
    {
        public int Volume { get; set; }
        public int IssueNo { get; set; }
        public int PublishedMonth { get; set; }
        public override string Print()
        {
            return base.Print()+$", {Volume}, {IssueNo}, {PublishedMonth}";
        }

        //charge for late return > 7, is increased to 1.50Eur for the journal
        public override double Return()
        {
            double charge = 0;
            Available = true;
            ReturnedDate = DateTime.Now;
            if (DateTime.Now.Subtract(BorrowedDate).TotalDays > 7)
            {
                double extraDays = DateTime.Now.Subtract(BorrowedDate).TotalDays-7;
                charge = 1.5 * extraDays;
            }
            return charge;
        }
        public override double Return(DateTime futureReturnDate)
        {
            double charge = 0;

            if (futureReturnDate.Subtract(BorrowedDate).TotalDays > 7)
            {
                double extraDays = futureReturnDate.Subtract(BorrowedDate).TotalDays-7;
                charge = 1.5 * extraDays;
            }
            return charge;
        }

    }
}
