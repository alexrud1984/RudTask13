using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckStack();
            CheckQueue();
        }

        static void CheckStack()
        {
            DynamicStack<Something> stack = new DynamicStack<Something>(5);
            stack.BufferIsEmpty += BufferIsEmpty;
            stack.BufferIsFull += BufferIsFull;
            stack.ElementRemoved += RemoveFromStack;
            stack.NewElemntAdded += AddToStack;
            Console.WriteLine("Check Stack");

            stack.Print();

            stack.Push(new Something ("1"));
            stack.Print();

            Console.WriteLine("Peek " + stack.Peek());
            stack.Print();

            stack.Pop();
            stack.Print();

            try
            {
                for (int i = 0; i < 6; i++)
                {
                    stack.Push(new Something(i.ToString()));
                    stack.Print();
                }
            }
            catch (AddToFullException ex)
            {
                Console.WriteLine(ex);
            }
            stack.Print();

            Console.WriteLine("Peek " + stack.Peek());
            stack.Print();

            try
            {
                for (int i = 0; i < 6; i++)
                {
                    stack.Pop();
                    stack.Print();
                }
            }
            catch (TakeFromEmptyException ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void CheckQueue()
        {
            DynamicQueue<Something> queue = new DynamicQueue<Something>(5);
            queue.BufferIsFull += BufferIsFull;
            queue.BufferIsEmpty += BufferIsEmpty;
            queue.NewElemntAdded += AddToQueue;
            queue.ElementRemoved += RemoveFromQueue;

            Console.WriteLine("Check queue");

            queue.Print();

            queue.Enqueue(new Something("1"));
            queue.Print();

            Console.WriteLine ("Peek: " + queue.Peek());
            queue.Print();

            queue.Dequeue();
            queue.Print();

            try
            {
                for (int i = 0; i < 6; i++)
                {
                    queue.Enqueue(new Something(i.ToString()));
                    queue.Print();
                }
            }
            catch (AddToFullException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Peek: " + queue.Peek());
            queue.Print();

            Console.WriteLine("Peek: " + queue.Peek());
            queue.Print();

            try
            {
                for (int i = 0; i < 6; i++)
                {
                    queue.Dequeue();
                    queue.Print();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("That's all");
            Console.ReadKey();
        }

        static void BufferIsFull(Buffer<Something> buffer, BufferIsFullEventArgs eventArgs)
        {
            Console.WriteLine("Id {0}: {1}", buffer.ID, eventArgs.Reason);
        }

        static void BufferIsEmpty(BufferIsFullEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Reason);
        }

        static void AddToQueue(NewElementAddedEventArgs eventArgs)
        {
            Console.WriteLine("{0} been added.", eventArgs.Value);
        }

        static void RemoveFromQueue(NewElementAddedEventArgs eventArgs)
        {
            Console.WriteLine("{0} been removed from queue.", eventArgs.Value);
        }

        static void AddToStack(NewElementAddedEventArgs eventArgs)
        {
            Console.WriteLine("{0} been added.", eventArgs.Value);
        }

        static void RemoveFromStack(NewElementAddedEventArgs eventArgs)
        {
            Console.WriteLine("{0} been removed from queue.", eventArgs.Value);
        }

    }
}
