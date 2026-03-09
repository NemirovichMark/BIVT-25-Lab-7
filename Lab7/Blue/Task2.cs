namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            //fields
            private string _name;
            private string _surname;
            private int[,] _marks;


            private int _currentJump;

            //parametrs
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks => (int[,])_marks.Clone();

            public int TotalScore
            {
                get
                {
                    int summ = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            summ += _marks[i,j];
                        }
                    }
                    return summ;
                }
            }

            private int CurrentJump => _currentJump;

            //methods
            public void Jump(int[] result)
            {
                if (result == null) { System.Console.WriteLine("Input Jump() array null"); return; }
                if (result.Length != 5) { System.Console.WriteLine("оценок судей не 5"); return; }
                if (_currentJump <= 1)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        _marks[_currentJump, i] = result[i];
                    }
                    _currentJump++;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) { return; }
                // var Participants = new Dictionary<int, Participant>();
                // foreach (Participant par in array)
                // {
                //     Participants.Add(par.TotalScore, par);
                // }
                // var SortedParticipants = new SortedDictionary<int, Participant>(Participants);

                // Participant[] answer = SortedParticipants.Values { get; }
                // for (int i = 0; i < array.Length; i++)
                // {
                    
                // }

                // вообще как видно выше, я очень хотел попробовать сделать сортировку по ключам словоря, но чет не сошлось
                // ключи должны быть индивидуальными, а также потом вытащить из словоря только значения в массив вообще не вышло(
                // но я уверен что меня все равно на защите спросят, а как я сделал сортировку, честно, спасибо стаковерфлоу и ИИ))

                Array.Sort(array, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }

            public void Print()
            {
                System.Console.WriteLine($"Name: {Name}, Surname: {Surname}, Total score: {TotalScore}");
            }

            //constructor
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int [2, 5];
                _currentJump = 0;
            }
        }
    }
}