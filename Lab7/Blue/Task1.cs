namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            //поля
            private string _name;
            private string _surname;
            private int _votes;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            //конструктор
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            public int CountVotes(Response[] responses)
            {
                int count = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == Name && responses[i].Surname == Surname)
                    {
                        count++;
                    }
                }
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == Name && responses[i].Surname == Surname)
                    {
                        responses[i]._votes = count;
                    }
                }
                return count;
            }

            public void Print()
            {
                Console.WriteLine($"имя: {Name}, фамилия: {Surname}, голоса: {Votes}");
            }
        }
    }
}
