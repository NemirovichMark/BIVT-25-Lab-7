namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private bool _hasJump;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    var marks = new int[5];
                    for (int i =0;i<5;i++)
                        marks[i] = _marks[i];

                    return marks;
                }
            }
            public int Result
            {
                get
                {
                    if (!_hasJump) return 0;
                    int marks = _marks.Sum() - _marks.Min() - _marks.Max();
                    int jump = 60 + (_distance - 120) * 2;
                    if (jump < 0) jump = 0;
                    return marks + jump;
                }
            }

            public Participant(string name,string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
                _hasJump = false;
            }

            public  void  Jump(int  distance,  int[] marks)
            {
                if (_distance<0) return;
                if (marks.Length!=5 || marks == null) return;
                for (int i =0;i<5;i++)
                    if (marks[i]<0 || marks[i]>20) return;

                _distance = distance;
                for (int i =0;i<marks.Length;i++)
                    _marks[i] = marks[i];

                _hasJump = true;
            }
            public static void Sort(Participant[] array)
            {
                if (array.Length<2 || array == null) return;
                int l = 1;
                while (l < array.Length)
                {
                    if (l ==0 || array[l-1].Result >= array[l].Result) l++;
                    else
                    {
                        (array[l-1],array[l]) = (array[l],array[l-1]);
                        l--;
                    }
                }
            }

            public void Print ()
            {
                System.Console.WriteLine("__________Participant___________");
                System.Console.WriteLine($"Name: {_name}; Surname: {_surname}");
                System.Console.WriteLine($"Distance: {_distance}");
                System.Console.WriteLine($"Marks: {string.Join(" ",_marks)} ");
            }
        }
    }
}
