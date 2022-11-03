using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces_W6Q3
{
 
    class Priest : Character, IHeal
    {
        public Priest(): base(200, 125, 100)
        { }

        public override void Attack(Character target)
        {
            //if he dealt 100 damage to the opponent, he restores 10% of that, or 10 health points.
            target.Health -= this.Damage;
            this.Health += Convert.ToInt32(.1 * this.Damage);
        }

        public void Heal(Character target)
        {
            // he reduces his mana by 100 and heals the target character by increasing his health with 150 health points.
            this.Mana -= 100;
            target.Health += 150;

        }
    }
}
