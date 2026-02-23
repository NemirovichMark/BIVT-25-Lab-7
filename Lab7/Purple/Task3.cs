namespace Lab7.Purple
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _topPlace;
            private double _totalMark;

            public string Name => _name;

            public string Surname => _surname;

            public double[] Marks
            {
                get
                {
                    if (_marks == null)
                        return default(double[]);
                    double[] marks = new double[_marks.Length];
                    Array.Copy(_marks, marks, marks.Length);
                    return marks;
                }
            }

            public int[] Places => _places;

            public int TopPlace => _topPlace;

            public double TotalMark => _totalMark;

            public int Score => _places.Sum();
            
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;

                _marks = new double[7];
                _places = new int[7];
            }

            public void Evaluate(double result) //установка оценки
            {
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = result;
                        break;
                    }
                }
            }
            
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) 
                    return;

                int n = participants.Length; //участники
                int judges = 7; 

                // Сбрасываем по нулям все перед расчетом
                for (int i = 0; i < n; i++)
                {
                    participants[i]._topPlace = int.MaxValue;
                    participants[i]._totalMark = 0;
                    for (int j = 0; j < judges; j++)
                        participants[i]._places[j] = 0;
                }
                
                for (int judge = 0; judge < judges; judge++)
                {
                    for (int i = 0; i < n; i++) // по каждому участнику
                    {
                        int betterCount = 0;  
                        for (int j = 0; j < n; j++) // считаем, сколько участников получили большую оценку
                        {
                            if (participants[j]._marks[judge] > participants[i]._marks[judge])
                                betterCount++;
                        }

                        participants[i]._places[judge] = betterCount + 1; // место участника у текущего судьи
                        
                        if (participants[i]._places[judge] < participants[i]._topPlace) // обновляем лучшее место
                            participants[i]._topPlace = participants[i]._places[judge];

                        participants[i]._totalMark += participants[i]._marks[judge]; 
                        // плюсуем оценку у этого судьи к totalMark

                    }
                }

                // Сортируем по последнему судье
                Array.Sort(participants, (x, y) => x._places[6].CompareTo(y._places[6])); //6 - последний судья
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) =>
                {
                    int xPlacesSum = x.Score; //сумма мест первого участника
                    int yPlacesSum = y.Score;
                    if (xPlacesSum != yPlacesSum)
                        return xPlacesSum.CompareTo(yPlacesSum);
                    
                    if (x.TopPlace != y.TopPlace)
                        return x.TopPlace.CompareTo(y.TopPlace);
                    
                    return y._totalMark.CompareTo(x._totalMark); // по убыванию totalMark
                });
            }

            public void Print()
            {
                Console.WriteLine(_name, _surname, string.Join(",",_places), _totalMark, string.Join(",",_marks));
            }
        }
    }
}