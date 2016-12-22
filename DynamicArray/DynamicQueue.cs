using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{

     public class DynamicQueue <T> : Buffer <T>, IDynamicQueue<T>
    {
        public DynamicQueue(int size) : base(size) { }

        public void Enqueue(T value)                    //put new value in queue
        {
            if (this.IsFull())
            {
                throw new AddToFullException();
            }
            bufferMtrx.Add(value);
            OnNewElementAdded(value.ToString());
            if (this.IsFull())
            {
                OnBufferIsFool("Queue is full");        //raise full buffer event
            }
        }

        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new TakeFromEmptyException();
            }
            T temp;
            temp = bufferMtrx[0];       //get first element from array
            bufferMtrx.Remove(0);       //remove this element
            if (this.IsEmpty())
            {
                OnBufferIsEmpty("Queue is empty"); //generate event if queue is empty
            }
            OnElementRemoved(temp.ToString());
            return temp;
        }

        public override T Peek()
        {
            if (this.IsEmpty())
            {
                throw new TakeFromEmptyException();
            }
            return bufferMtrx[0];   
        }

    }
}
