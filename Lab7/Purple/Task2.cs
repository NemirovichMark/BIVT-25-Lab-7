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
            public int[] Marks
            {
                get
                {
                    int[] copyMarks = new int[_marks.Length];
                    Array.Copy(_marks, copyMarks, _marks.Length);
                    return copyMarks;
                }
            }

            public int Result
            {
                get
                {
                    int resSum = 0;
                    int sumPointsForDistnce = 0;
                    Array.Sort(_marks);
                    for (int i = 1; i < _marks.Length - 1; i++)
                    {
                        resSum += _marks[i];
                    }
                    const int exampleDistance = 120;
                    const int pointsForExampleDisnance = 60;

                    int curDistance = _distance - exampleDistance;
                    // _distance > 90 должна быть потому что если спортсмен получит штраф 30 баллов,то 30 * 2 = 60
                    // А 60 - 60 = 0, соотвественно, если еще меньше не 90 то он уйдет в -, в условии написано что меньше 0 не может быть
                    if (_distance > 90)
                        //если дистанция получится отрицательная, то просто знак + перебьет - и будет все ок)
                        sumPointsForDistnce = pointsForExampleDisnance + curDistance * 2;

                    resSum += sumPointsForDistnce;
                    return resSum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                for (int i = 0; i < _marks.Length; i++)
                    _marks[i] = marks[i];
                _distance = distance;
            }

            public static void Sort(Participant[] array)
            {
                Participant[] sorted = array.OrderByDescending(x => x.Result).ToArray();
                for (int i = 0; i < array.Length; i++)
                    array[i] = sorted[i];
            }

            public void Print() { }
        }
    }
}