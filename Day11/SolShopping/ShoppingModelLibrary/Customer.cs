using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }
        public override string ToString()
        {
            return Id + " " + Name + " " + Age + " " + Phone;
        }

    }
}
