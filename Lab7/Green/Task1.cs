using System.Xml.Linq;

namespace Lab7.Green
{
    public class Task1
    {
        public struct Participant
        {
            //приват поля
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result = 0;

            private static double _standard;

            //статическое поле и свойство пассед
            private static int _passed;
            public static int Passed => _passed;

            //свойства
            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;

            //публичное лог свойство
            public bool HasPassed => _result <= _standard && _result > 0;

            static Participant()
            {
                _standard = 100;
                _passed = 0;
            }

            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
            }

            //метод
            public void Run(double result)
            {
                if (_result == 0)
                {
                    _result = result;
                    if (HasPassed)
                    {
                        _passed++;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(_surname);
                Console.WriteLine(_group);
                Console.WriteLine(_trainer);
                Console.WriteLine(_result);
            }
        }
    }
}
