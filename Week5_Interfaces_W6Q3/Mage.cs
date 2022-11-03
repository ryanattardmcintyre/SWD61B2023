using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces_W6Q3
{
   
    class Mage :Character
    {
        public Mage(): base(300,100, 75)
        { }

        public override void Attack(Character target)
        {
            this.Mana = this.Mana - 100;
            target.Health -= (this.Damage * 2);
            //e.g. if target is a priest, 150 will be deducted from the Priest's health
        }
    }
}
