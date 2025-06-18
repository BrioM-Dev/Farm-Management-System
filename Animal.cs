using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagementSystem
{
    internal class Animal
    {
        private string AnimalID;
        private string AnimalName;
        private int AnimalAge;
        private string Species;

        public string GetAnimalID()
        {
            return AnimalID;
        }
        public string GetAnimalName()
        {
            return AnimalName;
        }
        public int GetAnimalAge()
        {
            return AnimalAge;
        }
        public string GetSpecies()
        {
            return Species;
        }

        public Animal(string AnimalID, string AnimalName, int AnimalAge, string Species) 
        {
            this.AnimalID = AnimalID;
            this.AnimalName = AnimalName;
            this.AnimalAge = AnimalAge;
            this.Species = Species;
        }     
    }
}
