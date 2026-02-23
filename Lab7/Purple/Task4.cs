using System.Globalization;

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

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0.0;
                _hasRun = false;
            }

            public void Run(double time)
            {
                if (_hasRun) return;
                _time = time;
                _hasRun = true;
            }

            public void Print()
            {
                Console.WriteLine();
            }
        }

        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen; 

            public Group(string name) {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group)
            {
                _name = group._name;

                if (group._sportsmen == null)
                {
                    _sportsmen = null;
                } else
                {
                    _sportsmen = new Sportsman[group._sportsmen.Length];

                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        _sportsmen[i] = group._sportsmen[i];
                    }
                }
            }

            public void Add (Sportsman sportsman)
            {
                if (_sportsmen == null)
                {
                    _sportsmen = new Sportsman[] { sportsman };
                } else
                {
                    Sportsman[] array = new Sportsman[_sportsmen.Length + 1];

                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        array[i] = _sportsmen[i];
                    }

                    array[array.Length - 1] = sportsman;
                    _sportsmen = array;
                }
            }

            public void Add (Sportsman[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length; i++)
                {
                    Add(array[i]);
                }
            }
            
            public void Add (Group group)
            {
                if (group.Sportsmen == null) return;
                Add(group.Sportsmen);
            }

            public void Sort()
            {
                for (int i = 0; i < _sportsmen.Length - 1; i++)
                {
                    for (int j = 0; j < _sportsmen.Length - 1 - i; j++)
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
                Sportsman[] merged = new Sportsman[group1._sportsmen.Length + group2._sportsmen.Length];
                int i = 0, j = 0, k = 0;

                while (i < group1._sportsmen.Length && j < group2._sportsmen.Length)
                {
                    if (group1._sportsmen[i].Time >= group2._sportsmen[j].Time)
                    {
                        merged[k++] = group2._sportsmen[j++];
                    } else
                    {
                        merged[k++] = group1._sportsmen[i++];
                    }
                }

                while (i < group1._sportsmen.Length) merged[k++] = group1._sportsmen[i++];
                while (j < group2._sportsmen.Length) merged[k++] = group2._sportsmen[j++];

                Group res = new Group("Финалисты");
                res._sportsmen = merged;
                return res;
            }

            public void Print()
            {
                Console.WriteLine(Name);

                if (_sportsmen == null) return;
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i].Print();
                }
            }
        }
    }
}
