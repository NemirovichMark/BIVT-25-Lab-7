using System.Xml.Linq;

namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {

            //объявление полей
            private string _name;
            private string _surname;
            private int[,] _marks;

            //свойства
            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }
            public int[,] Marks
            {
                get
                {
                    int[,] copy = new int[2, 5];

                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 5; j++)
                            copy[i, j] = _marks[i, j];

                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            //конструктор
            public Participant(string name, string surname)
            {
                _marks = new int[2, 5];
                _name = name;
                _surname = surname;
            }


            //метод записи прыжков
            public void Jump(int[] result)
            {
                int indexRow = -1;
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    bool flag = true;
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        if (_marks[i, j] != 0)
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



            //метод сортировки результатов
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length - i; j++)
                    {
                        if (array[j - 1].TotalScore < array[j].TotalScore) //по убыванию очков
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine("");
            }
        }
    }
}
