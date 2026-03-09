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
            private List<double> scores;  // список для хранения результатов

            // Свойства только для чтения
            public string Name => name;
            public string Surname => surname;

            // СВОЙСТВО SCORES - ИСПРАВЛЕНО!
            public double[] Scores
            {
                get
                {
                    return scores.ToArray();  // преобразуем список в массив
                    // scores всегда существует, так как инициализируется в конструкторе
                }
            }

            // Свойство для суммы очков
            public double TotalScore
            {
                get
                {
                    if (scores.Count == 0) return 0;
                    
                    double sum = 0;
                    foreach (double score in scores)
                    {
                        sum += score;
                    }
                    return sum;
                }
            }

            // КОНСТРУКТОР 
            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                scores = new List<double>(); 
            }

            // Метод для добавления результата
            public void PlayMatch(double result)
            {
                scores.Add(result);  // добавляем в список
            }

            // Метод сортировки по убыванию суммы
            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }

            // Метод вывода
            public void Print()
            {
                Console.WriteLine($"{name} {surname} | Всего очков: {TotalScore}");
            }
        }
    }
}
