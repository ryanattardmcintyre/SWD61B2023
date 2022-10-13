using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Inheritance
{
    //inherited/derived class
    class Sphere: Circle
    {
        //radius is inherited in Sphere as well

        //hidden there's the default constructor of Sphere
        public Sphere(double r) :base(r)
        {
        }

        public override double FindArea()
        {
            return 4 * Math.PI * Radius * Radius;
        }

        public virtual double FindVolume()
        {
            return (4 *Math.PI * Math.Pow(Radius,3)) / 3;
        }
    }
}
