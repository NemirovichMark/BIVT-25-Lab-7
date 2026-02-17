using static Lab7.Purple.Task4;

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
            int count = 0;
            public void Run(double time)
            {
                if (count == 0)
                {
                    _time = time;
                    count++;
                }
            }
            
            public void Print()
            {
                Console.WriteLine($"{_name}  {_surname} {_time}");
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
                string name = group.Name;
                Sportsman[] sportsmen = new Sportsman[group.Sportsmen.Length];
                Array.Copy(group.Sportsmen, sportsmen, group.Sportsmen.Length);
            }
            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length+1);
                _sportsmen[^1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                int len = _sportsmen.Length;
                int count = 0;
                Array.Resize(ref _sportsmen, _sportsmen.Length + sportsmen.Length);
                for (int i = len; i< _sportsmen.Length; i++)
                {
                    _sportsmen[i] = sportsmen[count++];
                }
            }
            public void Add(Group group)
            {
                int len = _sportsmen.Length;
                int count = 0;
                Array.Resize(ref _sportsmen, _sportsmen.Length + group._sportsmen.Length);
                for (int i = len; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i] = group._sportsmen[count++];
                }
            }

            public void Sort()
            {
                for (int i = 0; i<_sportsmen.Length; i++)
                {
                    for (int j = i; j< _sportsmen.Length; j++)
                    {
                        if (_sportsmen[i].Time > _sportsmen[j].Time)
                        {
                            (_sportsmen[i], _sportsmen[j]) = (_sportsmen[j], _sportsmen[i]);
                        }
                    }
                }
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
                Console.WriteLine($"{_name}  {_sportsmen}");
            }
        }
    }
}
