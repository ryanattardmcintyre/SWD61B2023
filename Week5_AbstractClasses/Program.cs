using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_AbstractClasses
{

    /*
     * 
     * Abstract classes:
     * 1)are type of classes that allow the defintion of implemented and non-implemented behaviours & properties
     * 2) they should be used when in certain parts of the class it is still unclear how to proceed/what to implement
     * 3) are normally used as base classes from which one can inherit
     * 4) they cannot be initialized
     * 
     */


    class Program
    {
        static void Main(string[] args)
        {

            List<File> myFiles = new List<File>();

            JpgFile myImage = new JpgFile();
            myImage.Path = @"C:\Users\attar\Downloads\downloadedimages";
            myImage.FileName = "31jQ91XUDhS.jpg";

            TextFile myTextFile = new TextFile();
            /*
             * 
             *  \n =escape characters
             *  \r
             *  \t
             * 
             * */

            myTextFile.Path =  @"C:\Users\attar\Downloads\downloadedimages";
            myTextFile.FileName = "hello.txt";

            myFiles.Add(myImage);
            myFiles.Add(myTextFile);

            foreach (var item in myFiles)
            {
                item.LoadFile();

                if(item.GetType() == typeof(JpgFile))
                {
                    JpgFile myTempFile = (JpgFile)item; //typecasting is converting
                    Console.WriteLine(
                        Convert.ToBase64String(
                        myTempFile.Content));
                }

                if (item.GetType() == typeof(TextFile))
                {
                    TextFile myTempFile = (TextFile)item;
                    Console.WriteLine(myTempFile.Content);
                }


                Console.WriteLine();
                Console.WriteLine("Press a key to view next file contents");
                Console.ReadKey();
            }


        }
    }
}
