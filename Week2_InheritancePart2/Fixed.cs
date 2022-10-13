using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritancePart2
{
    public class Fixed: Account
    {
        public DateTime ResetDate { get; set; }
        public double InterestRate { get; set; } //0.02 p.a
        public DateTime ExpiryDate { get; set; }
        public virtual double CalculateTax(double taxRate)
        {
            if (Balance > 0)
            {
                double duration = ExpiryDate.Subtract(ResetDate).TotalDays;
                double interestInCurrency = ((Balance) * (InterestRate / 365)) * duration;
                ResetDate = DateTime.Now;
                return interestInCurrency;
            }
            else return 0;

        }
    }
}
