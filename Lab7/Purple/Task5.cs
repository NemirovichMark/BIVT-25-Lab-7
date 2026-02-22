using System.Numerics;
using System.Runtime;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Lab7.Purple
{
    public class Task5
    {
        public struct Response
        {
            // Animal, CharacterTrait, Concept.
            private string _animal;
            private string _charactertrait;
            private string _concept;

            public string Animal => _animal;
            public string CharacterTrait => _charactertrait;
            public string Concept => _concept;

            public Response (string animal , string charactertrait , string concept)
            {
                _animal = animal;
                _charactertrait = charactertrait;
                _concept = concept;
            }
            // метод который считает, сколько ответов на выбранный вопрос(от 1 до 3) из списка анкет совпадает с текущей анкетой
            public int CountVotes(Response[] responses, int questionNumber)
            {
                int count = 0;
                if (questionNumber == 1)
                {
                    for (int i = 0; i < responses.Length; i++)
                    {
                        if (_animal == responses[i]._animal)
                        {
                            count++;
                        }
                    }
                }
                if (questionNumber == 2)
                {
                    for (int i = 0; i < responses.Length; i++)
                    {
                        if (_charactertrait == responses[i]._charactertrait)
                        {
                            count++;
                        }
                    }
                }
                if (questionNumber == 3)
                {
                    for (int i = 0; i < responses.Length; i++)
                    {
                        if (_concept == responses[i]._concept)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
            public void Print()
            {
                Console.WriteLine(_animal);
            }
        }
        public struct Research
        {
            //  Name, Responses. 
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
                if (answers == null || answers.Length != 3) return;
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = new Response( answers[0], answers[1], answers[2]);
            }
            //который возвращает до 5 наиболее часто встречающихся ответов по указанному вопросу.
            public string[] GetTopResponses(int question)
            {
                string[] result = new string[5];
                if (question == 1)
                {
                    // новый массив для ответов 
                    string[] top = new string[0];
                   
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Animal != null)
                        {
                            Array.Resize(ref top, top.Length + 1);
                            top[top.Length - 1] = _responses[i].Animal;
                        }
                    }
                    // массив для подсчета сколько раз отвечади также
                    int[] count = new int[top.Length];
                    for (int i = 0;i < count.Length;i++)
                    {
                        if (_responses[i].Animal != null)
                        {
                            count[i] = _responses[i].CountVotes(_responses, question);
                        } 
                    }
                    // цикл для замены похожих 
                    for (int i = 0;i <count.Length;i++)
                    {
                        for (int j = 0; j < count.Length; j++)
                        {
                            if (i != j & top[i] == top[j])
                            {
                                top[j] = null;
                                count[j] = -10;
                            }
                        }
                    }
                    int k = 0;
                    // подсчитываем сколкьо всего там разных ответов
                    for (int i = 0; i < count.Length; i++)
                    {
                        if (top[i] != null)
                        {
                            k++;
                        }
                    }
                    // создаем новые массивы где будут только различные без повторяющихся
                    string[] top2 = new string[k];
                    int[] count2 = new int[k];
                    int c= 0;
                    for (int i = 0;i < top.Length;i++)
                    {
                        if (top[i] != null)
                        {
                            top2[c] = top[i];
                            count2[c] = count[i];
                            c++;
                        }
                    }
                    // сортирую по количеству два массива
                    for (int i =0;i < count2.Length;i++)
                    {
                        for (int j = 1;j < count2.Length;j++)
                        {
                            if (count2[j] > count2[j-1])
                            {
                                (top2[j], top2[j - 1]) = (top2[j-1], top2[j]);
                                (count2[j], count2[j - 1]) = (count2[j - 1], count2[j]);
                            }
                        }
                    }
                    if (top2.Length < 5)
                    {
                        result = new string[top2.Length];
                    }
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = top2[i];
                    }
                }
                if (question == 2)
                {
                    string[] top = new string[0];

                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Animal != null)
                        {
                            Array.Resize(ref top, top.Length + 1);
                            top[top.Length - 1] = _responses[i].CharacterTrait;
                        }
                    }
                    int[] count = new int[top.Length];
                    for (int i = 0; i < count.Length; i++)
                    {
                        if (_responses[i].Animal != null)
                        {
                            count[i] = _responses[i].CountVotes(_responses, question);
                        }
                    }
                    for (int i = 0; i < count.Length; i++)
                    {
                        for (int j = 0; j < count.Length; j++)
                        {
                            if (i != j & top[i] == top[j])
                            {
                                top[j] = null;
                                count[j] = -10;
                            }
                        }
                    }
                    int k = 0;
                    for (int i = 0; i < count.Length; i++)
                    {
                        if (top[i] != null)
                        {
                            k++;
                        }
                    }
                    string[] top2 = new string[k];
                    int[] count2 = new int[k];
                    int c = 0;
                    for (int i = 0; i < top.Length; i++)
                    {
                        if (top[i] != null)
                        {
                            top2[c] = top[i];
                            count2[c] = count[i];
                            c++;
                        }
                    }
                    for (int i = 0; i < count2.Length; i++)
                    {
                        for (int j = 1; j < count2.Length; j++)
                        {
                            if (count2[j] > count2[j - 1])
                            {
                                (top2[j], top2[j - 1]) = (top2[j - 1], top2[j]);
                                (count2[j], count2[j - 1]) = (count2[j - 1], count2[j]);
                            }
                        }
                    }
                    if (top2.Length < 5)
                    {
                        result = new string[top2.Length];
                    }
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = top2[i];
                    }
                }
                if (question == 3)
                {
                    string[] top = new string[0];

                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Animal != null)
                        {
                            Array.Resize(ref top, top.Length + 1);
                            top[top.Length - 1] = _responses[i].Concept;
                        }
                    }
                    int[] count = new int[top.Length];
                    for (int i = 0; i < count.Length; i++)
                    {
                        if (_responses[i].Animal != null)
                        {
                            count[i] = _responses[i].CountVotes(_responses, question);
                        }
                    }
                    for (int i = 0; i < count.Length; i++)
                    {
                        for (int j = 0; j < count.Length; j++)
                        {
                            if (i != j & top[i] == top[j])
                            {
                                top[j] = null;
                                count[j] = -10;
                            }
                        }
                    }
                    int k = 0;
                    for (int i = 0; i < count.Length; i++)
                    {
                        if (top[i] != null)
                        {
                            k++;
                        }
                    }
                    string[] top2 = new string[k];
                    int[] count2 = new int[k];
                    int c = 0;
                    for (int i = 0; i < top.Length; i++)
                    {
                        if (top[i] != null)
                        {
                            top2[c] = top[i];
                            count2[c] = count[i];
                            c++;
                        }
                    }
                    for (int i = 0; i < count2.Length; i++)
                    {
                        for (int j = 1; j < count2.Length; j++)
                        {
                            if (count2[j] > count2[j - 1])
                            {
                                (top2[j], top2[j - 1]) = (top2[j - 1], top2[j]);
                                (count2[j], count2[j - 1]) = (count2[j - 1], count2[j]);
                            }
                        }
                    }
                    if (top2.Length < 5)
                    {
                        result = new string[top2.Length];
                    }
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = top2[i];
                    }
                }
                return result;
            
            }

            public void Print()
            {
                Console.WriteLine(_name);

            }


        }


    }
}
