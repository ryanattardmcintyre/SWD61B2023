using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4_ClassRelationships.Aggregation;
using Week4_ClassRelationships.Association;

namespace Week4_ClassRelationships.Composition
{
    class Vehicle
    {
        public Vehicle(Engine engine)
        { Engine = engine; }

        public Vehicle(Engine engine, string model, string make): this(engine)
        { Model = model; 
            Make = make; 
            //...
        }

        public string Model { get; set; }
        public string Make { get; set; }
        
        public int ManufacturedYear { get; set; }

        public string RegNo { get; set; }

        public string Color { get; set; }

        public Engine Engine { get; set; }

        public string OwnerId { get; set; }
        public List<Driver> Drivers { get; set; }

        public void AddDriver(Driver d)
        { Drivers.Add(d); }

        public void RemoveDriver(Driver d)
        { Drivers.Remove(d); }

        public void ChangeOwner(Person p)
        {
            OwnerId = p.IdCardNo;
        }
    }
}
