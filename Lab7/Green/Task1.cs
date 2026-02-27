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
            private bool _HasPassed;

            private static readonly int _norm;
            private static int _passed;
            


            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;
            public bool HasPassed => _HasPassed;

            public static int PassedTheStandard => _passed;
            

            static Participant()
            {
                _norm = 100;
                _passed = 0;
            }
            public Participant(string in_surname, string in_group,string in_trainer)
            {
                _surname=in_surname;
                _group=in_group;
                _trainer = in_trainer;
            }


            public void Run(double in_result)
            {
                if (_result == 0.0)
                {
                    _result = in_result;
                    if (_result <= _norm)
                    {
                        _HasPassed = true;
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
                Console.WriteLine(_HasPassed);
            }


        }
    }
}
