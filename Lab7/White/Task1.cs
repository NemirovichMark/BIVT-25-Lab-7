namespace Lab7.White
{
    public class Task1
    {
        public struct Participant      
        {
            private string surname;
            private string club;
            private double firstresult;
            private double secondresult;

            public Participant(string surname, string club) 
            {
                this.surname = surname;
                this.club = club;
            }

            public void Jump(double result)
            {
                if (firstresult == 0)
                {
                    firstresult = result;
                }
                else if (secondresult == 0)
                {
                    secondresult = result;
                }
                
            }

            public double JumpSum => firstresult + secondresult;

            public string Surname => surname;
            public string Club => club;
            public double FirstJump => firstresult;
            public double SecondJump => secondresult;

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.JumpSum.CompareTo(a.JumpSum));
            }
            public void Print() { }
        }
    }
}
