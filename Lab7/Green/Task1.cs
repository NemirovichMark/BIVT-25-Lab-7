using System.Xml.Linq;

namespace Lab7.Green
{
    public class Task1
    {
        public struct Participant
        {
            // Данные участника
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result;

            // Общие значения для всех участников
            private static double _standard;
            private static int _passed;

            static Participant()
            {
                _standard = 100; // норматив из условия
                _passed = 0; // число сдавших норматив
            }

            public Participant(string surname, string group, string trainer)
            {
                // Если передали null - возвращаю пустую строку
                _surname = surname == null ? "" : surname;
                _group = group == null ? "" : group;
                _trainer = trainer == null ? "" : trainer;

                // 0 — значит участник ещё не бежал
                _result = 0;
            }

            public string Surname { get { return _surname; } }
            public string Group { get { return _group; } }
            public string Trainer { get { return _trainer; } }
            public double Result { get { return _result; } }

            // Всего выполнивших норматив
            public static int PassedTheStandard { get { return _passed; } }

            // Проверка на выполнение норматива
            public bool HasPassed
            {
                get
                {
                    // 0 метров - не выполнил
                    if (_result == 0) return false;

                    // если уложился в норматив, то выполнил
                    return _result <= _standard;
                }
            }

            public void Run(double newResult)
            {
                if (_result != 0)
                    return;

                // записываю результат
                _result = newResult;

                // если выполнил, увеличиваю общий счётчик
                if (HasPassed)
                    _passed++;
            }

            public void Print()
            {
                Console.WriteLine($"{Surname} {Group} {Trainer} {Result} {HasPassed}");
            }
        }
    }
}
