using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Village
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var village = new Village("Село Лагучее");
            village.Print();
        }
        
        public struct People
        {
            public enum Color
            {
                blond = 1,
                dark = 2,
                grey = 3,
                blue = 4,
                black = 5
            }

            private string _hat;
            private string _gender;
            private Color _hairColor;
            private Color _clothingColor;
            

            public string Hat => _hat;

            public string Gender => _gender;

            public Color HairColor => _hairColor;

            public Color ClothingColor => _clothingColor;

            public People(string hat, string gender, Color hairColor, Color clothingColor)
            {
                _hat = hat;
                _gender = gender;
                _hairColor = hairColor;
                _clothingColor = clothingColor;
            }

            public void Print()
            {
                Console.WriteLine($"Головной убор: {Hat}, Пол: {Gender}, Волосы: {HairColor}, Цвет одежды: {ClothingColor}");
            }
        }

    
        public struct Village
        {
            private string _name;
            private People[] _peoples;

            public string Name => _name;
            public People[] Peoples => _peoples;

            public void AddPeople(People people)
            {
                Array.Resize(ref _peoples, _peoples.Length + 1);
                _peoples[_peoples.Length - 1] = people;
            }
            public Village(string name)
            {
                _name = name;
                _peoples = new People[]
                {
                    new People("hat", "female", People.Color.grey, People.Color.dark),
                    new People("cap", "male", People.Color.blond, People.Color.blue),
                    new People("handkerchief", "female", People.Color.grey, People.Color.grey),
                    new People("hat2", "male", People.Color.dark, People.Color.dark),
                    new People("cap2", "female", People.Color.blond, People.Color.black),
                };
            }
            public void AddPeoples(People[] peoples)
            {
                foreach (People people in peoples)
                {
                    AddPeople(people);
                }
            }

            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine("Жители:");
                foreach (var people in _peoples)
                {
                    people.Print();
                }
            }
        }

    }
}
