namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
            private bool _flag;
            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
                _flag = false;

            }
            public void Run(double time)
            {
                if (!_flag)
                {
                    _time = time;
                    _flag = true;
                }

            }

            public void Print()
            {
                Console.WriteLine(Name);
                Console.WriteLine(Surname);
                Console.WriteLine(Time);
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
            //         if (_sportsmen == null) return new Sportsman[0];
            //         Sportsman[] copy = new Sportsman[_sportsmen.Length];
            //         Array.Copy(_sportsmen, copy, _sportsmen.Length);
            //         return copy;
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
                _name = group.Name;
                var otherSportsmen = group.Sportsmen; 
                if (otherSportsmen != null)
                {
                    _sportsmen = new Sportsman[otherSportsmen.Length];
                    Array.Copy(otherSportsmen, _sportsmen, otherSportsmen.Length);
                }
                else
                {
                    _sportsmen = new Sportsman[0];
                }
            }
            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null || sportsmen.Length == 0) return;
                int oldSize = _sportsmen.Length;
                Array.Resize(ref  _sportsmen, oldSize + sportsmen.Length);
                Array.Copy(sportsmen, 0, _sportsmen, oldSize, sportsmen.Length);
            }

            public void Add(Group group)
            {
                if (group.Sportsmen == null || group.Sportsmen.Length == 0) return;
                Add(group.Sportsmen);
            }

            public void Sort()
            {
                for (int i = 0; i < _sportsmen.Length - 1; i++)
                {
                    for (int j = 0; j < _sportsmen.Length - i - 1; j++)
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
                finalists.Add(group1);
                finalists.Add(group2);
                finalists.Sort();
                return finalists;
                
            }

            public void Print()
            {
                Console.WriteLine(Name);
                if (_sportsmen != null)
                {
                    foreach (var s in _sportsmen)
                    {
                        s.Print();
                    }
                }
            }
        }
    }
}
