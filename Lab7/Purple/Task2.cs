namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            
            public string Surname => _surname;
            
            public int Distance => _distance;
            
            public int[] Marks
            {
                get
                {
                    if (_marks == null) 
                        return default(int[]);
                    int[] Marks = new int[_marks.Length];
                    Array.Copy(_marks, Marks, Marks.Length);
                    return Marks;
                }
            }

            public double Result
            {
                get
                {
                    int[] sortedMarks = new int[5];
                    Array.Copy(_marks, sortedMarks, 5);
                    Array.Sort(sortedMarks);
                    int _judgeScore = sortedMarks[1] +  sortedMarks[2] + sortedMarks[3];

                    int _distanceScore = Math.Max(60 + (_distance - 120)*2, 0);
                    
                    return _judgeScore + _distanceScore;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
                for (int i = 0; i < 5; i++)
                    _marks[i] = 0;
            }
            
            public void Jump(int distance, int[] marks)
            {
                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }
                _distance = distance;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].Result < array[j + 1].Result)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname} ,дистанция: {_distance}");
                for (int jump = 0; jump < 4; jump++) 
                {
                    Console.WriteLine($"Общий результат: {Result}");
                }
                
            }




        }
    }
}