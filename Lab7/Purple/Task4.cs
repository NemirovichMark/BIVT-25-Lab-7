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
                _time = 0;
            }

            public void Run(double time)
            {
                if (_time == 0)
                {
                    _time = time;
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);

                Console.WriteLine(_surname);

                Console.WriteLine(_time);
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
                _sportsmen = new Sportsman[group._sportsmen.Length];
                for (int i = 0;  i < _sportsmen.Length;i++)
                {
                    _sportsmen[i] = group._sportsmen[i];
                }
            }
            public void Add(Sportsman chel)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = chel;
            }
            public void Add(Sportsman[] cheliki)
            {
                foreach (Sportsman chel in cheliki)
                {
                    Add(chel);
                }
            }
            public void Add(Group group)
            {
                if (group.Sportsmen == null || group.Sportsmen.Length == 0) return;
                Add(group.Sportsmen);
            }
            public void Sort()
            {
                if (_sportsmen == null || _sportsmen.Length == 0) return;
                var sor = _sportsmen.OrderBy(s => s.Time).ToArray();
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i] = sor[i];
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                Group final  = new Group("Финалисты");
                final.Add(group1);
                final.Add(group2);
                final.Sort();
                return final;
            }
            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_sportsmen);
            }
        }

    }
}