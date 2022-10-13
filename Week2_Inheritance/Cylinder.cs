using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Inheritance
{
    class Cylinder: Sphere
    {
        public Cylinder(double r, double h):base(r)
        {
            Height = h;
        }
        public double Height { get; set; }

        public override double FindArea()
        {
            //2πrh+2πr2
            return (2 * Math.PI * Radius * Height)
                + (2 * Math.PI * Radius * Radius);

        }

        public override double FindPerimeter()
        {
            //2(2r + h)  
            return 2 * ((2 * Radius) + Height);
        }

        public override double FindVolume()
        {
            //πr2h
            return Math.PI * Radius * Radius * Height;
        }

    }
}
