using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces
{
    public enum LogType {Warning, Info, Critical, Error }

    //static polymorphism = method overloading
    //methods  can have the same name but different parameter-types
    interface ILog
    {
        void Log(string message);
        void Log(Exception ex);
        void Log(string message, LogType type);

        void Log(string message, LogType type, string username, string stackTrace);
    }
}
