namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
            private int _timeIndex;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _timeIndex = 0;
            }

            public void Run(double time)
            {
                if (_timeIndex == 0 && time >= 0)
                {
                    _time = time;
                    _timeIndex++;
                }
            }

            public void Print()
            {
                System.Console.WriteLine($"{_name} {_surname}: {_time}");
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
                Array.Copy(group.Sportsmen, _sportsmen, group.Sportsmen.Length);
            }

            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[^1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null) return;
                foreach (var sportsman in sportsmen)
                {
                    Add(sportsman);
                }
            }
            public void Add(Group group)
            {
                Add(group.Sportsmen);
            }

            public void Sort()
            {
                var sorted = _sportsmen.OrderBy(s => s.Time).ToArray();
                Array.Copy(sorted, _sportsmen, _sportsmen.Length);
            }

            public static Group Merge(Group group1, Group group2)
            {
                var finalists = new Group("Финалисты");
                finalists.Add(group1);
                finalists.Add(group2);
                finalists.Sort();
                return finalists;
            }

            public void Print()
            {
                System.Console.WriteLine(_name);
                var list = Sportsmen;
                for (int i = 0; i < list.Length; i++)
                {
                    System.Console.WriteLine($"{i+1} ");
                    list[i].Print();
                }
            }
        }
    }
}