namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;
            private bool _placeSet;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            // конструктор
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
                _placeSet = false;
            }

            public void SetPlace(int place)
            {
                if (!_placeSet) // если место не установлен
                {
                    _place = place;
                    _placeSet = true; //устанавливаем и отмечаем
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {Place}");
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            // 1 = 5 баллов, 2 = 4, 3 = 3, 4 = 2, 5 = 1, остальные = 0
            public int TotalScore
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        int place = _sportsmen[i].Place; //берем место i-ного
                        if (place == 1)
                            total += 5;
                        else if (place == 2)
                            total += 4;
                        else if (place == 3)
                            total += 3;
                        else if (place == 4)
                            total += 2;
                        else if (place == 5)
                            total += 1;
                        // елсе 0 
                    }
                    return total;
                }
            }

            public int TopPlace // обычное нахождение наименьшего места спортсмена
            {
                get
                {
                    int top = _sportsmen[0].Place;
                    for (int i = 1; i < _sportsmen.Length; i++)
                    {
                        if (top > _sportsmen[i].Place)
                        {
                            top = _sportsmen[i].Place;
                        }
                    }
                    return top;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6]; // максимум 6 человек
                _count = 0;
            }

            public void Add(Sportsman sportsman) // добавить одного спортсмена в группу
            {
                if (_count >= 6) return;
                _sportsmen[_count] = sportsman;
                _count++;
            }

            public void Add(Sportsman[] sportsmen) // добавить нескольких спортсменов в группу
            {
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    if (_count >= 6) break;
                    _sportsmen[_count] = sportsmen[i];
                    _count++;
                }
            }

            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        bool flag = false; // ставим флажок

                        if (teams[j].TotalScore < teams[j + 1].TotalScore) // Сравниваем по TotalScore (чем больше, тем лучше)

                        {
                            flag = true;
                        }
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore) // Если TotalScore равны - сравниваем по TopPlace (чем меньше, тем лучше)

                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)  //пузырик, если есть меньше поднимаем флаг
                            {
                                flag = true;
                            }
                        }

                        if (flag) // если флаг, меняем
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {TotalScore}: {TopPlace}");
                for (int i = 0; i < _count; i++)
                {
                    Console.Write("  ");
                    _sportsmen[i].Print();
                }
            }
        }
    }
}
