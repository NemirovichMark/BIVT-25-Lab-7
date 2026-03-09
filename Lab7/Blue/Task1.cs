namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int _votes;

            // читаем свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            // конструктор с проверками
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

                _votes = 0;
            }

            public int CountVotes(Response[] responses)
            {
                int count = 0;

                //  считаем голоса для этого чела

                for (int i = 0; i < responses.Length; i++)
                {
                    if (_name == responses[i]._name && _surname == responses[i]._surname)
                    {
                        count++;
                    }
                }

                // меняем для всего него

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
                Console.WriteLine($"{Name} {Surname}: {Votes}");
            }
        }
    }
}
