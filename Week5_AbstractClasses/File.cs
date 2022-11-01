using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_AbstractClasses
{
    public abstract class File
    {
        public string FileName { get; set; }
        public string Path { get; set; }

        public double Size { get; set; }

        public string FileType { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastAccessed { get; set; }

        public bool Encrypted { get; set; }

      
        public abstract void LoadFile(); //absctract method means, that any class which will inherit from this class
                                         // will be forced to implement this method

        public abstract void SaveFile();
       
    }
}
