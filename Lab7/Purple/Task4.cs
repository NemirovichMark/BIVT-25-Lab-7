namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            //поля

            private string _name;
            private string _surname;
            private double _time;
            private bool _installed = false;

            //свойства

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            //конструктор

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }

            //методы

            public void Run(double time)
            {
                if (_installed)
                {
                    return;
                }
                _time = time;
                _installed = true;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {Time}");
            }
        }


        public struct Group
        {
            //поля

            private string _name;
            private Sportsman[] _sportsmen;

            //свойства

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            //конструкторы

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group other)
            {
                _name = other.Name;
                if (other.Sportsmen == null)
                {
                    _sportsmen = new Sportsman[0];
                    return;
                }
                int n = other.Sportsmen.Length;
                _sportsmen = new Sportsman[n];
                for (int i = 0; i < n; i++)
                {
                    _sportsmen[i] = other.Sportsmen[i];
                }

            }

            //методы

            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[^1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null || sportsmen.Length == 0)
                {
                    return;
                }
                int n = _sportsmen.Length;
                Array.Resize(ref _sportsmen, _sportsmen.Length + sportsmen.Length);
                for(int i = 0; i < sportsmen.Length; i++)
                {
                    _sportsmen[n + i] = sportsmen[i];
                }
            }

            public void Add(Group other)
            {
                if (other._sportsmen == null || other._sportsmen.Length == 0)
                {
                    return;
                }
                int n = _sportsmen.Length;
                Array.Resize(ref _sportsmen, _sportsmen.Length + other._sportsmen.Length);
                for(int i = 0; i < other._sportsmen.Length; i++)
                {
                    _sportsmen[n + i] = other._sportsmen[i];
                }
            }

            public void Sort()
            {
                if (_sportsmen == null || _sportsmen.Length <= 1)
                {
                    return;
                }
                int i = 1;
                int j = 2;
                while (i < _sportsmen.Length)
                {
                    if (i == 0 || _sportsmen[i - 1].Time < _sportsmen[i].Time)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (_sportsmen[i], _sportsmen[i - 1]) = (_sportsmen[i - 1], _sportsmen[i]);
                        i--;
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                Group res = new Group("Финалисты");
                res.Add(group1);
                res.Add(group2);
                res.Sort();
                return res;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}");
                foreach (var s in _sportsmen)
                {
                    s.Print();
                }
                Console.WriteLine();
            }
        }

        
    }
}
