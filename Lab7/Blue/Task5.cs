namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;
            private bool _isSetted;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
                _isSetted = false;
            }

            public void SetPlace(int place)
            {
                if (_isSetted == false && place > 0 && place <= 18)
                {
                    _place = place;
                    _isSetted = true;
                }
            }

            public void Print()
            {
                return;
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;

            public Sportsman[] Sportsmen => (Sportsman[])_sportsmen.Clone();

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i].Place != 0)
                            sum += GetPoints(_sportsmen[i]);
                    }
                    return sum;
                }
            }

            public int TopPlace
            {
                get
                {
                    int topPlace = int.MaxValue;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i].Place != 0 && _sportsmen[i].Place < topPlace)
                            topPlace = _sportsmen[i].Place;
                    }
                    return topPlace;
                }
            }

            private int GetPoints(Sportsman sportsman)
            {
                if (sportsman.Place == 1) return 5;
                if (sportsman.Place == 2) return 4;
                if (sportsman.Place == 3) return 3;
                if (sportsman.Place == 4) return 2;
                if (sportsman.Place == 5) return 1;
                return 0;
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen.Length < 6)
                {
                    Sportsman[] newArr = new Sportsman[_sportsmen.Length + 1];
                    for (int i = 0; i < _sportsmen.Length; i++)
                        newArr[i] = _sportsmen[i];
                    newArr[newArr.Length - 1] = sportsman;
                    _sportsmen = newArr;
                }
            }

            public void Add(Sportsman[] sportsmen)
            {
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    if (_sportsmen.Length < 6)
                    {
                        Sportsman[] newArr = new Sportsman[_sportsmen.Length + 1];
                        for (int j = 0; j < _sportsmen.Length; j++)
                            newArr[j] = _sportsmen[j];
                        newArr[newArr.Length - 1] = sportsmen[i];
                        _sportsmen = newArr;
                    }
                    else
                        return;
                }
            }

            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        bool needSwap = false;

                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                            needSwap = true;
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (teams[j].HasFirstPlace() == false && teams[j + 1].HasFirstPlace() == true)
                                needSwap = true;
                        }

                        if (needSwap)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }

            private bool HasFirstPlace()
            {
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    if (_sportsmen[i].Place == 1)
                        return true;
                }
                return false;
            }

            public void Print()
            {
                return;
            }
        }
    }
}