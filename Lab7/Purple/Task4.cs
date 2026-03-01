namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }
            public void Run(double time)
            {
                _time = time;
            }
            public void Print()
            {
                Console.WriteLine($"name: {_name} surname: {_surname} time: {_time}");
            }

        }

        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;
            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                _name = group.Name;
                _sportsmen = new Sportsman[group.Sportsmen.Length];
                Array.Copy(group._sportsmen, _sportsmen, _sportsmen.Length);

            }
            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }
            public void Add(Sportsman[] sportsman)
            {
                int k = 0;
                int n = _sportsmen.Length;
                if (sportsman == null || sportsman.Length == 0) return;
                Array.Resize(ref _sportsmen, _sportsmen.Length + sportsman.Length);
                for (int i = n; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i] = sportsman[k++];
                }
            }
            public void Add(Group group)
            {
                if (group.Sportsmen == null || group.Sportsmen.Length == 0) return;
                Add(group.Sportsmen);
            }
            public void Sort()
            {
                int n = _sportsmen.Length;
                for (int i = 0; i < n-1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (_sportsmen[j].Time > _sportsmen[j + 1].Time)
                            (_sportsmen[j], _sportsmen[j + 1]) = (_sportsmen[j + 1], _sportsmen[j]);
                    }
                }
            }
            public static Group Merge(Group group1, Group group2)
            {

                Group finalyst = new Group("Финалисты");
                finalyst.Add(group1);
                finalyst.Add(group2);
                finalyst.Sort();
                return finalyst;
            }
            public void Print()
            {
                Console.WriteLine($"title: {_name}");
                foreach (Sportsman s in _sportsmen)
                    s.Print();
            }
        }
    }
}
