using System.ComponentModel.Design;
using System.Text.RegularExpressions;
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
            private bool _isSetted;

            private static int _passed;
            private static double standart;
            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;
            public static double PassedTheStandard => _passed;
            public bool HasPassed
            {
                get
                {
                    if (_result < standart && _isSetted)
                    {
                        return true;
                    }
                    return false;
                }
            }
            static Participant()
            {
                _passed = 0;
                standart = 100;
                
            }

            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0;
                _isSetted = false;
               
            }
            public void Run(double result)
            {
                if (!_isSetted)
                {
                    _result = result;
                    _isSetted = true;
                    if (_result < standart)
                    {
                        _passed++;
                    }
                }
            }
            public void Print()
            {
                return;
            }
        }
    }
    
}
