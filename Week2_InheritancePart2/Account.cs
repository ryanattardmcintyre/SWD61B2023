using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_InheritancePart2
{
    public class Account
    {
        public string Iban { get; set; }
        public int AccountNo { get; set; }
        public string BankName { get; set; }

        public DateTime CreationDate { get; set; }

        public string IdCardNo { get; set; }

        public double Balance { get; set; }
    }
}
