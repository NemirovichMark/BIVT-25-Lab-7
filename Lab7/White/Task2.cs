namespace Lab7.White
{
    public class Task2
    {
        public struct Participant     
        {
            private string name;
            private string surname;
            private double firstresult;
            private double secondresult;

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.firstresult = 0;       
                this.secondresult = 0;
            }

            public string Name => name;
            public string Surname => surname;
            public double FirstJump => firstresult;
            public double SecondJump => secondresult;

            public double BestJump => Math.Max(firstresult, secondresult); 

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

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.BestJump.CompareTo(a.BestJump));
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {BestJump}");
            }
        }
    }
}
