using System.ComponentModel;

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
                this._name = name;
                this._surname = surname;

            }
            public int CountVotes(Response[] responses)
            {
                int local_votes = 0;
                foreach (Response response in responses)
                {
                    if (Name == response.Name & Surname == response.Surname)
                    {
                        local_votes++;
                    }
                }

                for (int i = 0; i < responses.Length; i++)
                {
                    if (Name == responses[i].Name & Surname == responses[i].Surname)
                    {
                        responses[i]._votes = local_votes;
                    }
                }

                return Votes;
            }
            public void Print()
            {
                Console.WriteLine($"Name: {Name}\n Surname: {Surname}\n Votes: {Votes}\n");
            }

        }
    }
}

