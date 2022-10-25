using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4_ClassRelationships.Association;

namespace Week4_ClassRelationships.Aggregation
{
    public class Driver: Person
    {
        public int LicenseNo { get; set; }

        public DateTime LicenseExpiry { get; set; }

        public string LicenseType { get; set; }

    }
}
