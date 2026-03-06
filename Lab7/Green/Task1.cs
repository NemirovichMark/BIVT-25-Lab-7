using System.Xml.Linq;

namespace Lab7.Green
{
        public class Task1
    {
        public struct Participant
        {
            //поля
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result;
            private bool _hasPassed;
            

            //свойства
            public string Surname
            {
                get { return _surname; } // только для чтения
            }
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result =>_result;

            private const double STANDARD_RESULT = 100;
            private static int _passed = 0;
            
            public bool HasPassed => ( _result != 0 && _result <= STANDARD_RESULT);
            //
            public static int PassedTheStandard => _passed;

            //Конструктор

            static Participant()
            {
               _passed = 0;
            }

            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0;
            
            }
            public void Run(double result)
            {
                if (_result == 0 && result > 0)
                {
                    _result = result;
                    if (result <= STANDARD_RESULT)
                        _passed++;
                }
            }


            public void Print()
            {
                Console.WriteLine(Surname, Group, Trainer, Result, HasPassed );
            }
        }
    }
}
