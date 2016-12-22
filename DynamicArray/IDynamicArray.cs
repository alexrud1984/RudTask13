using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    interface IDynamicArray<T>
    {
        void Add(T value);
        void Insert(int index, T value);
        T Get(int index);
        void Remove(int index);
    }
}
