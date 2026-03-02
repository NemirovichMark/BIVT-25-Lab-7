namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            // поля
            private string _name;
            private string _surname;
            private int _votes;

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;
            
            // конструктор
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }
            public int CountVotes(Response[] responses) //массив структуры
            {
                if (responses == null)
                {
                    _votes = 0;
                    return 0;
                }
                int count = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == _name && responses[i].Surname == _surname)
                    {
                        count++;
                    }
                }
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == _name && responses[i].Surname ==_surname)
                    {
                        ref Response element = ref responses[i];
                        element._votes = count;
                    }

                }
                _votes = count;
                return count;
            }
            public void Print()
            {
                return;
            }
        }
    }
}
