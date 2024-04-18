using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class Request : IEquatable<Request> // Type safe
    {
        public int Id { get; set; }
        public string RequestText { get; set; }
        public int Raised_By { get; set; }
        public string Status { get; set; }
        public int Closed_By { get; set; }

        public bool Equals(Request? other) => this.Id.Equals(other.Id);

        //public bool Equals(Request? other)
        //{
        //    return this.Id.Equals(other.Id);
        //}
    }
}
