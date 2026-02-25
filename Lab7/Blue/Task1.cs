namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            private string _Name;
            private string _Surname;
            private int _Votes;

            public string Name => _Name;
            public string Surname => _Surname;
            public int Votes => _Votes;

            public Response(string Name, string Surname)
            {
                _Name = Name;
                _Surname = Surname;
                _Votes = 0;
            }
            private Response(string Name, string Surname, int Votes)
            {
                _Name = Name;
                _Surname = Surname;
                _Votes = Votes;
            }

            public int CountVotes(Response[] responses)
            {
                int count = 0;
                foreach (var vote in responses)
                {
                    if (vote.Name == this.Name && vote.Surname == this.Surname)
                        count++;
                }
                for(int i = 0; i < responses.Length; i++)
                {
                    if(responses[i].Name == this.Name && responses[i].Surname == this.Surname)
                    {
                        responses[i]=new Response(responses[i].Name,responses[i].Surname,count);
                    }
                }

                return count; 
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name} \nФамилия: {Surname} \nГолоса: {Votes}");
            }
        }
    }
}
