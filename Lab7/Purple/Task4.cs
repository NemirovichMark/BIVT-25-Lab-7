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
                _time = 0;
            }

            public void Run(double time)
            {
                if (_time != 0) return;
                _time = time;
            }
            public void Print()
            {
                Console.WriteLine($"Name: {_name}, Surname: {_surname}, Time: {_time}");
            }
        }

        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            // public Sportsman[] Sportsmen
            // {
            //     get
            //     {
            //         var sportsmen = new Sportsman[_sportsmen.Length];
            //         for (int i = 0; i < sportsmen.Length; i++)
            //             sportsmen[i] = _sportsmen[i];
            //         return sportsmen;
            //     }
            // }
            public Sportsman[] Sportsmen => _sportsmen;

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                _name = group._name;
                _sportsmen = new Sportsman[group._sportsmen.Length];
                for (int i = 0; i < group._sportsmen.Length; i++)
                {
                    _sportsmen[i] = group._sportsmen[i];
                }
            }

            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[^1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null) return;
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    Add(sportsmen[i]);
                }
            }
            public void Add(Group group)
            {
                if (group._sportsmen == null) return;
                Add(group._sportsmen);
            }
            public void Sort()
            {
                for (int i = 0; i < _sportsmen.Length - 1; i++)
                {
                    for (int j = 0; j < _sportsmen.Length - 1 - i; j++)
                    {
                        if (_sportsmen[j].Time > _sportsmen[j + 1].Time)
                        {
                            (_sportsmen[j], _sportsmen[j + 1]) = (_sportsmen[j + 1], _sportsmen[j]);
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                Group finalists = new Group("Финалисты");
                
                for (int i = 0; i < group1._sportsmen.Length; i++)
                {
                    finalists.Add(group1._sportsmen[i]);
                }
                for (int i = 0; i < group2._sportsmen.Length; i++)
                {
                    finalists.Add(group2._sportsmen[i]);
                }
                finalists.Sort();
                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"{_name}  {_sportsmen}");
            }
        }
    }
}
