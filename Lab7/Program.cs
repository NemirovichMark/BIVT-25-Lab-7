using Lab7.Purple;

namespace Lab7
{
    public class Program
    {
        public static void Main()
        {
            Purple.Task1.Participant p = new Purple.Task1.Participant("Жожик", "Долбаёбик");
            p.Jump([0, 1, 2, 4, 6, 1, 2]);
            p.Print();
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    Console.Write($"{matrix[y, x]} ");
                }
                Console.WriteLine();
            }
        }
    }
}