namespace Lab7.Purple
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks => (int[])_marks.Clone();
            public int Result => CalculateJumpScore(_marks, _distance);

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                if (marks == null || marks.Length != 5) return;
                _distance = distance;
                _marks = new int[5];
                for (int i = 0; i < 5; i++) { _marks[i] = marks[i]; }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                var sorted = array.OrderByDescending(p => p.Result).ToArray();
                Array.Copy(sorted, array, array.Length);
            }

            public void Print()
            {
                System.Console.WriteLine($"{_name} {_surname} {string.Join(" ", _marks)} {_distance}");
            }

            private static int CalculateJumpScore(int[] marks, int distance)
            {
                int min = marks[0], max = marks[0], sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    int m = marks[i];
                    sum += m;
                    if (m < min) min = m;
                    if (m > max) max = m;
                }
                int stylePoints  = sum - max - min;
                int distancePoints = 60 + (distance - 120) * 2;
                if (distancePoints < 0) distancePoints = 0;
                return stylePoints + distancePoints;
            }
        }
    }
}