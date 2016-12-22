using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class Something : IComparable <Something>              //something to sort
    {
        public static int Count { private set; get; }   //lets count objects to generate Id
        public int Id { private set; get; }             //obj Id
        public string Name { set; get; }                //this field we will sort


        public int CompareTo(Something other)
        {
            
            return (this.Name.CompareTo(other.Name));
        }

        public override string ToString()
        {
            string str = this.Id + " " + this.Name;
            return str;
        }

        public Something(string name)
        {
            Count++;
            Id=Count;
            Name = name;
        }

    }
}
