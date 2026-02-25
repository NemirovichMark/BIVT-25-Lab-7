

namespace Lab7.White
{
    public class Task2
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private double firstJump;
            private double secondJump;
            private bool firstJumpSet;
            private bool secondJumpSet;

            public string Name => name;
            public string Surname => surname;
            public double FirstJump => firstJump;
            public double SecondJump => secondJump;
            public double BestJump => Math.Max(firstJump, secondJump);

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                firstJump = 0;
                secondJump = 0;
                firstJumpSet = false;
                secondJumpSet = false;
            }

            public void Jump(double result)
            {
                if (!firstJumpSet)
                {
                    firstJump = result;
                    firstJumpSet = true;
                }
                else if (!secondJumpSet)
                {
                    secondJump = result;
                    secondJumpSet = true;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Name: {name}, Surname: {surname}, FirstJump: {firstJump}, SecondJump: {secondJump}, BestJump: {BestJump}");
            }
        }
    }
}