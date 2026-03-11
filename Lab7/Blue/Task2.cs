namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks => (int[,])_marks.Clone();

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    foreach (int mark in _marks)
                    {
                        sum += mark;
                    }
                    return sum;
                }
            }




            public Participant(string Name, string Surname)
            {
                _name = Name;
                _surname = Surname;
                _marks = new int[2, 5];


            }
            public void Jump(int[] result)
            {
                Print();
                int t1 = 0;
                Console.WriteLine(_marks.GetLength(1));
                for (int i = 0; i < _marks.GetLength(1); i++)
                {
                    t1 += _marks[0, i];
                }
                if (t1 == 0)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        _marks[0, i] = result[i];
                    }
                }
                else
                {
                    int t2 = 0;
                    for (int i = 0; i < _marks.GetLength(1); i++)
                    {
                        t2 += _marks[1, i];
                    }
                    if (t2 == 0)
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            _marks[1, i] = result[i];
                        }
                    }
                }

            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant buf = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = buf;
                        }
                    }

                }
            }
            public void Print()
            {
                string markss = "";
                foreach (int i in _marks)
                {

                    markss += $"{i.ToString()}, ";

                }
                Console.WriteLine($"Name: {Name} \n Surname: {Surname} \n Marks: {markss}");
            }


        }
    }
}
