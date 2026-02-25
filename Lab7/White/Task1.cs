namespace Lab7.White
{
    public class Task1
    {
        public struct Participant
        {
            private string surname;
            private string club;
            private double firstJump;
            private double secondJump;
            private bool firstJumpSet;
            private bool secondJumpSet;

            public string Surname => surname;
            public string Club => club;
            public double FirstJump => firstJump;
            public double SecondJump => secondJump;
            public double JumpSum => firstJump + secondJump;

            public Participant(string surname, string club)
            {
                this.surname = surname;
                this.club = club;
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
                        if (array[j].JumpSum < array[j + 1].JumpSum)
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
                Console.WriteLine($"Surname: {surname}, Club: {club}, FirstJump: {firstJump}, SecondJump: {secondJump}, JumpSum: {JumpSum}");
            }
        }
    }
}