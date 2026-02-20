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
                _time = time;
            }

            public void Print()
            {}

        }

        public struct Group
        {
            private string _groupName;
            private Sportsman[] _sportsmen;

            public string Name => _groupName;
            public Sportsman[] Sportsmen => _sportsmen;
            public Group(string groupName)
            {
                _groupName = groupName;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group)
            {
                _groupName = group.Name;
                _sportsmen = new Sportsman[group._sportsmen.Length];
                Array.Copy(group._sportsmen, _sportsmen, group.Sportsmen.Length);
            }

            public void Add(Sportsman sportik)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[^1] = sportik;
            }

            public void Add(Sportsman[] sportiks)
            {
                foreach (var sportik in sportiks)
                    Add(sportik);
            }

            public void Add(Group group)
            {
                var curGroupArray = group._sportsmen;
                Add(curGroupArray);
            }

            public void Sort()
            {
                var sortedArray = _sportsmen.OrderBy(x => x.Time).ToArray();
                for (var i = 0; i < sortedArray.Length; i++)
                    _sportsmen[i] = sortedArray[i];
            }

            public static Group Merge(Group group1, Group group2)
            {
                Group merge = new Group("Финалисты");
                merge.Add(group1);
                merge.Add(group2);
                merge.Sort();
                return merge;
            }

            public void Print() { }
        }
    }
}