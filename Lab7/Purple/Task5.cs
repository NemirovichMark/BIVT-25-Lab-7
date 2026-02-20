using System.Runtime;
using System.Xml.Linq;

namespace Lab7.Purple
{
    public class Task5
    {
        private static bool Find(string[] arr, string elem)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == elem) return true;
            }
            return false;
        }
        private static void AddM<T>(ref T[] arr, T elem)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = elem;
        }
        public struct Response
        {
            private string _animal;
            private string _characterTrait;
            private string _concept;

            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;

            public Response(string a1 = "", string a2 = "", string a3 = "")
            {
                _animal = a1;
                _characterTrait = a2;
                _concept = a3;
            }

            public int CountVotes(Response[] responses, int qNum)
            {
                int ans = 0;

                for(int i = 0; i < responses.Length; i++)
                {
                    if (qNum == 1) if (Animal == responses[i].Animal) ans++;
                    if (qNum == 2) if(CharacterTrait == responses[i].CharacterTrait) ans++;
                    if (qNum == 3) if (Concept == responses[i].Concept) ans++;
                }
                return ans;
            }

            public void Print()
            {
                Console.WriteLine($"{Animal, 20}, {CharacterTrait, 20}, {Concept, 20}");
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses => _responses;

            public Research(string name)
            {
                _name = name; 
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[^1] = new Response(answers[0], answers[1], answers[2]);
            }
            public string[] GetTopResponses(int num)
            {
                int elems = 5;
                var checks = new string[0];
                var top = new (string, int)[0];
                for(var i = 0; i < Responses.Length; i++)
                {
                    if(num == 1)
                    {
                        if (Find(checks, Responses[i].Animal)) continue;
                        AddM(ref checks, Responses[i].Animal);
                        AddM(ref top, (Responses[i].Animal, Responses[i].CountVotes(Responses, num)));
                    }
                    if (num == 2)
                    {
                        if (Find(checks, Responses[i].CharacterTrait)) continue;
                        AddM(ref checks, Responses[i].CharacterTrait);
                        AddM(ref top, (Responses[i].CharacterTrait, Responses[i].CountVotes(Responses, num)));
                    }
                    if (num == 3)
                    {
                        if (Find(checks, Responses[i].Concept)) continue;
                        AddM(ref checks, Responses[i].Concept);
                        AddM(ref top, (Responses[i].Concept, Responses[i].CountVotes(Responses, num)));
                    }
                }
                top = (from i in top
                       orderby i.Item2 descending
                       select i).ToArray();
                checks = new string[0];
                for(int i = 0; i < top.Length; i++) Console.WriteLine($"{i + 1}: {top[i].Item1} - {top[i].Item2}");
                Console.WriteLine("OK");
                for (int i = 0; i < elems && i < top.Length; i++)
                {
                    if (top[i].Item1 == null) continue;
                    AddM(ref checks, top[i].Item1);
                }
                return checks;
            }
            public void Print()
            {
                for(int i = 0; i < Responses.Length; i++)
                {
                    Console.Write($"{i, 3}: ");
                    Responses[i].Print();
                }
            }
        }
    }
}