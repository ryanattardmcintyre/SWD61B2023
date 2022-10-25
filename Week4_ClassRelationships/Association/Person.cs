using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_ClassRelationships.Association
{
    public class Person
    {
        public string FullName { get; set; }
        public string IdCardNo { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }
    }
}
