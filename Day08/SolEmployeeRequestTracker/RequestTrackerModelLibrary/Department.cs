using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_Head { get; set; }

        /// <summary>
        /// Checks if the Department names of two Department objects are the same 
        /// </summary>
        /// <param name="obj">Department Object</param>
        /// <returns>True if the department names are same, else false</returns>
        public override bool Equals(object? obj)
        {
            return this.Name.Equals((obj as Department).Name);
        }

        /// <summary>
        /// Concatenates and returns the values of Department object
        /// </summary>
        /// <returns>Values of Department Object as String</returns>
        public override string ToString()
        {
            return Id + " " + Name + " " + Department_Head;
        }
    }
}
