using System.Runtime;
using System.Xml.Linq;

namespace Lab7.Purple
{
    public class Task5
    {
        public struct Response
        {
            private string _animal;
            private string _characterTrait;
            private string _concept;

            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;

            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                int count = 0;

                for (int i = 0; i < responses.Length; i++)
                {
                    if (questionNumber == 1 && responses[i].Animal == _animal)
                    {
                        count++;
                    } else if (questionNumber == 2 && responses[i].CharacterTrait == _characterTrait)
                    {
                        count++;
                    } else if (questionNumber == 3 && responses[i].Concept == _concept)
                    {
                        count++;
                    }
                }

                return count;
            }

            public void Print()
            {
                Console.WriteLine(_animal);
                Console.WriteLine(_characterTrait);
                Console.WriteLine(_concept);
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses => _responses;

            public Research (string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                Response[] array = new Response[_responses.Length + 1];

                for (int i = 0; i < _responses.Length; i++)
                {
                    array[i] = _responses[i];
                }

                array[array.Length - 1] = new Response(answers[0], answers[1], answers[2]);
                _responses = array;
            }

            public string[] GetTopResponses(int question)
            {
                var dict = new Dictionary<string, int>();

                for (int i = 0; i < _responses.Length; i++)
                {
                    if (question == 1)
                    {
                        if (_responses[i].Animal == null) continue;
                        dict[_responses[i].Animal] = dict.ContainsKey(_responses[i].Animal) ? dict[_responses[i].Animal] + 1 : 1;
                    } else if (question == 2)
                    {
                        if (_responses[i].CharacterTrait == null) continue;
                        dict[_responses[i].CharacterTrait] = dict.ContainsKey(_responses[i].CharacterTrait) ? dict[_responses[i].CharacterTrait] + 1 : 1;
                    } else
                    {
                        if (_responses[i].Concept == null) continue;
                        dict[_responses[i].Concept] = dict.ContainsKey(_responses[i].Concept) ? dict[_responses[i].Concept] + 1 : 1;
                    }
                }

                var sorted = dict.OrderByDescending(kv => kv.Value).ToList();
                string[] array = new string[dict.Count < 5 ? dict.Count : 5];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = sorted[i].Key;
                }

                return array;
            }

            public void Print()
            {
                string[] resp1 = GetTopResponses(1);
                string[] resp2 = GetTopResponses(2);
                string[] resp3 = GetTopResponses(3);

                for (int i = 0; i < resp1.Length; i++)
                {
                    Console.WriteLine(resp1[i]);
                }

                for (int i = 0; i < resp2.Length; i++)
                {
                    Console.WriteLine(resp2[i]);
                }

                for (int i = 0; i < resp3.Length; i++)
                {
                    Console.WriteLine(resp3[i]);
                }
            }
        }
    }
}
