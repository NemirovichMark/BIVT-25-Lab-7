using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static Lab7.Purple.Task5;

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
                    if (questionNumber == 1)
                    {
                        if (responses[i].Animal == _animal) count++;
                    }
                    if (questionNumber == 2)
                    {
                        if (responses[i].CharacterTrait == _characterTrait) count++;
                    }
                    if (questionNumber == 3)
                    {
                        if (responses[i].Concept == _concept) count++;
                    }
                }

                return count;
            }

            public void Print()
            {
                Console.WriteLine($"{_animal} {_characterTrait} {_concept}");
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses
            {
                get
                {
                    var responses = new Response[_responses.Length];
                    Array.Copy(_responses, responses, responses.Length);
                    return responses;
                }
            }

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                Array.Resize(ref _responses, _responses.Length+1);
                var response = new Response(answers[0], answers[1], answers[2]);
                _responses[^1] = response;
            }

            public string[] GetTopResponses(int question)
            {
                string[] result = new string[5];
                if (question == 1)
                {
                    //Создаем массив без null
                    int newRespLen = 0;
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(_responses[i].Animal))
                        {
                            newRespLen++;
                        }
                    }
                    string[] newResponses = new string[newRespLen];
                    for (int i = 0; i < newRespLen; i++)
                    {
                        if (!String.IsNullOrEmpty(_responses[i].Animal))
                        {
                            newResponses[i] = _responses[i].Animal;
                        }
                    }

                    result = new string[5];
                    int[,] amounts = new int[2, newResponses.Length];
                    string resp = newResponses[0];
                    int count = 0;
                    int len = 0;
                    for (int j = 0; j < newResponses.Length; j++)
                    {
                        if (newResponses[j] == resp) count++;
                    }
                    amounts[0, len] = count;
                    amounts[1, len] = 0;
                    for (int i = 1; i < newResponses.Length; i++)
                    {
                        if (newResponses[i] != null)
                        {
                            resp = newResponses[i];
                        }
                        else continue;
                        bool checkIfIn = false;
                        for (int k = 0; k < len; k++)
                        {
                            if (resp == newResponses[amounts[1, k]]) checkIfIn = true;
                        }
                        if (checkIfIn) continue;
                        count = 0;
                        for (int j = 0; j < newResponses.Length; j++)
                        {
                            if (resp == newResponses[j]) count++;
                        }
                        amounts[0, len] = count;
                        amounts[1, len] = i;
                        len++;
                    }
                    for (int i = 0; i < amounts.GetLength(1); i++)
                    {
                        for (int j = i; j < amounts.GetLength(1); j++)
                        {
                            if (amounts[0, i] < amounts[0, j])
                            {
                                (amounts[0, i], amounts[0, j]) = (amounts[0, j], amounts[0, i]);
                                (amounts[1, i], amounts[1, j]) = (amounts[1, j], amounts[1, i]);
                            }
                        }
                    }
                    if (len < 5) result = new string[len];
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = newResponses[amounts[1, i]];
                    }
                }
                if (question == 2)
                {
                    //Создаем массив без null
                    int newRespLen = 0;
                    for (int i = 0; i<_responses.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(_responses[i].CharacterTrait))
                        {
                            newRespLen++;
                        }
                    }
                    string[] newResponses = new string[newRespLen];
                    for (int i = 0; i < newRespLen; i++)
                    {
                        if (!String.IsNullOrEmpty(_responses[i].CharacterTrait))
                        {
                            newResponses[i] = _responses[i].CharacterTrait;
                        }
                    }


                    result = new string[5];
                    int[,] amounts = new int[2, newResponses.Length];
                    string resp = newResponses[0];
                    int count = 0;
                    int len = 0;
                    for (int j = 0; j < newResponses.Length; j++)
                    {
                        if (newResponses[j] == resp) count++;
                    }
                    amounts[0, len] = count;
                    amounts[1, len] = 0;
                    for (int i = 1; i < newResponses.Length; i++)
                    {
                        if (newResponses[i] != null)
                        {
                            resp = newResponses[i];
                        }
                        else continue;
                        bool checkIfIn = false;
                        for (int k = 0; k < len; k++)
                        {
                            if (resp == newResponses[amounts[1, k]]) checkIfIn = true;
                        }
                        if (checkIfIn) continue;
                        count = 0;
                        for (int j = 0; j < newResponses.Length; j++)
                        {
                            if (resp == newResponses[j]) count++;
                        }
                        amounts[0, len] = count;
                        amounts[1, len] = i;
                        len++;
                    }
                    for (int i = 0; i < amounts.GetLength(1); i++)
                    {
                        for (int j = i; j < amounts.GetLength(1); j++)
                        {
                            if (amounts[0, i] <= amounts[0, j])
                            {
                                (amounts[0, i], amounts[0, j]) = (amounts[0, j], amounts[0, i]);
                                (amounts[1, i], amounts[1, j]) = (amounts[1, j], amounts[1, i]);
                            }
                        }
                    }
                    if (len<5) result = new string[len];

                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = newResponses[amounts[1, i]];
                    }
                }
                if (question == 3)
                {
                    //Создаем массив без null
                    int newRespLen = 0;
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(_responses[i].Concept))
                        {
                            newRespLen++;
                        }
                    }
                    string[] newResponses = new string[newRespLen];
                    for (int i = 0; i < newRespLen; i++)
                    {
                        if (!String.IsNullOrEmpty(_responses[i].Concept))
                        {
                            newResponses[i] = _responses[i].Concept;
                        }
                    }


                    result = new string[5];
                    int[,] amounts = new int[2, newResponses.Length];
                    string resp = newResponses[0];
                    int count = 0;
                    int len = 0;
                    for (int j = 0; j < newResponses.Length; j++)
                    {
                        if (newResponses[j] == resp) count++;
                    }
                    amounts[0, len] = count;
                    amounts[1, len] = 0;
                    for (int i = 1; i < newResponses.Length; i++)
                    {
                        if (newResponses[i] != null)
                        {
                            resp = newResponses[i];
                        }
                        else continue;
                        bool checkIfIn = false;
                        for (int k = 0; k < len; k++)
                        {
                            if (resp == newResponses[amounts[1, k]]) checkIfIn = true;
                        }
                        if (checkIfIn) continue;
                        count = 0;
                        for (int j = 0; j < newResponses.Length; j++)
                        {
                            if (resp == newResponses[j]) count++;
                        }
                        amounts[0, len] = count;
                        amounts[1, len] = i;
                        len++;
                    }
                    for (int i = 0; i < amounts.GetLength(1); i++)
                    {
                        for (int j = 0; j < amounts.GetLength(1); j++)
                        {
                            if (amounts[0, i] > amounts[0, j])
                            {
                                (amounts[0, i], amounts[0, j]) = (amounts[0, j], amounts[0, i]);
                                (amounts[1, i], amounts[1, j]) = (amounts[1, j], amounts[1, i]);
                            }
                            if (amounts[1, i] < amounts[1, j] && amounts[0, i] == amounts[0, j])
                            {
                                (amounts[0, i], amounts[0, j]) = (amounts[0, j], amounts[0, i]);
                                (amounts[1, i], amounts[1, j]) = (amounts[1, j], amounts[1, i]);
                            }
                        }
                    }
                    if (len < 5) result = new string[len];
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = newResponses[amounts[1, i]];
                    }
                }
                return result;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_responses}");
            }
        }
    }
}
