using System.Xml.Linq;

namespace Lab7.Green
{
    public class Task1
    {
        public struct Participant
        {
            // поля
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result;
            private static readonly  double Normat;
            private static int _passed;

            // свойства
            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;
            public static int PassedTheStandard => _passed;

            public bool HasPassed // Публичное логическое свойство только для чтения,
                                  // которое возвращает прошла участница норматив или нет.

            {
                get
                {
                    if (_result == 0)
                        return false;

                    return _result <= Normat; // сравниваем результат участницы с нормативом 
                                              
                }   
            }
            // конструктор
            static Participant()
            {
                Normat = 100; // значение норматива 
                _passed = 0; // Счётчик участниц, прошедших норматив
            }
            public Participant(string surname, string group,string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
            }
            public void Run(double result)
            {
                if( _result == 0)
                {
                    _result = result; // проверяем, первый ли это результат участницы.
                                      // Если да , то мы записываем его в поле _result.

                    if (result <= Normat) // кол-во прошедших норматив увеличивается
                        _passed++;
                }

                
                   
            }
            public void Print()
            {
                Console.WriteLine($"Фамилия: {Surname}");
                Console.WriteLine($"Группа: {Group}");
                Console.WriteLine($"Тренер: {Trainer}");
                Console.WriteLine($"Результат: {Result}");
                Console.WriteLine($"Прошла  ли норматив? : {(HasPassed ? "Да" : "Нет")}");
            }




        }
    }
}

