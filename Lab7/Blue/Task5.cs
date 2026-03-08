namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            private string _firstName;
            private string _lastName;
            private int _place;
            private bool _isPlaceSet;

            public string Name => _firstName;
            public string Surname => _lastName;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _firstName = name;
                _lastName = surname;
                _place = 0;
                _isPlaceSet = false;
            }

            public void SetPlace(int place)
            {
                if (place < 0) return;
                if (_isPlaceSet) return;
                _place = place;
                _isPlaceSet = true;
            }

            public void Print()
            {
                return;
            }
        }

        public struct Team
        {
            private string _teamName;
            private Sportsman[] _teamMembers;
            private int _memberCount;

            public string Name => _teamName;

            public Sportsman[] Sportsmen
            {
                get
                {
                    Sportsman[] copy = new Sportsman[_memberCount];
                    for (int i = 0; i < _memberCount; i++)
                        copy[i] = _teamMembers[i];
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < _memberCount; i++)
                    {
                        if (_teamMembers[i].Place == 1) total += 5;
                        else if (_teamMembers[i].Place == 2) total += 4;
                        else if (_teamMembers[i].Place == 3) total += 3;
                        else if (_teamMembers[i].Place == 4) total += 2;
                        else if (_teamMembers[i].Place == 5) total += 1;
                    }
                    return total;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_memberCount == 0) return 0;
                    
                    int best = _teamMembers[0].Place;
                    for (int i = 1; i < _memberCount; i++)
                    {
                        if (_teamMembers[i].Place < best)
                            best = _teamMembers[i].Place;
                    }
                    return best;
                }
            }

            public Team(string name)
            {
                _teamName = name;
                _teamMembers = new Sportsman[6];
                _memberCount = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_memberCount >= 6) return;
                _teamMembers[_memberCount] = sportsman;
                _memberCount++;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (_memberCount >= 6) return;
                
                for (int i = 0; i < sportsmen.Length; i++)
                    Add(sportsmen[i]);
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length <= 1) return;
                
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 1; j < teams.Length - i; j++)
                    {
                        if (teams[j - 1].TotalScore < teams[j].TotalScore)
                        {
                            Team temp = teams[j - 1];
                            teams[j - 1] = teams[j];
                            teams[j] = temp;
                        }
                        else if (teams[j - 1].TotalScore == teams[j].TotalScore)
                        {
                            if (teams[j - 1].TopPlace > teams[j].TopPlace)
                            {
                                Team temp = teams[j - 1];
                                teams[j - 1] = teams[j];
                                teams[j] = temp;
                            }
                        }
                    }
                }
            }

            public void Print()
            {
                return;
            }
        }
    }
}
