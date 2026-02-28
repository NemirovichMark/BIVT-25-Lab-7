using Lab7.Purple;

namespace Lab7
{
    public class Program
    {
        public static void Main()
        {
            
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