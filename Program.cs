using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Villagers village = new Villagers();
            
            foreach (var person in village.People)
            {
                Console.WriteLine($"{person.Gender}, {person.Hair}, {person.Accessories}");
            }
        }

        public struct Character
        {
            private string _gender;
            private string _hair;
            private string _accessories;
            private bool _hat;
            private bool _hasBeard;
            
            public string Gender => _gender;
            public string Hair => _hair;
            public string Accessories => _accessories;
            public bool Hat => _hat;
            public bool HasBeard => _hasBeard;
            
            public Character(string Gender, string Hair, string Accessories, bool Hat, bool HasBeard)
            {
                _gender = Gender;
                _hair = Hair;
                _accessories = Accessories;
                _hat = Hat;
                _hasBeard = HasBeard;
            }
        }
        
        public struct Villagers
        {
            private Character[] _people;

            public Character[] People => _people;

            public Villagers()
            {
                _people = new Character[]
                {
                    new Character("male",   "black",  "stick",  true,  true),
                    new Character("male",   "gray",   "bag",    true,  false),
                    new Character("female", "orange", "basket", false, false),
                    new Character("female", "black",  "none",   true,  false),
                    new Character("male",   "gray",   "bucket", false, true),
                    new Character("male",   "black",  "none",   true,  false),
                    new Character("male",   "brown",  "stick",  false, false),
                    new Character("female", "gray",   "none",   true,  false)
                };
            }
        }
    }
}