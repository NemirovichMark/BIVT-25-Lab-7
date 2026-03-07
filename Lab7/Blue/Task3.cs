using System.ComponentModel;
using static Lab7.Blue.Task2;
using static Lab7.Blue.Task3;

namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {

            //поля 
            private string _name;
            private string _surname;
            private int[] _penalty;
            public string Name 
            { 
                get
                {
                    return _name;
                }
            }


            //свойства
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }
            public int[] PenaltyTimes
            {
                get
                {
                    int[] copy = new int[_penalty.Length];
                    for (int i = 0; i < copy.Length; i++)
                    {
                        copy[i] = _penalty[i];
                    }
                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _penalty.Length; i++)
                    {
                        sum += _penalty[i];
                    }
                    return sum;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    for (int i = 0; i< _penalty.Length; i++)
                    {
                        if (_penalty[i] == 10) return true;
                    }
                    return false;
                }
            }

            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penalty = new int[0];
            }



            //метод для добавления нового штрафного времени
            public void PlayMatch(int time)
            {
                if (time != 0 && time != 2 && time != 5 && time != 10) return;
                int[] new_penalty = new int[_penalty.Length + 1];
                for (int i = 0; i < _penalty.Length; i++)
                {
                    new_penalty[i] = _penalty[i];
                }
                new_penalty[new_penalty.Length - 1] = time;
                _penalty = new_penalty;
            }


            //метод для сортировки
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1)
                    return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length - i; j++)
                    {
                        if (array[j - 1].TotalTime > array[j].TotalTime)
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
