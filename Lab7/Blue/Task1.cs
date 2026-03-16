namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int _votes;

            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            public int CountVotes(Response[] responses)
            {
                if (responses == null)
                {
                    return 0;
                }

                int count = 0;

                foreach (var response in responses)
                {
                    if (response.Name == _name &&
                        response.Surname == _surname)
                    {
                        count++;
                    }
                }

                _votes = count;

                for (int i = 0; i < responses.Length; i++)
                {
                    if (Name == responses[i].Name & Surname == responses[i].Surname)
                    {
                        responses[i]._votes = count;
                    }
                }

                return count;
            }

            public void Print()
            {
                Console.WriteLine($"Кандидат: {Name} {Surname}");
                Console.WriteLine($"Количество голосов: {Votes}");
            }
        }
    }
}
