using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_Interfaces
{
    abstract class SystemLog : ILog
    {
        //access modifiers:
        //public 
        //private
        //protected: allows the property to be accessed only from inherited classes

        protected List<string> Logs = new List<string>();
        public void Log(string message)
        {
            Logs.Add($"{DateTime.Now.ToString()}: {LogType.Info}:  {message}");
        }
        

        public void Log(Exception ex)
        {
            Logs.Add($"{DateTime.Now.ToString()}: {LogType.Error}: {ex.Message}, {ex.StackTrace}, {ex.GetType().ToString()}");
        }

        public void Log(string message, LogType type)
        {
            Logs.Add($"{DateTime.Now.ToString()}: {type}:  {message}");
        }

        public void Log(string message, LogType type, string username, string stackTrace)
        {
            Logs.Add($"{DateTime.Now.ToString()}: {LogType.Error}: {message}, {stackTrace}, {type.ToString()}");
        }
    }
}
