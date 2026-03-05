using System.Collections.Specialized;
using System.Xml.Linq;

namespace Lab7.Green
{
    public class Task1
    {
        public struct Participant
        {
            // Поля
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result;
            private static double _norma;
            private static int _passed;

            // Свойства
            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;
            public static int PassedTheStandard => _passed;
            public bool HasPassed
            {
                get
                {
                    if (_result == 0)
                        return false;
                    else
                    {
                        if (_result <= _norma)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
            // Конструктор
            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0;
            }

            //Статический конструктор
            static Participant()
            {
                _norma = 100;
                _passed = 0;
            }

            // Метод
            public void Run(double result)
            {
                if (_result == 0)
                {
                    _result = result;
                    if (result <= _norma)
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
                if (_result == 0)
                {
                    Console.WriteLine("Резултат: ещё не прошел");
                }
                else
                {
                    Console.WriteLine($"Результат: {_result} сек");
                    Console.WriteLine($"Норматив: {(_result <= _norma ? "прошел" : "не прошел")}");
                }
                Console.WriteLine();
            }
        }
    }
}
