using System.Xml.Linq;
using static Lab7.Green.Task1;

namespace Lab7.Green
{
    
    public class Task1
    {
        public struct Participant
        {
            private string _lastname;
            private string _group;
            private string _couchlm;
            private double _result;
            private static int _norm;
            private static int _passed;
            public static int PassedTheStandard => _passed;
            public string Surname => _lastname;
            public string Group => _group;
            public string Trainer => _couchlm;
            public double Result => _result;
            static Participant()
            {
                _norm = 100;
                _passed = 0;
            }
            public bool HasPassed
            {
                get
                {
                    if (_result <= _norm)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public Participant(string name, string group, string trainer)
            {
                _lastname = name;
                _group = group;
                _couchlm = trainer;
                _result = 0;
            }
            public void Run(double result)
            {
                if (_result > 0)
                {
                    return;
                }
                _result = result;
                if (result <= _norm)
                {
                    _passed++;
                }
            }
            public void Print()
            {
                Console.WriteLine($"Фамилия: {_lastname}");
                Console.WriteLine($"Группа: {_group}");
                Console.WriteLine($"Тренер: {_couchlm}");
                Console.WriteLine($"Результат:{_result}" );
                Console.WriteLine($"Норматив: {_norm} сек");
                
                
            }
        }
    }
}
