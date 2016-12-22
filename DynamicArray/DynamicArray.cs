using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class DynamicArray<T> : IDynamicArray<T>
    {
        private const int grFactor = 2;
        private int capacity;
        private int size;
        private T[] matrix;

        public T this[int index]
        {
            get
            {
                if (index >= size || index<0)
                {
                    return default (T);
                }
                return matrix[index];
            }

            set
            {
                if (index >= size)                      //if index out of size
                {
                    size = index;                       //change size to index to compare with capacity
                    matrix = Expand();                  //than try expand matrix
                    size++;
                }
                matrix[index] = value;
            }
        } 


        public DynamicArray(int userCapacity)
        {
            capacity = userCapacity;
            matrix = new T[capacity];
            size = 0;
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public void Add(T value)
        {
            matrix=Expand();
            matrix[size] = value;
            size++;
        }

        public T Get(int index)
        {

            return this[index];                     //return via the indexer property
        }

        public void Insert(int index, T value)
        {
            if (index >= size)                      //if index out of size
            {
                size = index;                       //change size to index to compare with capacity
                matrix = Expand();                  //than try expand matrix
                matrix[index] = value;              //put the value in the end of matrix  
            }
            else
            {
                matrix = Expand();                    //try to expand to check/create if need a place
                for (int i = size; i >= index; i--)  //move elemetnts to the right until get index place
                {
                    matrix[i] = matrix[i - 1];
                }
                matrix[index] = value;                //insert elemet to his place
            }
            size++;                                  //increase size
        }

        public void Remove(int index)
        {
            if (index >= size || index<0)                         //prevent to remove from emty array or out of size elements
            {
                return;
            }

            for (int i = index; i < (size-1); i++)          //move all elements to the left until deleted index reached
            {
                matrix[i] = matrix[i + 1];
            }
            size--;
            Shrink();                                   //try to shrink array arfter remove element
        }

        private T[] Expand ()
        {
            if (size < capacity)
            {
                return matrix;                       //no need to expand if size less than capacity
            }

            T[] tempMatrix;
            while (capacity <= size)                //increase capacity while it less than size
            {
                capacity *= grFactor;
            }

            tempMatrix = new T[capacity];           //create new matrix with new capacity
             
            for (int i = 0; i < matrix.Length; i++)
            {
                tempMatrix[i] = matrix[i];          //copy old matrix to the new
            }
            return tempMatrix;
        }

        private void Shrink()
        {
            if (size * grFactor * 2 < capacity)             //check if size less than capacity more than in 4 times
            {
                T[] tempMatrix;
                capacity = capacity / 2 / grFactor;
                tempMatrix = new T[capacity];               //create new matrix less that original
                for (int i = 0; i < size; i++)
                {
                    tempMatrix[i] = matrix[i];               //copy old matrix to the new
                }
                matrix = tempMatrix;
            }
        }

    }
}
