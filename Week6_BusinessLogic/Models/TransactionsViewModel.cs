using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_BusinessLogic.Models
{
    public class TransactionsViewModel
    {
        public string Isbn { get; set; }
        public string BookName { get; set; }
        public int Borrowings { get; set; }
    }
}
