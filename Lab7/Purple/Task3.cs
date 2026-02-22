using System.Linq;

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
            private int _topplace;
            private double _totalmark;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks =>
                (_marks == null || _marks.Length == 0) ? null : (double[]) _marks.Clone();
            public int[] Places => 
                (_places == null || _places.Length == 0) ? null : (int[]) _places.Clone();
            public int TopPlace => _topplace;
            public double TotalMark => _totalmark;
            public int Score => (_places == null) ? 0 : _places.Sum();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _topplace = 0;
                _totalmark = 0;
            }

            public void Evaluate(double result)
            {
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = result;
                        _totalmark += result;
                        break;
                    }
                }

            }
            
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                for (int judge = 0; judge < 7; judge++)
                {
                    Array.Sort(participants, (a, b) => b._marks[judge].CompareTo(a._marks[judge]));

                    for (int i = 0; i < participants.Length; i++)
                    {
                        participants[i]._places[judge] = i + 1;
                        if (judge == 0 || (i + 1) < participants[i]._topplace)
                        {
                            participants[i]._topplace = i + 1; 
                        }
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        bool shouldSwap = false;
                        
                        if (array[j].Score > array[j+1].Score) shouldSwap = true;
                        else if (array[j].Score == array[j+1].Score)
                        {
                            if (array[j].TopPlace > array[j+1].TopPlace) shouldSwap = true;
                            else if (array[j].TopPlace == array[j+1].TopPlace)
                            {
                                double sum1 = 0.0, sum2 = 0.0;
                                for (int k = 0; k < array[j].Marks.Length; k++)
                                {
                                    sum1 += array[j].Marks[k];
                                    sum2 += array[j+1].Marks[k];
                                }
                                if (sum1 < sum2)
                                    shouldSwap = true;
                            }
                        }
                        if (shouldSwap) (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }


            public void Print()
            {
                Console.WriteLine($"Participant: {_surname} {_name}");
                Console.WriteLine($"Total Score: {Score}");
                Console.WriteLine($"Places: {string.Join(", ", _places)}");
            }
        }
    }
}
