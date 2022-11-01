using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces
{
    class TextFileLog : SystemLog, IFile
    {
        public void SaveToFile(string fullPath, string message)
        {
            throw new NotImplementedException();
        }
    }
}
