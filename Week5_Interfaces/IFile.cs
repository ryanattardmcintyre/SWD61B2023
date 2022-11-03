using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces
{
    //interface is like a contract specifying what methods should be implemented, should this be inherited
    interface IFile
    {
        void SaveToFile(string fullPath, string message);
    }
}
