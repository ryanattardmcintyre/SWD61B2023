using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_AbstractClasses
{
    public class TextFile : File
    {
        public string Content { get; set; }
        public override void LoadFile()
        {
            Content = System.IO.File.ReadAllText(Path + "\\" + FileName);
        }

        public override void SaveFile()
        {
            System.IO.File.WriteAllText(Path + "\\" + FileName, Content);

        }
    }
}
