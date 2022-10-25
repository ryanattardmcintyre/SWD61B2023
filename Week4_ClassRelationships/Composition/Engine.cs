using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_ClassRelationships.Composition
{
    enum FuelType { Petrol, Diesel, Hybrid, FullElectric, Gas}

    class Engine
    {
        public string HP { get; set; }
        public string Make { get; set; }

        public int CC { get; set; }

        public int Torque { get; set; }

        public FuelType FuelType { get; set; }

        public string EngineNo { get; set; }

        public int Mileage { get; set; }

    }
}
