using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces_W6Q3
{
    //abstract class cannot be instantiated
    abstract class Character : IAttack
    {
        //protected makes the member of the class available/accessible only
        //in the derived classes e.g. Mage, Warrior, Priest
        protected Character(int mana, int health, int damage)
        {
            Mana = mana;
            Health = health;
            Damage = damage;
        }

        public int Mana { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        //methods inherited from the interface
        //can either be
        //1) implemented
        //2) marked as abstract to postpone implementation to a later stage
        public abstract void Attack(Character target);
    }
}
