namespace ConsoleApp4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    namespace ConsoleApp1
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                var Villadge = new Villadge("Sunny");
                Villadge.Print();
            }
            public struct Character
            {
                private string _name;
                private string _surname;
                private string _job;
                private int _age;
                private string _hair;
                private string _weapon;
                public string Name => _name;
                public string Surname => _surname;
                public string Job => _job;
                public int Age => _age;
                public string Hair => _hair;
                public string Weapon => _weapon;
                public Character(string name, string surname, string job, int age, string hair, string weapon)
                {
                    _name = name;
                    _surname = surname;
                    _job = job;
                    _age = age;
                    _hair = hair;
                    _weapon = weapon;
                }
                public void Print()
                {
                    Console.WriteLine($"{Name},{Surname},{Job},{Age},{Hair},{Weapon}");
                }

            }
            public struct Villadge
            {
                private string _name;
                private Character[] _characters;
                public string Name => _name;
                public Character[] Characters => _characters;
                public Villadge(string name)
                {
                    _name = name;
                    _characters = new Character[8]
                    {
                    new Character ("Boba","Big","Gaurd",35,"Brown","Sword"),
                    new Character ("Den","Belmont","Craftsman",20,"Light","none"),
                    new Character ("Lucy","Light","girlie girl",19,"Red","none"),
                    new Character ("Lucy","Light","Traveler",25,"Brown","none"),
                    new Character ("Biba","Big","Gaurd",35,"Brown","bucket"),
                    new Character ("Bobo","Big","Student",13,"Brown","none"),
                    new Character ("Boba","Big","Hunter",25,"Light Brown","Sword"),
                    new Character ("Lilia","Blue","Seller",25,"White","тапок"),
                    };
                }
                public void Print()
                {
                    Console.WriteLine(_name);
                    foreach (var character in Characters)
                    {
                        character.Print();
                    }
                }
            }
        }
    }

}
