using System.Xml.Linq;

namespace Lab7.Purple
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _topPlace;
            private int _totalMark;

            private int currentMark = 0;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => (double[])_marks.Clone();
            public int[] Places => (int[])_places.Clone();
            public int TopPlace => _topPlace;
            public int TotalMark => _totalMark;

            public int Score
            {
                get
                {
                    return 0;
                }
            }

            public Participant(string Name, string Surname)
            {
                if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname)) throw new Exception("Null constructor");
                _name = Name;
                _surname = Surname;
                _marks = [0, 0, 0, 0, 0, 0, 0];
                _places = [0, 0, 0, 0, 0, 0, 0];
            }

            public void Evaluate(double result)
            {
                if ((result > 0 || result < 6) && currentMark < 6)
                    _marks[currentMark++] = result;
            }
            public static void Sort(Participant[] array)
            {

            }

            public static void SetPlaces(Participant[] participants)
            {
                Participant tempPartic;
                double tempMark;
                for(int x = 0; x < 7; x++)
                {
                    for(int i = 0; i < participants.Length; i++)
                        for(int j = 0; j < participants.Length - i - 1; j++)
                            if (participants[j + 1]._marks[x] < participants[j]._marks[x])
                            {
                                tempPartic = participants[j];
                                participants[j] = participants[j + 1];
                                participants[j + 1] = tempPartic;
                            }
                    for(int y = 0; y < participants.Length; y++)
                        participants[y]._places[x] = y + 1;
                }
                for(int x = 0; x < participants.Length; x++)
                {
                    participants[x]._topPlace = participants[x]._places.Min();
                    participants[x]._totalMark = participants[x]._places.Sum();
                }

                for (int i = 0; i < participants.Length; i++)
                    for (int j = 0; j < participants.Length - i - 1; j++)
                        if (participants[j + 1]._places[6] > participants[j]._places[6])
                        {
                            tempPartic = participants[j];
                            participants[j] = participants[j + 1];
                            participants[j + 1] = tempPartic;
                        }
            }
            public void Print()
            {
                Console.WriteLine($"Имя:{_name}\n" +
                    $"Фамилия:{_surname}\n" +
                    $"Дистанция прыжка:{0}");
                Console.WriteLine($"Оценки Судей:{string.Join(' ', _marks)}");
            }
        }
    }
}