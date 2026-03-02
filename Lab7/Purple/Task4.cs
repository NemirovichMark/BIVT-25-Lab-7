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
                if (_time == 0)
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

            public Sportsman[] Sportsmen => _sportsmen;

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group)
            {
                _name = group.Name;
                _sportsmen = group.Sportsmen.ToArray();
            }

            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    Add(sportsmen[i]);
                }
            }

            public void Add(Group group)
            {
                Add(group.Sportsmen);
            }

            public void Sort()
            {
                Sportsman[] sportsmen = new Sportsman[_sportsmen.Length];
                sportsmen = _sportsmen.OrderBy(x => x.Time).ToArray();
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i] = sportsmen[i];
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                Group ans = new Group(group1);
                ans.Add(group2);
                ans.Sort();
                return ans;
            }
            public void Print()
            {
                foreach(var i in _sportsmen)
                {
                    i.Print();
                }
            }
        }
    }
}
