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
            {
                Console.WriteLine($"Name: {Name},\nSurname: {Surname},\nTime: {Time}");
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
                Sportsman[] array = new Sportsman[group._sportsmen.Length];
                for (int i = 0; i < group._sportsmen.Length; i++)
                {
                    array[i] = group._sportsmen[i];
                }

                _sportsmen = array;
            }

            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen,_sportsmen.Length+1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null) return;
                foreach (Sportsman s in sportsmen)
                {
                    Add(s);
                }
            }

            public void Add(Group group)
            {
                Add(group._sportsmen);
            }
            public void Sort()
            {
                int i = 0;
                while (i < _sportsmen.Length)
                {
                    if (i == 0 || _sportsmen[i].Time >= _sportsmen[i - 1].Time)
                    {
                        i++;
                    }
                    else
                    {
                        Sportsman tmp = _sportsmen[i];
                        _sportsmen[i] = _sportsmen[i - 1];
                        _sportsmen[i - 1] = tmp;
                        i--;
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                Sportsman[] array = new Sportsman[group1._sportsmen.Length + group2._sportsmen.Length];
                int i1 = 0, i2 = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (i1 < group1._sportsmen.Length && i2 < group2._sportsmen.Length)
                    {
                        if (group1._sportsmen[i1].Time <= group2._sportsmen[i2].Time)
                        {
                            array[i] = group1._sportsmen[i1];
                            i1++;
                        }
                        else
                        {
                            array[i] = group2._sportsmen[i2];
                            i2++;
                        }
                    }
                    else if (i1 == group1._sportsmen.Length)
                    {
                        array[i] = group2._sportsmen[i2];
                        i2++;
                    }
                    else
                    {
                        array[i] = group1._sportsmen[i1];
                        i1++;
                    }
                }

                Group group = new Group("Финалисты");
                group._sportsmen = array;
                return group;
            }

            public void Print()
            {
                Console.WriteLine("Финалисты");
                foreach (Sportsman s in _sportsmen)
                {
                    s.Print();
                }
            }
        }
    }
}
