using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritancePart2
{
    public class Savings: Fixed
    {
        public double Withdraw(double amount)
        {
            if(Balance >= amount)
            Balance = Balance- amount;
            //100-50 = 50....remaining balance
            return Balance;
        }
    }
}
