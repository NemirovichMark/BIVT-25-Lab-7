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
            public Sportsman(string Name, string Surname)
            {
                _name = Name;
                _surname = Surname;
                _time = 0.0;
            }
            public void Run(double time)
            {
                if (_time == 0.0)
                {
                    _time = time;
                }
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {Name}");
                Console.WriteLine($"Фамилия: {Surname}");
                Console.WriteLine($"Время: {Time}");
            }
        }
        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;
            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;
            public Group(string Name)
            {
                _name = Name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                _name = group.Name;
                _sportsmen = new Sportsman[group.Sportsmen.Length];

                for (int i = 0; i < group.Sportsmen.Length; i++)
                {
                    _sportsmen[i] = group.Sportsmen[i];
                }
            }
            public void Add(Sportsman sportsman)
            {
                Sportsman[] temp = new Sportsman[_sportsmen.Length + 1];
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    temp[i] = _sportsmen[i];
                }
                temp[_sportsmen.Length] = sportsman;
                _sportsmen = temp;
            }
            public void Add(Sportsman[] sportsmen)
            {
                Sportsman[] temp = new Sportsman[_sportsmen.Length + sportsmen.Length];
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    temp[i] = _sportsmen[i];
                }
                for (int j = 0; j < sportsmen.Length; j++)
                {
                    temp[_sportsmen.Length + j] = sportsmen[j];
                }
                _sportsmen = temp;
            }
            public void Add(Group group)
            {
                Add(group.Sportsmen);
            }
            public void Sort()
            {
                for (int i = 0; i < _sportsmen.Length - 1; i++)
                {
                    for (int j = i + 1; j < _sportsmen.Length; j++)
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
                Group finalGroup = new Group("Финалисты");
                finalGroup._sportsmen = new Sportsman[group1.Sportsmen.Length + group2.Sportsmen.Length];
                int i = 0;
                int j = 0;
                int k = 0;
                while (i < group1.Sportsmen.Length && j < group2.Sportsmen.Length)
                {
                    if (group1.Sportsmen[i].Time <= group2.Sportsmen[j].Time)
                    {
                        finalGroup._sportsmen[k] = group1.Sportsmen[i];
                        i++;
                    }
                    else
                    {
                        finalGroup._sportsmen[k] = group2.Sportsmen[j];
                        j++;
                    }
                    k++;
                }
                while (i < group1.Sportsmen.Length)
                {
                    finalGroup._sportsmen[k] = group1.Sportsmen[i];
                    i++;
                    k++;
                }
                while (j < group2.Sportsmen.Length)
                {
                    finalGroup._sportsmen[k] = group2.Sportsmen[j];
                    j++;
                    k++;
                }
                return finalGroup;
            }
            public void Print()
            {
                Console.WriteLine($"Группа: {Name}");
                Console.WriteLine("Участники:");
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i].Print();
                    Console.WriteLine();
                }
            }   
        }
    }
}