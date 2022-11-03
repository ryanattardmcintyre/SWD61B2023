using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces
{

    //the difference between abstract classes and interfaces
    //1) abstract classes allow you to implement methods inside them however they also allow the specification of methods to be implemented in the future
    //2) you can inherit from ONLY 1 abstract class, while you can inherit from multiple interfaces

    class TextFileLog : SystemLog, IFile
    {
 

        public void SaveToFile(string fullPath, string message)
        {
            System.IO.File.AppendAllText(fullPath, message);
        }
    }
}
