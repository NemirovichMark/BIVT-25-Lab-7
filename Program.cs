using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            A Mellstroy = new A("меллстройность", 67);

            B Artur = new B("Артур", 52, "привет артур", false);

            A nineMice = new B("9mice", 9, "полная дилара");

            B Aleksandr = nineMice as B;
            Aleksandr.Method();
        }
    }
    public class A
    {
        // поля
        protected string _name;
        protected int _rank;

        public string Name => _name;
        public int Rank => _rank;

        public A(string name, int rank)
        {
            _name = name;
            _rank = rank;
        }

        public virtual void Method()
        {
            Console.WriteLine("Method in Class A");
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name: {_name}, Rank: {_rank}.");
        }
    }
    public class B : A
    {
        private string _meme;
        public bool _isRed;

        public string Meme => _meme;

        public B(string name, int rank, string meme) : base(name, rank)
        {
            _meme = meme;
            _isRed = true;
        }
        public B(string name, int rank, string meme, bool isRed) : this(name, rank, meme)
        {
            _isRed = isRed;
        }
        public override void Method()
        {
            Console.WriteLine("Method in Class B");
        }
        public override void Print()
        {
            Console.WriteLine($"Name: {_name}, Rank: {_rank}, Meme: {_meme}, Красный: {_isRed}");
        }
    }
}
