using System.Net.Quic;
using System.Runtime;
using System.Xml.Linq;

namespace Lab7.Purple
{
    public class Task5
    {
        public struct Response
        {
            private string _animal;
            private string _charactertrait;
            private string _concept;
            public string Animal => _animal;
            public string CharacterTrait => _charactertrait;
            public string Concept => _concept;

            public Response(string animal, string charactertrait, string concept)
            {
                _animal = animal;
                _charactertrait = charactertrait;
                _concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null || questionNumber > 3 || questionNumber < 1) return default(int);
                int count = 0;
                foreach (Response r in responses)
                {
                    if (questionNumber == 1)
                    {
                        if (_animal == r._animal) count++;
                    }
                    else if (questionNumber == 2)
                    {
                        if(_charactertrait == r._charactertrait) count++;
                    }
                    else
                    {
                        if(_concept == r._concept) count++;
                    }
                }
                return count;
            }

            public void Print()
            {
                Console.WriteLine(Animal,"\n",CharacterTrait,"\n",Concept);
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
                if (answers == null) return;
                Array.Resize(ref _responses,_responses.Length+1);
                _responses[_responses.Length - 1] = new Response(answers[0], answers[1], answers[2]);
            }

            public string[] GetTopResponses(int question)
            {
                if (question > 3 || question < 1) return null;
                string[] responses = null;
                if (question == 1)
                {
                    Response[] array = new Response[_responses.Length];
                    int count = 0;
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Animal == null) continue;
                        int n = 0;
                        for (int j = 0; j < count; j++)
                        {
                            if (_responses[i].Animal == array[j].Animal)
                            {
                                n = 1;
                                break;
                            }
                        }

                        if (n == 0)
                        {
                            array[count] = _responses[i];
                            count++;
                        }
                    }
                    
                    int i1 = 0;
                    while (i1 < count)
                    {
                        if (i1 == 0 || array[i1].CountVotes(_responses, question) <=
                            array[i1 - 1].CountVotes(_responses, question))
                        {
                            i1++;
                        }
                        else
                        {
                            Response tmp = array[i1];
                            array[i1] = array[i1 - 1];
                            array[i1 - 1] = tmp;
                            i1--;
                        }
                    }

                    if (count > 5)
                    {
                        count = 5;
                    }
                    string[] ans = new string[count];
                    for (int i = 0; i < count; i++)
                    {
                        ans[i] = array[i].Animal;
                    }

                    responses = ans;
                }
                else if (question == 2)
                {
                    Response[] array = new Response[_responses.Length];
                    int count = 0;
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].CharacterTrait == null) continue;
                        int n = 0;
                        for (int j = 0; j < count; j++)
                        {
                            if (_responses[i].CharacterTrait == array[j].CharacterTrait)
                            {
                                n = 1;
                                break;
                            }
                        }

                        if (n == 0)
                        {
                            array[count] = _responses[i];
                            count++;
                        }
                    }

                    int i1 = 0;
                    while (i1 < count)
                    {
                        if (i1 == 0 || array[i1].CountVotes(_responses, question) <=
                            array[i1 - 1].CountVotes(_responses, question))
                        {
                            i1++;
                        }
                        else
                        {
                            Response tmp = array[i1];
                            array[i1] = array[i1 - 1];
                            array[i1 - 1] = tmp;
                            i1--;
                        }
                    }

                    if (count > 5)
                    {
                        count = 5;
                    }
                    string[] ans = new string[count];
                    for (int i = 0; i < count; i++)
                    {
                        ans[i] = array[i].CharacterTrait;
                    }

                    responses = ans;
                }
                else
                {
                    Response[] array = new Response[_responses.Length];
                    int count = 0;
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Concept == null) continue;
                        int n = 0;
                        for (int j = 0; j < count; j++)
                        {
                            if (_responses[i].Concept == array[j].Concept)
                            {
                                n = 1;
                                break;
                            }
                        }

                        if (n == 0)
                        {
                            array[count] = _responses[i];
                            count++;
                        }
                    }
                    int i1 = 0;
                    while (i1 < count)
                    {
                        if (i1 == 0 || array[i1].CountVotes(_responses, question) <=
                            array[i1 - 1].CountVotes(_responses, question))
                        {
                            i1++;
                        }
                        else
                        {
                            Response tmp = array[i1];
                            array[i1] = array[i1 - 1];
                            array[i1 - 1] = tmp;
                            i1--;
                        }
                    }

                    if (count > 5)
                    {
                        count = 5;
                    }
                    string[] ans = new string[count];
                    for (int i = 0; i < count; i++)
                    {
                        ans[i] = array[i].Concept;
                    }

                    responses = ans;
                }

                return responses;
            }

            public void Print()
            {
                Console.WriteLine(string.Join(" ",GetTopResponses(1)));
                Console.WriteLine(string.Join(" ",GetTopResponses(2)));
                Console.WriteLine(string.Join(" ",GetTopResponses(3)));
            }
        }
        
    }
}
