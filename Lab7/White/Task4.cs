using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7.White
{
    public class Task4
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private List<double> scores;

            public string Name => name;
            public string Surname => surname;

            public double[] Scores
            {
                get
                {
                    if (scores == null) return null;
                    return scores.ToArray();
                }
            }

            public double TotalScore
            {
                get
                {
                    if (scores == null || scores.Count == 0) return 0;

                    double sum = 0;
                    foreach (double score in scores)
                    {
                        sum += score;
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                scores = new List<double>();
            }

            public void PlayMatch(double result)
            {
                if (scores == null)
                    scores = new List<double>();

                scores.Add(result);
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
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
                Console.WriteLine($"Name: {name}, Surname: {surname}, TotalScore: {TotalScore}");
            }
        }
    }
}