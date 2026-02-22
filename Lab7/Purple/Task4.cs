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
                _time = 0.0;
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
                Console.WriteLine($"Sportsman: {_surname} {_name}");
                Console.WriteLine($"Run Time: {_time}");
            }
        }
        
        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;
            
            public string Name => _name;

            public Sportsman[] Sportsmen => _sportsmen;
                //(_sportsmen == null || _sportsmen.Length == 0) ? null : _sportsmen;
        
            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
        
            public Group(Group group)
            {
                _name = group.Name;
                _sportsmen = new Sportsman[group._sportsmen.Length];
                Array.Copy(group._sportsmen, _sportsmen, _sportsmen.Length);
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
                int n = group1._sportsmen.Length;
                int n2 = group2._sportsmen.Length;
                Sportsman[] sorted = new Sportsman[n + n2];
                Array.Copy(group1._sportsmen, sorted, group1._sportsmen.Length);
                Array.Copy(group2._sportsmen, 0, sorted, group1._sportsmen.Length, group2._sportsmen.Length);
                
                for (int i = 0; i < n + n2; i++)
                {
                    for (int j = 0; j < (n + n2) - i - 1; j++)
                    {
                        if (sorted[j].Time > sorted[j + 1].Time)
                        {
                            (sorted[j], sorted[j + 1]) = (sorted[j + 1], sorted[j]);
                        }
                    }
                }
                
                finalists.Add(sorted);
                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"Group: {_name}");
                Console.WriteLine(String.Join(", ", _sportsmen));
            }
        }
    }
}
