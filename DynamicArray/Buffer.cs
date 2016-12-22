using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    //event delegates
    public delegate void BufferIsFullHandler<T> (Buffer<T> buffer, BufferIsFullEventArgs eventArgs);
    public delegate void BufferIsEmptyHandler (BufferIsEmptyEventArgs eventArgs);
    public delegate void NewElementAddedHandler(NewElementAddedEventArgs eventArgs);
    public delegate void ElementRemovedHandler(ElementRemovedEventArgs eventArgs);

    //argument classes
    public class BufferIsFullEventArgs : EventArgs
    { 
        public string Reason { set; get; }
    }

    public class BufferIsEmptyEventArgs : BufferIsFullEventArgs { };

    public class NewElementAddedEventArgs : EventArgs
    {
        public string Value { set; get; }
    }

    public class ElementRemovedEventArgs : NewElementAddedEventArgs { }

    public abstract class Buffer<T> : IBuffer<T>
    {
        protected DynamicArray <T> bufferMtrx;
        protected int size;
        static int count = 0; 
        public int ID {private set; get;} 

        public Buffer(int size)
        {
            this.size = size;
            bufferMtrx = new DynamicArray <T> (size);
            ID = count++;
        }

        public event BufferIsFullHandler<T> BufferIsFull;
        public event BufferIsEmptyHandler BufferIsEmpty;
        public event NewElementAddedHandler NewElemntAdded;
        public event ElementRemovedHandler ElementRemoved;

        public abstract T Peek();

        public bool IsFull()
        {
            if (size == bufferMtrx.Size)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public bool IsEmpty()
        {
            if (bufferMtrx.Size == 0)        
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }

        public void Print()
        {
            {
                for (int i = 0; i < bufferMtrx.Size; i++)
                {
                    Console.WriteLine(bufferMtrx[i].ToString());
                }
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        protected void OnBufferIsFool(string reason)                                //method to raise event
        {
            if (BufferIsFull != null)
            {
                BufferIsFullEventArgs eventArgs = new BufferIsFullEventArgs ();     //create new arguments object
                eventArgs.Reason = reason;                                          //arguments creatiom
                BufferIsFull(this, eventArgs);                                           //event creation
            }
        }

        protected void OnBufferIsEmpty(string reason)                                //method to raise event
        {
            if (BufferIsEmpty != null)
            {
                BufferIsEmptyEventArgs eventArgs = new BufferIsEmptyEventArgs();     //create new arguments object
                eventArgs.Reason = reason;                                          //arguments creatiom
                BufferIsEmpty(eventArgs);                                                 //event creation
            }
        }

        protected void OnNewElementAdded(string value)                                //method to raise event
        {
            if (NewElemntAdded != null)
            {
                NewElementAddedEventArgs eventArgs = new NewElementAddedEventArgs();    //create new arguments object
                eventArgs.Value = value;                                             //arguments creatiom
                NewElemntAdded(eventArgs);                                             //event creation
            }
        }

        protected void OnElementRemoved(string value)                                //method to raise event
        {
            if (ElementRemoved != null)
            {
                ElementRemovedEventArgs eventArgs = new ElementRemovedEventArgs();    //create new arguments object
                eventArgs.Value = value;                                             //arguments creatiom
                ElementRemoved(eventArgs);                                             //event creation
            }
        }

    }
}
