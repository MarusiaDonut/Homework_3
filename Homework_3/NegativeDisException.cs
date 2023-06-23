using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    internal class NegativeDisException : Exception
    {
        public NegativeDisException(string message) : base (message)
        {
            message = message;
            Console.WriteLine(message);
        }
    }
}
