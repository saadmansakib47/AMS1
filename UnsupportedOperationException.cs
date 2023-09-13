using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS1
{
    public class UnsupportedOperationException : Exception 
    {
        public UnsupportedOperationException(string message) : base (message)
        {

        }
    }
}
