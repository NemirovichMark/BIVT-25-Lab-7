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
            public Response(string Animal, string CharacterTrait, string Concept)
            {
                _animal = Animal;
                _characterTrait = CharacterTrait;
                _concept = Concept;
            }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                int res = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (questionNumber == 1)
                    {
                        if (_animal != null && _animal != "" && responses[i].Animal == _animal)
                        {
                            res++;
                        }
                    }
                    if (questionNumber == 2)
                    {
                        if (_characterTrait != null && _characterTrait != "" && responses[i].CharacterTrait == _characterTrait)
                        {
                            res++;
                        }
                    }
                    if (questionNumber == 3)
                    {
                        if (_concept != null && _concept != "" && responses[i].Concept == _concept)
                        {
                            res++;
                        }
                    }
                }
                return res;
            }
            public void Print()
            {
                Console.WriteLine($"Животное: {Animal}, Черта: {CharacterTrait}, Понятие: {Concept}");
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;
            public string Name => _name;
            public Response[] Responses => _responses;

            public Research(string Name)
            {
                _name = Name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                string animal = "";
                string characterTrait = "";
                string concept = "";

                if (answers.Length > 0)
                {
                    animal = answers[0];
                }
                if (answers.Length > 1)
                {
                    characterTrait = answers[1];
                }
                if (answers.Length > 2)
                {
                    concept = answers[2];
                }

                Response newResponse = new Response(animal, characterTrait, concept);

                Response[] temp = new Response[_responses.Length + 1];
                for (int i = 0; i < _responses.Length; i++)
                {
                    temp[i] = _responses[i];
                }
                temp[_responses.Length] = newResponse;
                _responses = temp;
            }

            public string[] GetTopResponses(int question)
            {
                string[] uniqueAnswers = new string[0];
                int[] voteCounts = new int[0];

                for (int i = 0; i < _responses.Length; i++)
                {
                    string answer = "";
                    if (question == 1)
                    {
                        answer = _responses[i].Animal;
                    }
                    else if (question == 2)
                    {
                        answer = _responses[i].CharacterTrait;
                    }
                    else if (question == 3)
                    {
                        answer = _responses[i].Concept;
                    }

                    if (answer == null || answer == "")
                    {
                        continue;
                    }

                    bool found = false;
                    for (int j = 0; j < uniqueAnswers.Length; j++)
                    {
                        if (uniqueAnswers[j] == answer)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        string[] tempAnswers = new string[uniqueAnswers.Length + 1];
                        int[] tempCounts = new int[voteCounts.Length + 1];
                        for (int j = 0; j < uniqueAnswers.Length; j++)
                        {
                            tempAnswers[j] = uniqueAnswers[j];
                            tempCounts[j] = voteCounts[j];
                        }
                        tempAnswers[uniqueAnswers.Length] = answer;

                        string animal = "";
                        string characterTrait = "";
                        string concept = "";

                        if (question == 1)
                        {
                            animal = answer;
                        }
                        else if (question == 2)
                        {
                            characterTrait = answer;
                        }
                        else if (question == 3)
                        {
                            concept = answer;
                        }

                        Response countResponse = new Response(animal, characterTrait, concept);
                        tempCounts[voteCounts.Length] = countResponse.CountVotes(_responses, question);

                        uniqueAnswers = tempAnswers;
                        voteCounts = tempCounts;
                    }
                }

                for (int i = 0; i < uniqueAnswers.Length - 1; i++)
                {
                    for (int j = i + 1; j < uniqueAnswers.Length; j++)
                    {
                        if (voteCounts[i] < voteCounts[j])
                        {
                            (voteCounts[i], voteCounts[j]) = (voteCounts[j], voteCounts[i]);
                            (uniqueAnswers[i], uniqueAnswers[j]) = (uniqueAnswers[j], uniqueAnswers[i]);
                        }
                    }
                }

                int topCount = 5;
                if (uniqueAnswers.Length < 5)
                {
                    topCount = uniqueAnswers.Length;
                }

                string[] result = new string[topCount];
                for (int i = 0; i < topCount; i++)
                {
                    result[i] = uniqueAnswers[i];
                }
                return result;
            }

            public void Print()
            {
                Console.WriteLine($"Исследование: {Name}");
                Console.WriteLine("Ответы:");
                for (int i = 0; i < _responses.Length; i++)
                {
                    _responses[i].Print();
                }
            }
        }
    }
}