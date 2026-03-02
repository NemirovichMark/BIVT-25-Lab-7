using System.Runtime;
using System.Xml.Linq;
using static Lab7.Purple.Task4;

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
            public string CharacterTrait=> _characterTrait;
            public string Concept=> _concept;
            public Response(string animal,string characterTrait,string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                int count = 0;

                if (questionNumber < 1 || questionNumber > 3)
                    return 0;

                string currentValue = "";
                switch (questionNumber)
                {
                    case 1:
                        currentValue = Animal;
                        break;
                    case 2:
                        currentValue = CharacterTrait;
                        break;
                    case 3:
                        currentValue = Concept;
                        break;
                }

                foreach (Response response in responses)
                {
                    string responseValue = "";
                    switch (questionNumber)
                    {
                        case 1:
                            responseValue = response.Animal;
                            break;
                        case 2:
                            responseValue = response.CharacterTrait;
                            break;
                        case 3:
                            responseValue = response.Concept;
                            break;
                    }

                    if (currentValue == responseValue)
                    {
                        count++;
                    }
                }

                return count;
            }
            public void Print()
            {
                Console.WriteLine($"Animal:{_animal}");
                Console.WriteLine($"CharacterTrait:{_characterTrait}");
                Console.WriteLine($"Concept:{_concept}");
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
                _responses= new Response[0];
            }
            public void Add(string[] answers)
            {
                if (answers.Length != 3 || answers==null) return;
                
                Response[] newArray = new Response[_responses.Length + 1];
                for (int i = 0; i < _responses.Length; i++)
                {
                    newArray[i] = _responses[i];
                }
                Response newResponse = new Response(answers[0], answers[1], answers[2]);
                newArray[_responses.Length] = newResponse;
                _responses = newArray;
                
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
                Console.WriteLine(Name);
                Console.WriteLine(string.Join(" ", Responses));
            }
        }
    }  
}
