using System.Runtime;
using System.Xml.Linq;
using static Lab7.Purple.Task5;

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
                if (responses == null || responses.Length == 0) return 0;
                int k = 0;
                if (questionNumber == 1) 
                {
                    for (int i = 0; i < responses.Length; i++)
                    {
                        if (responses[i].Animal == _animal)
                        {
                            k++;
                        }
                    }
                }
                else if (questionNumber == 2)
                {
                    for (int i = 0; i < responses.Length; i++)
                    {
                        if (responses[i].CharacterTrait == _charactertrait)
                        {
                            k++;
                        }
                    }
                }
                else if (questionNumber == 3)
                {
                    for (int i = 0; i < responses.Length; i++)
                    {
                        if (responses[i].Concept == _concept)
                        {
                            k++;
                        }
                    }
                }
                return k;
            }
            public void Print()
            {
                Console.WriteLine(_animal);
                Console.WriteLine(_charactertrait);
                Console.WriteLine(_concept);
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
                Response newAnswer = new Response(answers[0], answers[1], answers[2]);
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = newAnswer;
            }
            public string[] GetTopResponses(int question)
            {
                if (_responses.Length == 0 || _responses == null) return null;
                string[] ans = new string[0];
                if (question == 1)
                {
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        Array.Resize(ref ans, ans.Length + 1);
                        ans[^1] = _responses[i].Animal;
                    }
                }
                else if (question == 2)
                {
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        Array.Resize(ref ans, ans.Length + 1);
                        ans[^1] = _responses[i].CharacterTrait;
                    }
                }
                else if (question == 3)
                {
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        Array.Resize(ref ans, ans.Length + 1);
                        ans[^1] = _responses[i].Concept;
                    }
                }

                int[] ans_kol = new int[ans.Length];
                for (int i = 0;  i < ans.Length; i++)
                {
                    int k = 1;
                    if (ans[i] != null)
                    {
                        for (int j = i+1; j < ans.Length; j++)
                        {
                            if (ans[i] == ans[j]) 
                            {
                                k++;
                                ans[j] = null;
                            }
                        }
                        ans_kol[i] = k;
                    }


                }
                int[] temp_kol = new int[ans_kol.Length];
                Array.Copy(ans_kol, temp_kol, ans_kol.Length);
                string[] ans_fin = new string[0];
                for (int i = 0; i < 5; i++)
                {
                    if (ans_kol.Max() == 0 ) break;
                    for (int j = 0; j < ans_kol.Length; j ++)
                    {
                        if (ans_kol[j]== ans_kol.Max() && ans[j] != null)
                        {
                            Array.Resize(ref ans_fin, ans_fin.Length+1);
                            ans_fin[i] = ans[j];
                            ans_kol[j] = 0;
                            break;

                        }
                    }
                }
                Console.WriteLine(string.Join(" ", ans));
                Console.WriteLine(string.Join(" ", ans_kol));
                Console.WriteLine(string.Join(" ", ans_fin));
                return ans_fin;
                
            }
            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_responses);
            }
        }
    }
}