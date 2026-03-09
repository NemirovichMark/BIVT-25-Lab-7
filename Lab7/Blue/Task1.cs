using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            //fields
            private string _name;
            private string _surname;
            private int _votes;

            //parameters
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Votes { get { return _votes; } }

            //methods
            
            public int CountVotes(Response[] responses)
            {
                int count = 0;
                foreach (Response res in responses)
                {
                    if (res.Name == _name && res.Surname == _surname) { count++; }
                }
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == _name && responses[i].Surname == _surname)
                    {
                        Response res = responses[i];
                        res._votes = count;
                        responses[i] = res;
                    }
                }
                return count;
            }

            public void Print()
            {
                System.Console.WriteLine($"Name: {Name}, Surname: {Surname}, Votes: {_votes}");
            }

            //construct
            public Response (string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }


        }
    }
}