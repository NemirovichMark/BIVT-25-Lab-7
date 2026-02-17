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
            public double[] Marks => _marks.ToArray();
            public int[] Places => _places.ToArray();
            public int TopPlace => _topPlace;
            public double TotalMark => _totalMark;

            public double Score {
                get
                {
                    if(_places == null) return 0;
                    return (from i in _places select i).Sum(i => i);
                }
        }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                for (int i = 0; i < 7; i++) _marks[i] = -0.0001;
                _places = new int[7];
                _topPlace = 0;
                _totalMark = 0;
            }

            public void Evaluate(double res)
            {
                if (_marks == null) return;
                for(int i = 0; i < 7; i++) if (_marks[i] == -0.0001) { _marks[i] = res; return; }
            }
            public static void SetPlaces(Participant[] parts)
            {
                int n = parts.Length;
                var ans = parts;
                for (int i = 0; i < 7; i++)
                {
                    ans = (from j in ans
                          orderby j.Marks[i] descending
                          select j).ToArray();
                    for (int j = 0; j < n; j++)
                    {
                        ans[j]._places[i] = j + 1;
                        if (ans[j]._topPlace == 0 || ans[j]._topPlace > j + 1) ans[j]._topPlace = j + 1;
                        ans[j]._totalMark += ans[j].Marks[i];
                    }
                }
                for (int i = 0; i < n; i++) parts[i] = ans[i];
            }
            public static void Sort(Participant[] parts)
            {
                var ans = parts.OrderBy(n => n.Score).ThenByDescending(n => n.TotalMark).ToArray();
                for (int i = 0; i < ans.Length; i++) parts[i] = ans[i];
                foreach (var i in parts) i.Print();
            }
            public void Print()
            {
                Console.Write($"{Name, 10} {Surname, 10} - {Score, 4}");
            }
        }
    }
}