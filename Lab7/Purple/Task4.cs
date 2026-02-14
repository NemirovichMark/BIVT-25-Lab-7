namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
            private bool _hasRun;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name,string surname)
            {
                _name = name;
                _surname = surname;
                _hasRun = false;
            }
            public void Run(double time)
            {
                if (_hasRun || time <= 0)
                {
                    // System.Console.WriteLine("!error cant make time for spotsmen!");
                    return;
                }
                // System.Console.WriteLine("new time complete");
                _time = time;
                _hasRun = true;
            }
            public void Print()
            {
                System.Console.WriteLine("___________Sportsman___________");
                System.Console.WriteLine($"Name: {_name}; Surname: {_surname}");
                System.Console.WriteLine($"HasRun: {_hasRun}; Time: {_time}");
            }
        }
        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;
            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    var sportsmen = new Sportsman[_sportsmen.Length];
                    for (int i =0;i<_sportsmen.Length;i++)
                        sportsmen[i] = _sportsmen[i];
                    return _sportsmen;
                }
            }
            public Group (string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                if (group._sportsmen == null) return;
                _name = group._name;
                _sportsmen = new Sportsman[0];
                Add (group._sportsmen);
            }
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null)
                {
                    Array.Resize(ref _sportsmen,1);
                    _sportsmen[0] = sportsman;
                }
                else
                {
                    Array.Resize(ref _sportsmen,_sportsmen.Length+1);
                    _sportsmen[^1] = sportsman;
                }
            }
            public void Add(Sportsman[] sportsmans)
            {
                if (sportsmans == null) return;
                foreach (var sportsman in sportsmans)
                    Add(sportsman);
            }
            public void Add(Group group)
            {
                var sportsmans = group._sportsmen;
                Add(sportsmans);
            }
            public  void  Sort()
            {
                int l = 1;
                while (l < _sportsmen.Length)
                {
                    if (l == 0 || _sportsmen[l-1].Time <= _sportsmen[l].Time) l++;
                    else
                    {
                        (_sportsmen[l-1],_sportsmen[l]) = (_sportsmen[l],_sportsmen[l-1]);
                        l--;
                    }
                }
                // _sportsmen = _sportsmen.OrderBy(s => s.Time).ToArray(); почему то не работает :(
            }
            public static Group Merge(Group group1, Group group2)
            {

                var group = new Group("Финалисты");

                int len1 = group1._sportsmen.Length,len2 = group2._sportsmen.Length;
                Array.Resize(ref group._sportsmen, len1 + len2);
                for (int i = 0; i < len1; i++)
                    group._sportsmen[i] = group1._sportsmen[i];
                
                for (int i =0;i<len2;i++)
                    group._sportsmen[len1+i] = group2._sportsmen[i];
        
                group._sportsmen = group._sportsmen.OrderBy(s => s.Time).ToArray();
                return group;
            }
            public void Print()
            {
                System.Console.WriteLine("___________Group____________");
                System.Console.WriteLine($"Name: {_name}");
                System.Console.WriteLine("Sportsmans: ");
                foreach (var sportsman in _sportsmen)
                    System.Console.Write($"{sportsman.Name,10}");
            }
        }
    }
}
