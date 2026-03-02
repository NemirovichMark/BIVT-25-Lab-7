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
                    if (_marks == null) return null;
                    return _marks.ToArray();
                }
            }


            public int Result
            {
                get
                {
                    if (_marks == null) return 0;
                    int res = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        res += _marks[i];
                    }
                    res -=  (_marks.Max() + _marks.Min());
                    int locres = 60;
                    if (_distance - 120 >= 0)
                    {
                        locres += (_distance - 120) * 2;
                    }
                    else
                    {
                        if ((locres+ (_distance - 120) * 2) >= 0)
                        {
                            locres += (_distance - 120) * 2;
                        }
                        else
                        {
                            locres = 0;
                        }
                    }
                    res += locres;
                    return res;

                }
            }

            public Participant(string name, string surname)
            {
                // Проинициализировать ВСЕ нестатические поля
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }
            public void Jump(int distance, int[] marks)
            {
                _distance = distance;
                if (_marks == null || _marks.Length != marks.Length) return;
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                var s = array.OrderByDescending(participant => participant.Result).ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = s[i];
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(Result);


            }
        }
    }
}