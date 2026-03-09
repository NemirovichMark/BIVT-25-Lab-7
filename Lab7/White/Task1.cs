using System;

namespace Lab7.White
{
    // Структура "Участник соревнований"
    public struct Participant
    {
        // Приватные поля (скрыты от прямого доступа)
        private string surname;      // фамилия
        private string club;         // название клуба
        private double firstJump;    // результат первого прыжка
        private double secondJump;   // результат второго прыжка

        // Конструктор - вызывается при создании участника
        public Participant(string surname, string club)
        {
            this.surname = surname;   // this.surname - поле структуры
            this.club = club;         // club - параметр конструктора
            firstJump = 0;             // сначала прыжков нет
            secondJump = 0;
        }

        // Свойства только для чтения (можно получить, нельзя изменить)
        public string Surname
        {
            get { return surname; }
        }

        public string Club
        {
            get { return club; }
        }

        public double FirstJump
        {
            get { return firstJump; }
        }

        public double SecondJump
        {
            get { return secondJump; }
        }

        // Свойство для суммы двух прыжков
        public double JumpSum
        {
            get { return firstJump + secondJump; }
        }

        // Метод для добавления результата прыжка
        public void Jump(double result)
        {
            if (firstJump == 0)           // если первый прыжок еще не сделан
            {
                firstJump = result;        // записываем в первый прыжок
            }
            else if (secondJump == 0)      // если первый уже есть
            {
                secondJump = result;       // записываем во второй прыжок
            }
            // если оба прыжка уже есть - ничего не делаем
        }

        // Статический метод сортировки массива участников
        public static void Sort(Participant[] array)
        {
            // Пузырьковая сортировка (простая и понятная)
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    // Сравниваем суммы прыжков
                    if (array[j].JumpSum < array[j + 1].JumpSum)
                    {
                        // Меняем местами (по убыванию)
                        Participant temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Метод для вывода информации об участнике
        public void Print()
        {
            Console.WriteLine($"Фамилия: {surname}");
            Console.WriteLine($"Клуб: {club}");
            Console.WriteLine($"1-й прыжок: {firstJump:F2} м");
            Console.WriteLine($"2-й прыжок: {secondJump:F2} м");
            Console.WriteLine($"Сумма: {JumpSum:F2} м");
            Console.WriteLine(new string('-', 30));
        }
    }
}
