using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Inheritance
{
    class Sphere: Circle
    {
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
