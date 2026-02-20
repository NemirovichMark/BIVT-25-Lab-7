namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            // Приватные поля
            private string _name;
            private string _surname;
            private int _votes;


            /// Публичный конструктор с двумя параметрами

            public Response(string name, string surname)
            {
                if (name != null)
                {
                    _name = name;
                }
                else
                {
                    _name = "";
                }

                if (surname != null)
                {
                    _surname = surname;
                }
                else
                {
                    _surname = "";
                }

                _votes = 0; // Изначально 0 голосов
            }


            /// Свойства для чтения

            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;


            /// Счетчик голосов
            public int CountVotes(Response[] responses)
            {
                // Проверка на нулики
                if (responses == null)
                {
                    _votes = 0;
                    return 0;
                }

                // Считаем количество совпадений
                int count = 0;
                string currentName = Name;
                string currentSurname = Surname;

                // подсчет
                for (int i = 0; i < responses.Length; i++)
                {
                    // Сравниваем имена и фамилии
                    if (responses[i].Name == currentName &&
                        responses[i].Surname == currentSurname)
                    {
                        count++;
                    }
                }

                // обновление голосов у всех структур в массиве
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == currentName &&
                        responses[i].Surname == currentSurname)
                    {
                        ref Response item = ref responses[i]; // ссылка на элемент в массиве (нужно из-за того что это структура а не класс,
                                                              // в классе можно менять напрямую тут - нет, ибо прога дает ссылку а не саму переменную)
                        item._votes = count;                  
                    }
                }

                // Обновляем войтс
                _votes = count;


                return count;
            }

            /// Метод для вывода информации
            public void Print()
            {
                return;
            }
        }
    }
}