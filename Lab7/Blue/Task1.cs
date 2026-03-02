namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            // Создание приватных полей
            private string _name;
            private string _surname;
            private int _votes;
            
            // Публичные свойства для полей
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            // Конструктор только для name and surname
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }

            public int CountVotes(Response[] responses)
            {
                int count = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (_name == responses[i]._name && _surname == responses[i]._surname)
                    {
                        count++;
                    }
                }
                
                for (int i = 0; i < responses.Length; i++)
                {
                    if (_name == responses[i]._name && _surname == responses[i]._surname)
                    {
                        responses[i]._votes = count;
                    }
                }
                
                return count;
            }
            
            public void Print()
            {
                Console.WriteLine("Name: " + _name + ", Surname: " + _surname + ", Votes: " + _votes);
            }
        }
    }
}
