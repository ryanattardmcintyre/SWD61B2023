using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Inheritance
{
    //base
    class Circle
    {
        
        public Circle(double r)
        { Radius = r; }

        public double Radius { get; set; }
        public double Diameter { get { return Radius * 2; }  }

        public virtual double FindArea()
        {
            return  Math.PI * Math.Pow(Radius, 2);
        }

        public virtual double FindPerimeter()
        { return 2 * Math.PI * Radius; }
    }
}
