using System.Linq;
using System;
using System.Drawing;

namespace Structures3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Village = new Village("BIVTIKI");
            //Village.AddGnomy(gnomys);

            Console.WriteLine();
            Village.Print();
        }
    }


    public struct Gnomy
    {
        public enum Color
        { 
            Black=1, Brown=2, Red=3
        }
        public enum Clothes
        {
            Blue = 5, Green = 6, Yellow = 7
        }
        private string _name;
        private int _age;
        private Color _hair;
        private Clothes _clothes;
        private string _gender;

        public string Name => _name;
        public int Age => _age;
        public string Gender => _gender;
        public Color Hair => _hair; public Clothes Scirt => _clothes;
        public Gnomy(string name, int age, Color hair, Clothes clothes, string gender)
        {
            this._name = name;
            _age = age;
            _hair = Color.Black;
            _clothes = Clothes.Blue;
            _gender = gender;
        }
        public void Print()
        {
            Console.WriteLine($"Gnomy: {_name}, {_age}, {_hair}, {_clothes}, {_gender}");
        }
    }
    public struct Village
    {
        private string _name;
        private Gnomy[] _gnomys;
        public string Name => _name;
        public Gnomy[] Gnomys => _gnomys;


        public Village(string name)
        {
            _name = name;
            _gnomys = new Gnomy[8]
            {
                new Gnomy("Bob", 53, Gnomy.Color.Black, Gnomy.Clothes.Blue, "m"),
                new Gnomy("Marley", 20, Gnomy.Color.Brown, Gnomy.Clothes.Blue,"m"),
                new Gnomy("Villy", 18, Gnomy.Color.Red, Gnomy.Clothes.Green,"f"),
                new Gnomy("Vlada", 15, Gnomy.Color.Brown, Gnomy.Clothes.Yellow,"f"),
                new Gnomy("Antuan", 52, Gnomy.Color.Black, Gnomy.Clothes.Blue,"m"),
                new Gnomy("Boba", 13, Gnomy.Color.Black, Gnomy.Clothes.Blue, "m"),
                new Gnomy("Figgy", 21, Gnomy.Color.Brown, Gnomy.Clothes.Green, "f"),
                new Gnomy("Luisa", 20, Gnomy.Color.Black, Gnomy.Clothes.Blue,"f")
            };
        }
        public void AddGnomy(Gnomy gnomy)
        {
            Array.Resize(ref _gnomys, _gnomys.Length + 1);
            _gnomys[_gnomys.Length - 1] = gnomy;
        }
        public void AddGnomy(Gnomy[] gnomys)
        {
            foreach (Gnomy gnomy in gnomys)
            {
                AddGnomy(gnomy);
            }
        }
        public void Print()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Gnomys:");
            foreach (var gnomy in _gnomys)
            {
                gnomy.Print();
            }
        }
    }
}
