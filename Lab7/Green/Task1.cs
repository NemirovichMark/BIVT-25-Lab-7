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
            private bool _runCalled;

            private static readonly double _standard;
            private static int _passed;

            static Participant()
            {
                _standard = 100.0;
                _passed = 0;
            }

            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0;
                _runCalled = false;
            }

            public string Surname
            {
                get
                {
                    if (_surname == null) return "";
                    return _surname;
                }
            }

            public string Group
            {
                get
                {
                    if (_group == null) return "";
                    return _group;
                }
            }

            public string Trainer
            {
                get
                {
                    if (_trainer == null) return "";
                    return _trainer;
                }
            }

            public double Result => _result;

            public static int PassedTheStandard => _passed;

            public bool HasPassed
            {
                get
                {
                    if (!_runCalled) return false;
                    return _result <= _standard;
                }
            }

            public void Run(double result)
            {
                if (_runCalled) return;
                _result = result;
                _runCalled = true;
                if (_result <= _standard)
                {
                    _passed++;
                }
            }   
            public void Print()
            {
                Console.WriteLine($"Участница: {Surname}, группа: {Group}, тренер: {Trainer}, результат: {Result}, прошла: {HasPassed}");
            }
        }
    }

    
}
