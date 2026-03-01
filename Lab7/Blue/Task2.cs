using System.Numerics;

namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private double[,] _marks;

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[,] Marks
            {
                get
                {
                    double[,] copy = new double[2, 5];
                    for (int i = 0; i < copy.GetLength(0); i++)
                    {
                        for (int j = 0; j < copy.GetLength(1); j++)
                        {
                            copy[i,j] = _marks[i,j];
                        }
                    }
                    return copy;
                }
            }
            public double TotalScore
            {
                get
                {
                    double sum = 0;
                    for (int i = 0; i < _marks.GetLength(0);i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }
            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[2, 5];
            }
            public void Jump(int[] result)
            {
                int indexRow = -1;
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    bool flag = true;
                    for (int j = 0; j < _marks.GetLength (1); j++)
                    {
                        if (_marks[i,j] != 0) //если в строке имеется оценка
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        indexRow = i;
                        break;
                    }
                }
                if (indexRow > -1)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        _marks[indexRow, j] = result[j];
                    }
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length;i++)
                {
                    for (int j = 1; j < array.Length - i; j++)
                    {
                        if (array[j-1].TotalScore < array[j].TotalScore) //по убыванию очков
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
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
