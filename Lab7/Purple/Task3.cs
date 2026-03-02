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
            private double _totalMark;

            private int currentMark = 0;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => (double[])_marks.Clone();
            public int[] Places => (int[])_places.Clone();
            public int TopPlace => _topPlace;
            public double TotalMark => _totalMark;

            public int Score => _places.Sum();

            public Participant(string Name, string Surname)
            {
                if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname)) throw new Exception("Null constructor");
                _name = Name;
                _surname = Surname;
                _marks = [0, 0, 0, 0, 0, 0, 0];
                _places = [0, 0, 0, 0, 0, 0, 0];
                _totalMark = 0;
                _topPlace = 0;
            }

            public void Evaluate(double result)
            {
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = result;
                        break;
                    }
                }
            }

            public static void SetPlaces(Participant[] participants)
            {
                Participant[] answer = participants;
                for (int i = 0; i < 7; i++)
                {
                    answer = (from j in answer orderby j.Marks[i] descending select j).ToArray();
                    for (int x = 0; x < participants.Length; x++)
                    {
                        answer[x]._places[i] = x + 1;
                        if (answer[x]._topPlace == 0 || answer[x]._topPlace > x + 1) 
                            answer[x]._topPlace = x + 1;
                        answer[x]._totalMark += answer[x].Marks[i];
                    }
                }
                for (int x = 0; x < participants.Length; x++) 
                    participants[x] = answer[x];
            }

            public static void Sort(Participant[] participants)
            {
                Participant[] sortedParticipants = new Participant[participants.Length];
                sortedParticipants = participants.OrderBy(x => x.Score).ThenByDescending(x => x._totalMark).ToArray();
                Participant temp;
                for (int x = 0; x < participants.Length; x++)
                {
                    participants[x] = sortedParticipants[x];
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