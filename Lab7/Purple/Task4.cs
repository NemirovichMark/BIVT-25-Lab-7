using System;
using System.Linq;

namespace Lab7.Purple
{
    public class Task4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
            private bool _hasTime;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0.0;
                _hasTime = false;
            }

            public void Run(double time)
            {
                if (_hasTime) return;
                _time = time;
                _hasTime = true;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Time:F4}");
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
                _name = group._name;
                _sportsmen = group._sportsmen.ToArray();
            }

            public void Add(Sportsman elem)
            {
                var newArr = new Sportsman[_sportsmen.Length + 1];
                Array.Copy(_sportsmen, newArr, _sportsmen.Length);
                newArr[^1] = elem;
                _sportsmen = newArr;
            }

            public void Add(Sportsman[] array)
            {
                var newArr = new Sportsman[_sportsmen.Length + array.Length];
                Array.Copy(_sportsmen, newArr, _sportsmen.Length);
                Array.Copy(array, 0, newArr, _sportsmen.Length, array.Length);
                _sportsmen = newArr;
            }
            public void Add(Group group)
            {
                Add(group._sportsmen);
            }

            public void Sort()
            {
                Array.Sort(_sportsmen, (a, b) => a.Time.CompareTo(b.Time));
            }

            public static Group Merge(Group group1, Group group2)
            {
                var arr1 = group1._sportsmen;
                var arr2 = group2._sportsmen;

                var merged = new Sportsman[arr1.Length + arr2.Length];

                int i = 0, j = 0, k = 0;
                while (i < arr1.Length && j < arr2.Length)
                {
                    if (arr1[i].Time <= arr2[j].Time)
                        merged[k++] = arr1[i++];
                    else
                        merged[k++] = arr2[j++];
                }

                while (i < arr1.Length)
                    merged[k++] = arr1[i++];
                while (j < arr2.Length)
                    merged[k++] = arr2[j++];

                var result = new Group("Финалисты");
                result._sportsmen = merged;
                return result;
            }

            public void Print()
            {
                Console.WriteLine(Name);
                foreach (var s in _sportsmen)
                    s.Print();
            }
        }
    }
}
