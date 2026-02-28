using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            A objA = new A("Вася", "Иванов", 18);
            Console.WriteLine(objA.Name);
            objA.Print();
            B objB = new B("Bася", "Пухляк", 18, "Линукс"); // Первый коструктор
            B objBNEW = new B("Bася", "Пухляк", 18, "Линукс", true); // Второй
            objA.Method();
            objB.Method();
            objBNEW.Print();
            B var = objA as B;
            
        }
    }
    public class A
    {
        protected string _name;
        protected string _surname;
        protected int _age;
        public string Name => _name;
        public string Surname => _surname;
        public int Age => _age;
        public A(string Name, string Surname, int Age)
        {
            _name = Name;
            _surname = Surname;
            _age = Age;
        }
        public virtual void Method()
        {
            Console.WriteLine("Method in class A");
        }
        public void Print()
        {
            Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Возраст: {_age}");
        }

    }
    public class B : A
    {
        private string _word;
        private bool _isValid;
        public string Word => _word;
        public bool IsValid => _isValid;
        public B(string Name, string Surname, int Age, string Word) : base(Name, Surname, Age)
        {
            _word = Word;
            _isValid = true;
        }
        public B(string Name, string Surname, int Age, string Word, bool IsValid) : this(Name, Surname, Age, Word)
        {
            _word = Word;
            _isValid = IsValid;
        }
        public override void Method()
        {
            Console.WriteLine("Method in class B");
        }
        public void Print()
        {
            Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Возраст: {_age}, Слово: {_word}");
        }
    }
}
