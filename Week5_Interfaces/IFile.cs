using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces
{
    interface IFile
    {
        void SaveToFile(string fullPath, string message);
    }
}
