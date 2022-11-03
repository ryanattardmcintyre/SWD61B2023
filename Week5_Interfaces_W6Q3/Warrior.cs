using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces_W6Q3
{
   
    class Warrior :Character
    {
        public Warrior(): base(0, 300, 120)
        { }

        public override void Attack(Character target)
        {
            target.Health -= this.Damage;
        }
    }
}
