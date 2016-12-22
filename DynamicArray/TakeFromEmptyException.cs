using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class TakeFromEmptyException : Exception
    {
        public TakeFromEmptyException() : base("I can't do it Master! It is empty.")
        {
        }
    }
}
