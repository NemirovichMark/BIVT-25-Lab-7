using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            A objA = new A("сливы", 3000000);
            B objB = new B("сливы", 3000000 ,3);
            objB.Method();
        }
    }
    public class A
    {
        protected string _name;
        protected int _age;

        public string Name => _name;
        public int Age => _age;

        public A(string name, int age) 
        { 
            _name = name;
            _age = age;
        }
        public virtual void Method()
        {
            Console.WriteLine("метод в А");
        }
        public void Print()
        {
            Console.WriteLine($"{_name} {_age}");
        }
    }
    public class B : A
    {
        private int _skolko_yablock;
        private bool _ti_krut;
        public int Skolko => _skolko_yablock;
        public bool Krut => _ti_krut;
        public B(string name, int age, int kol_yab) : base(name, age)
        {
            _skolko_yablock = kol_yab;
            _ti_krut = true;
        }
        public B(string name, int age, int kol_yab, bool krut) :  this ( name, age, kol_yab)
        {
            _ti_krut = krut;
        }
        public override void Method()
        {
            Console.WriteLine("метод в B");
        }
        public void Print()
        {
            Console.WriteLine($"{_name} {_age} {_skolko_yablock}");
        }
    }


}
