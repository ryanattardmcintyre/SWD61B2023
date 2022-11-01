using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4_ClassRelationships.Aggregation;
using Week4_ClassRelationships.Composition;

namespace Week4_ClassRelationships
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine e;
            e = new Engine();
            e.FuelType = FuelType.Hybrid;
            e.Make = "Toyota";

            Vehicle v = new Vehicle(e);
            v.Make = "Toyota";
            v.Model = "chr";
            v.ManufacturedYear = 2020;
           
           
            Driver d = new Driver();
            v.AddDriver(d);


        }
    }
}
