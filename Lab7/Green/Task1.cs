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
            private bool _resultCheck;

            private static readonly double _standart;
            private static int _passed;

            static Participant()
            {
                _standart = 100.0;
                _passed = 0;
            }

            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0;
                _resultCheck = false;
            }

            public string Surname
            {
                get
                {
                    if (_surname == null) return string.Empty; ;
                    return _surname;
                }
            }

            public string Group
            {
                get
                {
                    if (_group == null) return string.Empty; ;
                    return _group;
                }
            }

            public string Trainer
            {
                get
                {
                    if (_trainer == null) return string.Empty;
                    return _trainer;
                }
            }

            public double Result
            {
                get
                {
                    if (_result == 0) return 0;
                    return _result;
                }
            }
            public static int PassedTheStandard
            {
                get { return _passed; }
            }

            public bool HasPassed
            {
                get
                {
                    if (!_resultCheck) return false;
                    return _result <= _standart;
                }
            }

            public void Run(double result)
            {
                if (_resultCheck == false)
                {
                    _result = result;
                    _resultCheck = true;

                    if (HasPassed)
                    {
                        _passed++;
                    }
                }

            }

            public void Print()
            {
                Console.WriteLine($"Фамилия: {_surname}");
                Console.WriteLine($"Группа: {_group}");
                Console.WriteLine($"Тренер: {_trainer}");
                Console.WriteLine($"Результат: {(_resultCheck ? _result.ToString() : "не указан")}");
                Console.WriteLine($"Норматив: {_standart}");
                Console.WriteLine($"Прошла норматив: {(_resultCheck ? (HasPassed ? "да" : "нет") : "неизвестно")}");
                Console.WriteLine($"Всего прошли норматив: {_passed}");
            }
        }
    }

}
