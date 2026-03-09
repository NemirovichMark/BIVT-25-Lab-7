using System.Numerics;
using System.Xml.Linq;

namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            //polya
            private string _name;
            private string _surname;
            private int _place;
            private int _count;
            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;
            //конструктор
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
                _count = 0;
            }
            
            public void SetPlace(int place)
            {
                if (_count > 0)
                {
                    return;
                }
                _place = place;
                _count++;
            }
            public void Print()
            {
                Console.WriteLine($"имя:{_name},Фамилия:{_surname},место:{_place}");
            }
        }

        public struct Team
        {
            //поля
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;
            //свойства
            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    Sportsman[] array = new Sportsman[_sportsmen.Length];
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        array[i] = _sportsmen[i];
                    }

                    return array;
                }
            }
            public int TotalScore
            {
                get
                {
                    int totalteam = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        int place = _sportsmen[i].Place;
                        if (place == 1) totalteam += 5;
                        else if (place == 2)  totalteam += 4;
                        else if (place == 3)  totalteam += 3;
                        else if (place == 4)  totalteam += 2;
                        else if (place == 5)  totalteam += 1;
                    }
                    return totalteam;
                }
            }
            public int TopPlace
            {
                get
                {
                    int top = int.MaxValue;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (top > _sportsmen[i].Place)
                        {
                            top = _sportsmen[i].Place;
                        }
                    }

                    return top;
                }
            }
            //конструктор
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _count = 0;
            }
            //методы
            public void Add(Sportsman sportsman)
            {
                if (_count >= 6) return;

                _sportsmen[_count++] = sportsman;
            }
            public void Add(Sportsman[] sportsman)
            {
                foreach (Sportsman t in sportsman)
                {
                    if (_count >= 6)
                    {
                        break;
                    }
                    Add(t);
                }
            }
            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 1; j < teams.Length; j++)
                    {
                        if (teams[j].TotalScore > teams[j - 1].TotalScore || (teams[j].TotalScore == teams[j - 1].TotalScore && teams[j].TopPlace < teams[j - 1].TopPlace))
                        {
                            (teams[j - 1], teams[j]) = (teams[j], teams[j - 1]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name}, наивысший счет {TotalScore}, наивысшее место {TopPlace}");
            }
        }
    }
}
