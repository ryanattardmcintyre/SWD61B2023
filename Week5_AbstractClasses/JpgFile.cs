using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_AbstractClasses
{
    public class JpgFile : File
    {
        //as per inheritance, in JpgFile you are going to inherit the public components
        //but anything which was declared as abstract must now be implemented


        
        public byte[] Content { get; set; }
        public override void LoadFile()
        {
            //built in class which one can use to handle physical files
            //e.g. FileStream, System.IO.File, ....

            //approach 1:
             Content = System.IO.File.ReadAllBytes(Path + "\\" + FileName);

            //approach 2:
           /* int counter = 0;
            byte[] buffer = new byte[100];
             
            using (System.IO.FileStream fsIn = new System.IO.FileStream(Path + "\\" + FileName, System.IO.FileMode.Open))
            {
                Content = new byte[fsIn.Length];

                while(counter < fsIn.Length - 100)
                {
                    fsIn.Read(buffer, counter, 100);
                    buffer.CopyTo(Content.ToArray(), counter);
                    counter += 100;
                    
                }
                fsIn.Read(buffer, 0, (int)fsIn.Length - counter);
                buffer.CopyTo(Content.ToArray(), counter);
            }  */

        }

        public override void SaveFile()
        {
            System.IO.File.WriteAllBytes(Path + "\\" + FileName, Content);
        }
    }
}
