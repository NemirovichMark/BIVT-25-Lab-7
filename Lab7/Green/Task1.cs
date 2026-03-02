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
            private static double _standart;
            private static int _passed;
            

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
                    {
                        return false;
                    }
                    else if (_result <= _standart)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0;
            }

            static Participant()
            {
                _standart = 100;
                _passed = 0;
            }

            public void Run(double result)
            {
                if (_result == 0)
                {
                    _result = result;
                    if(result <= _standart)
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
