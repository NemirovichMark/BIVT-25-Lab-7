using System.Reflection;

namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int[] _penaltytimes;

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    int[] copy = new int[_penaltytimes.Length];
                    for (int i = 0; i < copy.Length; i++)
                    {
                        copy[i] = _penaltytimes[i];
                    }
                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _penaltytimes.Length;i++)
                    {
                        sum += _penaltytimes[i];
                    }
                    return sum;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    for (int i =0; i < _penaltytimes.Length;i++)
                    {
                        if (_penaltytimes[i] == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltytimes = new int[0];
            }

            public void PlayMatch(int time) //добавляет штрафное время в массив
            {
                if (time != 0 && time != 2 && time != 5 && time != 10)
                {
                    return;
                }
                int[] newTimes = new int[_penaltytimes.Length+1];
                for (int i =0; i < _penaltytimes.Length; i++)
                {
                    newTimes[i] = _penaltytimes[i];
                }
                newTimes[newTimes.Length - 1] = time;
                _penaltytimes = newTimes;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1)
                    return;
                for (int i = 0;  i < array.Length; i++)
                {
                    for (int j = 1; j < array.Length-i; j++)
                    {
                        if (array[j-1].TotalTime > array[j].TotalTime) // по возрастанию общего времени
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
