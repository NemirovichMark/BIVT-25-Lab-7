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
                if (responses == null || responses.Length == 0) return 0;
                switch (questionNumber)
                {
                    case 1:
                        foreach (Response response in responses)
                        {
                            if (response._animal == _animal) count++;
                        }

                        break;
                    case 2:
                        foreach (Response response in responses)
                        {
                            if (response._characterTrait == _characterTrait) count++;
                        }

                        break;
                    case 3:
                        foreach (Response response in responses)
                        {
                            if (response._concept == _concept) count++;
                        }

                        break;
                }

                return count;
            }

            public void Print()
            {
                Console.WriteLine($"Asking results: {_animal}, {_characterTrait}, {_concept}.");
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
                if (_responses == null || _responses.Length == 0) return new string[0];
                string[] allAnswers = new string[0];
                switch (question)
                {
                    case 1:
                        for (int i = 0; i < _responses.Length; i++)
                        { 
                            Array.Resize(ref allAnswers, allAnswers.Length + 1);
                            allAnswers[allAnswers.Length - 1] = _responses[i].Animal;
                        }
                        break;
                    case 2:
                        for (int i = 0; i < _responses.Length; i++)
                        {
                            Array.Resize(ref allAnswers, allAnswers.Length + 1);
                            allAnswers[allAnswers.Length - 1] = _responses[i].CharacterTrait;
                        }
                        break;
                    case 3:
                        for (int i = 0; i < _responses.Length; i++)
                        {
                            Array.Resize(ref allAnswers, allAnswers.Length + 1);
                            allAnswers[allAnswers.Length - 1] = _responses[i].Concept;
                        }
                        break;
                }
                    
                string[] unique = allAnswers.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
                int[] amounts = new int[unique.Length];

                for (int i = 0; i < allAnswers.Length; i++)
                {
                    for (int j = 0; j < unique.Length; j++)
                    {
                        if (allAnswers[i] == unique[j])
                        {
                            amounts[j]++;
                        }
                    }
                }

                for (int i = 0; i < unique.Length; i++)
                {
                    for (int j = 0; j < unique.Length - i - 1; j++)
                    {
                        if (amounts[j] < amounts[j + 1])
                        {
                            (unique[j], unique[j + 1]) = (unique[j + 1], unique[j]);
                            (amounts[j], amounts[j + 1]) = (amounts[j + 1], amounts[j]);
                        }
                    }
                }
                    
                int resultSize = Math.Min(5, amounts.Length);
                string[] result = new string[resultSize];
                Array.Copy(unique, result, resultSize);
                return result;
            }

            public void Print()
            {
                Console.WriteLine($"Name: {_name}.");
                Console.WriteLine(String.Join(", ", Responses));
            }
        }
    }
}
