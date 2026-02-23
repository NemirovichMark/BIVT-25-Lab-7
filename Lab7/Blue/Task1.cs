namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int _votes;
            
            public string Name { get => _name; }
            public string Surname { get => _surname; }
            public int Votes { get => _votes; }

            public Response(string name, string surname) {
                _name = name;
                _surname = surname;
            }

            public void Print()
            {
                Console.WriteLine($"({_name} {_surname}) has {_votes} votes");
            }
            /* C# idiomatic???
            public int CountVotes(Response[] responses)
            {
                _votes = responses.Count(Eq);
                
                for (int i = 0; i < responses.Length; i += 1)
                {
                    ref var resp = ref responses[i];
                    if (Eq(resp)) { resp._votes = _votes; }
                }
                return _votes;
            }
            
            
            */
            bool Eq(Response some) => _name == some._name && _surname == some._surname;
            // More MONADS
            private Monads.Maybe<int> Count(Response[] responses)
            {
                if (responses.Length == 0) return Monads.Maybe<int>.Nothing();
                int count = 0;
                foreach (var response in responses)
                {
                    if (Eq(response)) count++;
                }
                if  (count == 0) return Monads.Maybe<int>.Nothing();
                _votes = count;
                return Monads.Maybe<int>.Just(count);
            }

            public int CountVotes(Response[] responses)
            {
                var monad = Count(responses);
                if (monad.HasValue == false) { return 0;}
                for (int i = 0; i < responses.Length; i += 1)
                {
                    ref var resp = ref responses[i];
                    if (Eq(resp)) { resp._votes = _votes; }
                }

                return _votes;
            }
            
        }
    }
}
