using System.Xml.Linq;

namespace Lab7.Green
{
    public class Task1
    {
        public struct Participant
        {
            //приватные поля
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result;

            private static readonly double _standard;
            private static int _passed;

            //свойства
            static public int PassedTheStandard=> _passed;

            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;

            public bool HasPassed
            {
                get
                {
                    return _result != 0 && _result<=_standard;
                }
            }

            //конструктор
            static Participant()
            {
                _standard = 100;
                _passed = 0;
            }

            public Participant(string surname,string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0;
            }

            //методы
            public void Run(double result)
            {
                if (_result == 0)
                {
                    _result = result;
                    if (_result <= _standard)
                    {
                        _passed++;
                    }
                }
            }

            public void Print()
            {
                if (_surname != null)
                    Console.WriteLine(_surname);

                if (_group != null)
                    Console.WriteLine(_group);

                if (_trainer != null)
                    Console.WriteLine(_trainer);

                Console.WriteLine(_result);
            }
        }
    }
}
