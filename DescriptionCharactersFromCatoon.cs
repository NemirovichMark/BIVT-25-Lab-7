using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

    }

    public struct Person
    {
        public string _name;
        public string _gender;
        public string[] _dress;
        public bool _hasBeard;
        public string _formOfArms;
        public string _whereBag;

        public string Name => _name;
        public string Gender => _gender;
        public string[] Dress => _dress.ToArray();
        public bool HasBeard => _hasBeard;
        public string FormOfArms => _formOfArms;
        public string Bag => _whereBag;

        public Person(string name, string gender, string[] dress, bool hasBeard, string formOfArms, string whereBag)
        {
            _name = name;
            _gender = gender;
            _dress = dress;
            _hasBeard = hasBeard;
            _formOfArms = formOfArms;
            _whereBag = whereBag;
        }

    }
    public struct Village
    {
        private Person[] _persons;

        public Person[] Persons => _persons.ToArray();

        public Village(string n) {

            _persons = new Person[8]
            {
                new Person("Tom", "m", new string[3]{"jacket", "hat", "boots"}, true, "straight", "left shoulder" ),
                new Person("Fill", "m", new string[3]{"jacket", "hat", "boots"},false, "left on 90 degrees right straight", "left shoulder"),
                new Person("Jenny", "w", new string[3]{"jacket", "not hat", "boots"}, false, "right on 90 degrees left straight", "left shoulder"),
                new Person("Bred", "m", new string[3]{"jacket", "hat", "boots"}, false, "on the breast", "left shoulder"),
                new Person("Oliver", "m", new string[3]{"jacket", "hat", "boots"}, true, "straight", "left shoulder"),
                new Person("Lily", "w", new string[3]{"jacket", "hat", "boots"}, false, "straight", "left shoulder"),
                new Person("Freya", "w", new string[3]{"jacket", "hat", "boots"}, false, "left on 90 degrees right straight", "on the right arm"),
                new Person("Amelia", "mw", new string[3]{"jacket", "hat", "boots"}, false, "left on 90 degrees right straight", "left shoulder")
            };
        }
    }
}




