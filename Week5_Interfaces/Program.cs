using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces
{
    //Interfaces are like classes BUT THEY ARE NOT, which exist only to be inherited
    //in other words you can call them contracts, meaning that any class (it can be abstract class as well) has to respect what is defined in a contract/interface
    //usage: normally interfaces are used when you have started building your own library or your own framework
    // you can only inherit an interface not initialize it
    //interfaces are usually called I.......
    //Interfaces dont allow you to code inside them....they are stricter than Abstract classes
    class Program
    {
        static void Main(string[] args)
        {
            TextFileLog myLoggingMethod = new TextFileLog();
            
        }
    }

    
}
