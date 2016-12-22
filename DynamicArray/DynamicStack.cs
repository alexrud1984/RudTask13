using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class DynamicStack <T> : Buffer <T>, IMyStack<T>
    {
        public DynamicStack(int size) : base(size) { }

        public T Pop()                                            //returns top value in the stack
        {
            if (this.IsEmpty())
            {
                throw new TakeFromEmptyException();
            }

            T temp = bufferMtrx[bufferMtrx.Size - 1];             //save last value in array
            bufferMtrx.Remove(bufferMtrx.Size-1);                  // delete it form array
            OnElementRemoved(temp.ToString());
            if(this.IsEmpty())
            {
                OnBufferIsEmpty("Stack is empty");
            }
            return temp;                                          
        }

        public void Push(T value)                                 //push the value to the next free sell
        {
            if (this.IsFull())
            {
                throw new AddToFullException();
            }
            bufferMtrx.Add(value);
            OnNewElementAdded(value.ToString());
            if (this.IsFull())
            {
                OnBufferIsFool("Stack is full");
            }
        }

        public override T Peek()                                           //return top value without deletion
        {
            if (this.IsEmpty())
            {
                throw new TakeFromEmptyException();
            }
            return bufferMtrx[bufferMtrx.Size-1];
        }

    }
}
