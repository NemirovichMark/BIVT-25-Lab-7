using System.Xml.Linq;

namespace Lab7.Green
{
    public class Task1
    {
        public struct Participant
        {
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result;

            private static readonly int _norm;
            private static int _passed;

            static Participant()
            {
                _norm = 100;
                _passed = 0;
            }

            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0;
            }

            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;

            public static int PassedTheStandard => _passed;

            public bool HasPassed => _result <= _norm && _result != 0;

            public void Run(double result)
            {
                if (_result != 0)
                    return;

                _result = result;

                if (_result <= _norm)
                    _passed++;
            }

            public void Print()
            {
                Console.WriteLine($"Фамилия: {_surname}");
                Console.WriteLine($"Группа: {_group}");
                Console.WriteLine($"Тренер: {_trainer}");
                Console.WriteLine($"Результат: {_result}");
                Console.WriteLine($"Норматив выполнен: {HasPassed}");
            }

        }
    }
}