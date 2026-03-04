namespace Lab7.Blue
{
    public class Task1
    {
        // Структура
        public struct Response
        {
            // Поля
            private string _name;
            private string _surname;
            private int _votes;
            // Свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;
            // Конструктор
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }
            // Мемтод
            public int CountVotes(Response[] responses)
            {
                int k = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == _name && responses[i].Surname ==_surname)
                    {
                        k++;
                    }
                }
                for (int i = 0;i< responses.Length;i++)
                {
                    if (responses[i].Name == _name && responses[i].Surname == _surname)
                    {
                        responses[i]._votes = k; //обновляем его приватное поле _votes, потому что мы внутрм структуры
                    }
                }
                _votes = k;
                return _votes;
            }
            public void Print()
            {
                Console.WriteLine(_surname + " " + _name + "--" + _votes);
            }
        }
    }
}
