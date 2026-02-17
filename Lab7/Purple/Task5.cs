using System.Runtime;
using System.Xml.Linq;
using System;
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
                string myAnswer = "";
                if (questionNumber == 1)
                {
                    myAnswer = this._animal;
                }

                else if (questionNumber == 2)
                {
                    myAnswer = this._characterTrait;
                }

                else if (questionNumber == 3)
                {
                    myAnswer = this._concept;
                }

                if (myAnswer == null || myAnswer.Length == 0) return 0;

                foreach (Response response in responses)
                {
                    string otherAnswer = "";
                    if (questionNumber == 1)
                    {
                        otherAnswer = response._animal;
                    }
                    else if (questionNumber == 2)
                    {
                        otherAnswer = response._characterTrait;
                    }
                    else if (questionNumber == 3)
                    {
                        otherAnswer = response._concept;
                    }

                    if (myAnswer == otherAnswer)
                    {
                        count++;
                    }
                }
                return count;
            }

            public void Print()
            {
                Console.WriteLine(Animal);
                Console.WriteLine(CharacterTrait);
                Console.WriteLine(Concept);
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

            public void Add(string[] responses)
            {
                Response newResponse = new Response(responses[0], responses[1], responses[2]);
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = newResponse;
            }
            public string[] GetTopResponses(int question)
            {
                if (_responses == null || _responses.Length == 0) return new string[0];
                
                string[] allAnswers = new string[_responses.Length];
                for (int i = 0; i < _responses.Length; i++)
                {
                    allAnswers[i] = (question == 1) ? _responses[i].Animal :
                                    (question == 2) ? _responses[i].CharacterTrait :
                                                      _responses[i].Concept;
                }

                string[] uniqueAnswers = allAnswers.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
                int[] counts = new int[uniqueAnswers.Length];

                for (int i = 0; i < uniqueAnswers.Length; i++)
                {
                    for (int j = 0; j < _responses.Length; j++)
                    {
                        string respVal = (question == 1) ? _responses[j].Animal :
                                         (question == 2) ? _responses[j].CharacterTrait :
                                                           _responses[j].Concept;

                        if (respVal == uniqueAnswers[i])
                        {
                            counts[i] = _responses[j].CountVotes(_responses, question);
                            break; 
                        }
                    }
                }

                for (int i = 0; i < uniqueAnswers.Length - 1; i++)
                {
                    for (int j = 0; j < uniqueAnswers.Length - i - 1; j++)
                    {
                        if (counts[j] < counts[j + 1])
                        {
                            (counts[j], counts[j + 1]) = (counts[j + 1], counts[j]);

                            (uniqueAnswers[j], uniqueAnswers[j + 1]) = (uniqueAnswers[j + 1], uniqueAnswers[j]);
                        }
                    }
                }

                int finalSize = Math.Min(5, uniqueAnswers.Length);
                string[] result = new string[finalSize];
                Array.Copy(uniqueAnswers, result, finalSize);
                return result;
            }

            public void Print()
            {
                Console.WriteLine(Name);
                Console.WriteLine(String.Join(", ", Responses));
            }
        }   
    }
}
