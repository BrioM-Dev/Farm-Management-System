using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagementSystem
{
    internal interface IManagement
    {
        void AddAnimal(string AnimalID, string AnimalName, int AnimalAge, string Species);
        void RemoveAnimal(string AnimalID);
        void ListAnimals();
    }
}
