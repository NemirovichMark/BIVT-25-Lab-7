namespace Lab7.Blue
{
    public class Task2
    {
        readonly struct SuperMarks(uint jumps, uint judments)
        {
            readonly int[,] marks = new int[jumps, judments];

            public readonly int JumpsTotal => this.marks.GetLength(0);
            public readonly int JudmentsTotal => this.marks.GetLength(1);
            public readonly int[,] View => (int[,])this.marks.Clone();

            public readonly int Sum() => this.marks.Cast<int>().Sum();

            public readonly void Apply(int[] result, int i)
            {
                for (var j = 0; j < this.JudmentsTotal; j += 1) { this.marks[i, j] = result[j]; }
            }
        }

        public struct Participant(string name, string surname)
        {
            readonly string name = name, surname = surname;
            readonly SuperMarks super_marks = new(jumps: 2, judments: 5);
            int jumps_done = 0;

            public readonly string Name => this.name;
            public readonly string Surname => this.surname;
            public readonly int[,] Marks => this.super_marks.View;
            public readonly int TotalScore => this.super_marks.Sum();

            public void Jump(int[] result)
            {
                if (!IsResultDestinationValid(result) || !this.CanJump) { return; }
                this.super_marks.Apply(result, this.jumps_done);
                this.jumps_done += 1;
            }

            public static void Sort(Participant[] array)
            {
                if (array != null) { Array.Sort(array, (l, r) => r.TotalScore.CompareTo(l.TotalScore)); }
            }

            public readonly void Print() => Console.WriteLine(this.ToString());

            readonly bool IsResultDestinationValid(int[] result) => result != null && result.Length == this.super_marks.JudmentsTotal;

            readonly bool CanJump => this.jumps_done < this.super_marks.JumpsTotal;

            override public readonly string ToString() =>
                $"Participant{{name: \"{name}\", surname: \"{surname}\", TotalScore: {TotalScore}, CanJump: {CanJump}}}";
        }
    }
}