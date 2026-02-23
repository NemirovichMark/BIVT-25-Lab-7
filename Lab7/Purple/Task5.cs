using System;
using System.Linq;

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
                    Response r = responses[i];
                    switch (questionNumber)
                    {
                        case 1:
                            if (r.Animal == _animal) count++;
                            break;
                        case 2:
                            if (r.CharacterTrait == _characterTrait) count++;
                            break;
                        case 3:
                            if (r.Concept == _concept) count++;
                            break;
                    }
                }
                return count;
            }

            public void Print()
            {
                Console.WriteLine($"Animal: {_animal}, CharacterTrait: {_characterTrait}, Concept: {_concept}");
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses => _responses.ToArray(); 

            private struct AnswerStat
            {
                public string Value;
                public int Count;
                public int FirstIndex;
            }

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                Response resp = new Response(answers[0], answers[1], answers[2]);

                int currentLen = _responses.Length;
                Response[] newArr = new Response[currentLen + 1];
                
                Array.Copy(_responses, newArr, currentLen);
                
                newArr[^1] = resp;
                _responses = newArr;
            }

            public string[] GetTopResponses(int question)
            {
                string[] rawAnswers = new string[_responses.Length];
                for (int i = 0; i < _responses.Length; i++)
                {
                    switch (question)
                    {
                        case 1:
                            rawAnswers[i] = _responses[i].Animal;
                            break;
                        case 2:
                            rawAnswers[i] = _responses[i].CharacterTrait;
                            break;
                        case 3:
                            rawAnswers[i] = _responses[i].Concept;
                            break;
                    }
                }

                AnswerStat[] stats = new AnswerStat[_responses.Length];
                int uniqueCount = 0;

                for (int i = 0; i < rawAnswers.Length; i++)
                {
                    string current = rawAnswers[i];
                    if (string.IsNullOrEmpty(current)) continue;

                    int foundIdx = -1;
                    for (int k = 0; k < uniqueCount; k++)
                    {
                        if (stats[k].Value == current)
                        {
                            foundIdx = k;
                            break;
                        }
                    }

                    if (foundIdx == -1)
                    {
                        stats[uniqueCount].Value = current;
                        stats[uniqueCount].Count = 1;
                        stats[uniqueCount].FirstIndex = i;
                        uniqueCount++;
                    }
                    else
                    {
                        stats[foundIdx].Count++;
                    }
                }

                for (int i = 0; i < uniqueCount - 1; i++)
                {
                    for (int j = 0; j < uniqueCount - i - 1; j++)
                    {
                        bool swap = false;
                        if (stats[j].Count < stats[j + 1].Count) swap = true;
                        else if (stats[j].Count == stats[j + 1].Count && stats[j].FirstIndex > stats[j + 1].FirstIndex) swap = true;

                        if (swap)
                        {
                            (stats[j], stats[j + 1]) = (stats[j + 1], stats[j]);
                        }
                    }
                }

                int resultSize = (uniqueCount < 5) ? uniqueCount : 5;
                string[] topResponses = new string[resultSize];
                for (int i = 0; i < resultSize; i++)
                {
                    topResponses[i] = stats[i].Value;
                }

                return topResponses;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                for (int i = 0; i < _responses.Length; i++)
                {
                    _responses[i].Print();
                }
            }
        }
    }
}
