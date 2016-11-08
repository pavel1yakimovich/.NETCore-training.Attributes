using System;
using System.Collections.Generic;

namespace Attributes
{
    // Should be applied to classes only.
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InstantiateUserAttribute : Attribute
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public InstantiateUserAttribute(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public InstantiateUserAttribute(string firstName, string lastName)
        {
            this.Id = null;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
