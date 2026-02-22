using System.Runtime;
using System.Xml.Linq;
using System.Linq;

namespace Lab7.Purple
{
    public class Task5
    {
        public struct Response
        {

            //поля

            private string _animal;
            private string _characterTrait;
            private string _concept;

            //свойства

            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;

            //конструктор

            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            //методы

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null || questionNumber > 3 || questionNumber < 1)
                {
                    return 0;
                }
                int cnt = 0;

                if (questionNumber == 1)
                    foreach (Response r in responses)
                        cnt += Convert.ToInt32(Animal == r.Animal);
                else if (questionNumber == 2)
                    foreach (Response r in responses)
                        cnt += Convert.ToInt32(CharacterTrait == r.CharacterTrait);
                else
                    foreach (Response r in responses)
                        cnt += Convert.ToInt32(Concept == r.Concept);
                
                return cnt;
            }

            public void Print()
            {
                Console.WriteLine($"{Animal} {CharacterTrait} {Concept}");
            }
        }


        public struct Research
        {
            //поля

            private string _name;
            private Response[] _responses;

            //свойства

            public string Name => _name;
            public Response[] Responses
            {
                get
                {
                    if (_responses == null)
                    {
                        return new Response[0];
                    }
                    return _responses;
                }
            }

            //конструктор

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            //методы

            public void Add(string[] answers)
            {
                if (answers == null || answers.Length != 3)
                {
                    return;
                }
                Array.Resize(ref _responses, _responses.Length + 1);
                Response r = new Response(answers[0], answers[1], answers[2]);
                _responses[^1] = r;
            }

            public string[] GetTopResponses(int question)
            {
                if (question > 3 || question < 1 || _responses == null || _responses.Length == 0)
                {
                    return new string[0];
                }
                int cntAnswers;
                string mx = "";
                string[] answers = new string[0];
                int cntmx;
                string[] allAnswer = new string[0];

                if (question == 1)
                {
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Animal != "" && _responses[i].Animal != null)
                        {
                            Array.Resize(ref allAnswer, allAnswer.Length + 1);
                            allAnswer[^1] = _responses[i].Animal;
                        }
                    }
                }
                else if (question == 2)
                {
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].CharacterTrait != "" && _responses[i].CharacterTrait != null)
                        {
                            Array.Resize(ref allAnswer, allAnswer.Length + 1);
                            allAnswer[^1] = _responses[i].CharacterTrait;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Concept != "" && _responses[i].Concept != null)
                        {
                            Array.Resize(ref allAnswer, allAnswer.Length + 1);
                            allAnswer[^1] = _responses[i].Concept;
                        }
                    }
                }

                for(int len = 0; len < 5; len++)
                {
                    cntmx = 0;
                    mx = "";
                    foreach (string answer in allAnswer)
                    {
                        cntAnswers = allAnswer.Count(x => x == answer);
                        if (answers.Contains(answer) == false && cntAnswers > cntmx)
                        {
                            cntmx = cntAnswers;
                            mx = answer;
                        }
                    }
                    if (mx != "" && mx != null)
                    {
                        Array.Resize(ref answers, answers.Length + 1);
                        answers[^1] = mx;
                    }
                    else
                    {
                        break;
                    }
                }
                return answers;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Responses}");
            }

        }
    }
}
