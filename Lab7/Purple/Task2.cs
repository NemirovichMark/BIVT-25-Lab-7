namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            private string _name; private string _surname;
            private int _dist; private int[] _marks; private int _result;

            public string Name => _name; public string Surname => _surname;
            public int Distance => _dist; public int[] Marks => (int[])_marks.Clone();
            public int Result
            { get
                {
                    int sum = 0, min=int.MaxValue, max=int.MinValue;
                    for (int i = 0; i < _marks.Length; i++)
                    { 
                        if (_marks[i] < min)   min = _marks[i];
                        if (_marks[i] > max)   max = _marks[i];
                        sum += _marks[i];
                    }
                    int range = 60;
                    int _res = 0;
                    if (_dist > 120)   range += (_dist - 120) * 2;
                    else   range -= (120-_dist) * 2;
                    if (range < 0) _res=(sum - (max + min));
                    else _res=(sum - (min + max)+range);
                    _result = _res;
                    return _result;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name; _surname = surname; _dist = 0; _marks = new int[5]; _result=0;
        }
            public void Jump(int distance, int[] marks)
            {
                _dist = distance;
                if (marks == null || marks.Length != 5) return; 
                _marks = marks;
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                    for (int j = 0; j < array.Length - i - 1; j++)
                        if (array[j].Result < array[j + 1].Result)
                            (array[j], array[j + 1]) = (array[j+1], array[j]);
            }
            public void Print()
            { Console.Write($"Name: {_name} Surname: {_surname} Distance: {_dist} Marks: {_marks} Result: {_result}"); }
        }
    }
}
