using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing
{
    public class UserUtility
    {
        /**
         * THis method is used for Fails
         * @param String message
         * **/
        string path = ".//..//..//..//";
        public UserUtility()
        {

        }
        public void FailMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Write(message);
        }
        /**
         * THis method is used for Success
         * @param String message
         * **/
        public void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Write(message);
        }
        /**
         * Typical write method
         * @param String message
         * **/
        public void Write(string message)
        {
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
