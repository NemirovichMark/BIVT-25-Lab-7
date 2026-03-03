namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
            private bool _hasRun;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
                _hasRun = false;
            }

            public void Run(double time)
            {
                if (!_hasRun)
                    _time = time;
                _hasRun = true;
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}:   {_time}");
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
                _name =group.Name;
                _sportsmen = group.Sportsmen;
            }

            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length+1);
                _sportsmen[^1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                foreach (Sportsman sportsman in sportsmen)
                {
                    this.Add(sportsman);
                }
            }
            public void Add(Group group)
            {
                this.Add(group._sportsmen);
            }
            public void Sort()
            {
                for (int i =0; i <  _sportsmen.Length; i++)
                {
                    for (int j = i; j>0 && _sportsmen[j].Time < _sportsmen[j-1].Time; j--)
                    {
                        (_sportsmen[j], _sportsmen[j-1]) = (_sportsmen[j-1], _sportsmen[j]);
                    }
                }
            }
            public static Group Merge(Group group1, Group group2)
            {
                Group finalists = new Group("Финалисты");
                for (int i = 0, j = 0; i < group1.Sportsmen.Length || j < group2.Sportsmen.Length;)
                {
                    if (i == group1.Sportsmen.Length && j == group2.Sportsmen.Length)
                    {
                        break;
                    }
                    else if (i == group1.Sportsmen.Length || group2.Sportsmen[j].Time < group1.Sportsmen[i].Time)
                    {
                        finalists.Add(group2.Sportsmen[j++]);
                    }
                    else
                    {
                        finalists.Add(group1.Sportsmen[i++]);
                    }
                }
                return finalists;
            }
            public void Print()
            {

            }
        }
    }
}
