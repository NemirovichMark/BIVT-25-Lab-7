using System.Runtime.Serialization;

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
                if (_time == 0) _time = time;
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - {Time} сек.");
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
            public Group(Group other)
            {
                _name = other.Name;
                _sportsmen = other.Sportsmen.ToArray();
            }

            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[^1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                for(int i = 0; i < sportsmen.Length; i++)
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
                _sportsmen = (from i in _sportsmen
                              orderby i.Time
                              select i).ToArray();
            }
            public static Group Merge(Group g1, Group g2)
            {
                var ans = new Group(g1);
                ans.Add(g2);
                ans.Sort();
                return ans;
            }
            public void Print()
            {
                Console.WriteLine($"{Name}");
                foreach(var i in _sportsmen)
                {
                    i.Print();
                }
            }
        }
    }
}