using System;

namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (_place == 0)
                {
                    _place = place;
                }
            }

            public void Print()
            {
                Console.WriteLine($"Спортсмен: {Name} {Surname} | Место: {Place}");
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return new Sportsman[6];
                    return _sportsmen;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _count; i++)
                    {
                        if (_sportsmen[i].Place == 1) sum += 5;
                        else if (_sportsmen[i].Place == 2) sum += 4;
                        else if (_sportsmen[i].Place == 3) sum += 3;
                        else if (_sportsmen[i].Place == 4) sum += 2;
                        else if (_sportsmen[i].Place == 5) sum += 1;
                    }
                    return sum;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _count == 0) return 0;
                    int top = 18;
                    bool found = false;

                    for (int i = 0; i < _count; i++)
                    {
                        if (_sportsmen[i].Place > 0 && _sportsmen[i].Place < top)
                        {
                            top = _sportsmen[i].Place;
                            found = true;
                        }
                    }
                    return found ? top : 0;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _count = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) _sportsmen = new Sportsman[6];
                if (_count >= 6) return;

                _sportsmen[_count] = sportsman;
                _count++;
            }

            public void Add(Sportsman[] sportsmenArray)
            {
                if (_sportsmen == null) _sportsmen = new Sportsman[6];
                if (sportsmenArray == null) return;

                if (_count + sportsmenArray.Length > 6) return;

                for (int i = 0; i < sportsmenArray.Length; i++)
                {
                    _sportsmen[_count] = sportsmenArray[i];
                    _count++;
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore ||
                           (teams[j].TotalScore == teams[j + 1].TotalScore && teams[j].TopPlace > teams[j + 1].TopPlace))
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name} | Очки: {TotalScore} | Высшее место: {TopPlace}");
            }
        }
    }
}
