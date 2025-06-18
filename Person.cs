using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagementSystem
{
    internal abstract class Person
    {
        private string Name;
        private int Age;
        private string ID;
        public Person(string Name, int Age, string ID)
        {
            this.Name = Name;
            this.Age = Age;
            this.ID = ID;
        }
    }
}
