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
                if (_time != 0.0)
                    return;
                _time = time;
            }

            public void Print()
            {
                Console.WriteLine(_name, _surname, _time);
            }
        }


        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmens;
            
            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmens;
            
            public Group(string name)
            {
                _name = name;
                _sportsmens = [];
            }
            
            public Group(Group other)
            {
                _name = other._name;
                Array.Copy(other._sportsmens, _sportsmens, other._sportsmens.Length);
            }

            public void Add(Sportsman sportsman) //для одного
            {
                Array.Resize(ref _sportsmens, _sportsmens.Length + 1);
                _sportsmens[_sportsmens.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                foreach (var sportsman in sportsmen)
                {
                    Add(sportsman); //добавление одного участника
                }
            }

            public void Add(Group group)
            {
                foreach (var sportsmen in group.Sportsmen)
                {
                    Add(sportsmen);
                }
            }

            public void Sort()
            {
                Array.Sort(_sportsmens, (x, y) => x.Time.CompareTo(y.Time));
            }
            
            public static Group Merge(Group group1, Group group2)
            {
                Group group = new Group("Финалисты");
                group.Add(group1);
                group.Add(group2);
                group.Sort();
                return group;
            }
            
            public void Print()
            {
                Console.WriteLine($"{Name}, {string.Join(", ", _sportsmens)})");
            }
        }
    }
}