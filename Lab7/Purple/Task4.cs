using static Lab7.Purple.Task4;

namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            private string _name; private string _surname;
            private double _time;
            public string Name => _name; public string Surname => _surname;
            public double Time => _time;
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0.0;
            }
            int c = 0;
            public void Run(double time)
            { if (c==0) _time = time; c++; }
            public void Print()
            { Console.Write($"Name: {Name}\nSurname: {Surname}\nTime: {Time}\n\n"); }
        }

        public struct Group
        {
            private string _gname; private Sportsman[] _sportsman;
            public string Name => _gname; public Sportsman[] Sportsmen => _sportsman;
            public Group(string gname)
            {
                _gname = gname;
                _sportsman = new Sportsman[0];
            }
            public Group(Group group)
            {
                string name=group.Name;
                Sportsman[] sportsman = (Sportsman[])group.Sportsmen.Clone();
            }
            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsman, _sportsman.Length + 1);
                _sportsman[^1] = sportsman;
            }
            public void Add(Sportsman[] sportsman)
            {
                int n = _sportsman.Length, k = 0;
                Array.Resize(ref _sportsman, _sportsman.Length + sportsman.Length);
                for (int i=n;i< _sportsman.Length;i++)
                    _sportsman[i] = sportsman[k++];
            }
            public void Add(Group group)
            {
                int n = _sportsman.Length, l = 0;
                Array.Resize(ref _sportsman, _sportsman.Length + group._sportsman.Length);
                for (int i = n; i < _sportsman.Length; i++)
                    _sportsman[i] = group._sportsman[l++];
            }
            public void Sort()
            {
                for (int i = 0; i < _sportsman.Length - 1; i++)
                    for (int j = 0; j < _sportsman.Length - i - 1; j++)
                        if (_sportsman[j].Time > _sportsman[j + 1].Time)
                            (_sportsman[j], _sportsman[j + 1]) = (_sportsman[j + 1], _sportsman[j]);
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
            { Console.Write($"Name: {_gname}\nSportsmen: {_sportsman}\n\n"); }
        }
        
    }
}
