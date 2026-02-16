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
                int count = 0;
                foreach (var response in responses)
                {
                    if (response.Name == _name && response.Surname == _surname)
                    {
                        count++;
                    }
                }

                for (int i = 0; i < responses.Length; i++)
                    if (responses[i].Name == _name && responses[i].Surname == _surname)
                        responses[i]._votes = count;

                return count;
            }

            public void Print() { }
            
        }

    }

}