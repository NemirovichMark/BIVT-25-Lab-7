namespace Lab7
{
    public class Program
    {
        public static void Main()
        {
            // ПРОСТАЯ ПРОВЕРКА ВСЕХ ЗАДАНИЙ
            Console.WriteLine("ПРОВЕРКА ЗАДАНИЙ");
            Console.WriteLine("===========================\n");

            // Задание 1
            Console.WriteLine("ЗАДАНИЕ 1 - Прыжки в длину");
            var t1_1 = new White.Task1.Participant("Иванов", "Динамо");
            var t1_2 = new White.Task1.Participant("Петров", "Спартак");
            
            t1_1.Jump(5.6);
            t1_1.Jump(5.8);
            t1_2.Jump(5.9);
            t1_2.Jump(5.7);
            
            White.Task1.Participant[] arr1 = { t1_1, t1_2 };
            
            Console.WriteLine("До сортировки:");
            t1_1.Print();
            t1_2.Print();
            
            White.Task1.Participant.Sort(arr1);
            
            Console.WriteLine("После сортировки:");
            arr1[0].Print();
            arr1[1].Print();
            
            Console.WriteLine("\n-------------------\n");

            // Задание 2
            Console.WriteLine("ЗАДАНИЕ 2 - Прыжки в высоту");
            var t2_1 = new White.Task2.Participant("Анна", "Иванова");
            var t2_2 = new White.Task2.Participant("Мария", "Петрова");
            
            t2_1.Jump(1.85);
            t2_1.Jump(1.90);
            t2_2.Jump(1.95);
            t2_2.Jump(1.88);
            
            White.Task2.Participant[] arr2 = { t2_1, t2_2 };
            
            Console.WriteLine("До сортировки:");
            t2_1.Print();
            t2_2.Print();
            
            White.Task2.Participant.Sort(arr2);
            
            Console.WriteLine("После сортировки:");
            arr2[0].Print();
            arr2[1].Print();
            
            Console.WriteLine("\n-------------------\n");

            // Задание 3
            Console.WriteLine("ЗАДАНИЕ 3 - Студенты");
            var t3_1 = new White.Task3.Student("Иван", "Иванов");
            var t3_2 = new White.Task3.Student("Петр", "Петров");
            
            t3_1.Lesson(5);
            t3_1.Lesson(4);
            t3_1.Lesson(0);
            
            t3_2.Lesson(3);
            t3_2.Lesson(0);
            t3_2.Lesson(0);
            
            White.Task3.Student[] arr3 = { t3_1, t3_2 };
            
            Console.WriteLine("До сортировки:");
            t3_1.Print();
            t3_2.Print();
            
            White.Task3.Student.SortBySkipped(arr3);
            
            Console.WriteLine("После сортировки:");
            arr3[0].Print();
            arr3[1].Print();
            
            Console.WriteLine("\n-------------------\n");

            // Задание 4
            Console.WriteLine("ЗАДАНИЕ 4 - Шахматы");
            var t4_1 = new White.Task4.Participant("Алексей", "Карпов");
            var t4_2 = new White.Task4.Participant("Гарри", "Каспаров");
            
            t4_1.PlayMatch(1);
            t4_1.PlayMatch(0.5);
            t4_2.PlayMatch(1);
            t4_2.PlayMatch(1);
            
            White.Task4.Participant[] arr4 = { t4_1, t4_2 };
            
            Console.WriteLine("До сортировки:");
            t4_1.Print();
            t4_2.Print();
            
            White.Task4.Participant.Sort(arr4);
            
            Console.WriteLine("После сортировки:");
            arr4[0].Print();
            arr4[1].Print();
            
            Console.WriteLine("\n-------------------\n");

            // Задание 5
            Console.WriteLine("ЗАДАНИЕ 5 - Футбол");
            var t5_1 = new White.Task5.Team("Динамо");
            var t5_2 = new White.Task5.Team("Спартак");
            
            t5_1.PlayMatch(2, 1);
            t5_1.PlayMatch(1, 1);
            t5_2.PlayMatch(3, 0);
            t5_2.PlayMatch(2, 2);
            
            White.Task5.Team[] arr5 = { t5_1, t5_2 };
            
            Console.WriteLine("До сортировки:");
            t5_1.Print();
            t5_2.Print();
            
            White.Task5.Team.SortTeams(arr5);
            
            Console.WriteLine("После сортировки:");
            arr5[0].Print();
            arr5[1].Print();
            
            Console.WriteLine("\n=========== ВСЕ ПРОВЕРЕНО ===========");
        }
    }

