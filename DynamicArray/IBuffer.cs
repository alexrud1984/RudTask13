using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    interface IBuffer <T>:IPrintable
    {
        bool IsEmpty();
        bool IsFull();
        T Peek();
    }
}
