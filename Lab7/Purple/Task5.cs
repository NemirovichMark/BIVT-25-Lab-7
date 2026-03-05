using System.Runtime;
using System.Xml.Linq;

namespace Lab7.Purple
{
    public class Task5
    {
        // СТРУКТУРА ОТВЕТА (АНКЕТА)
        public struct Response
        {
            // ПРИВАТНЫЕ ПОЛЯ
            private string _animal;
            private string _characterTrait;
            private string _concept;

            // ПУБЛИЧНЫЕ СВОЙСТВА ТОЛЬКО ДЛЯ ЧТЕНИЯ
            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;

            // КОНСТРУКТОР
            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            // МЕТОД ДЛЯ ПОДСЧЕТА ГОЛОСОВ
            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null || responses.Length == 0) return 0;

                string targetAnswer = "";

                // ОПРЕДЕЛЯЕМ, КАКОЙ ОТВЕТ СРАВНИВАЕМ 
                if (questionNumber == 1)
                {
                    targetAnswer = _animal;
                }
                else if (questionNumber == 2)
                {
                    targetAnswer = _characterTrait;
                }
                else if (questionNumber == 3)
                {
                    targetAnswer = _concept;
                }
                else
                {
                    return 0;
                }

                // Если ответ пустой, возвращаем 0
                if (targetAnswer == null || targetAnswer.Length == 0) return 0;

                int count = 0;

                // Считаем совпадения
                for (int i = 0; i < responses.Length; i++)
                {
                    string currentAnswer = "";

                    // ОПРЕДЕЛЯЕМ ОТВЕТ ТЕКУЩЕЙ АНКЕТЫ (без switch)
                    if (questionNumber == 1)
                    {
                        currentAnswer = responses[i]._animal;
                    }
                    else if (questionNumber == 2)
                    {
                        currentAnswer = responses[i]._characterTrait;
                    }
                    else if (questionNumber == 3)
                    {
                        currentAnswer = responses[i]._concept;
                    }

                    if (currentAnswer == targetAnswer)
                    {
                        count++;
                    }
                }

                return count;
            }

            // МЕТОД ДЛЯ ВЫВОДА
            public void Print()
            {
                Console.WriteLine($"Животное: {Animal}");
                Console.WriteLine($"Черта характера: {CharacterTrait}");
                Console.WriteLine($"Понятие/предмет: {Concept}");
            }
        }

        // СТРУКТУРА ИССЛЕДОВАНИЯ
        public struct Research
        {
            // ПРИВАТНЫЕ ПОЛЯ
            private string _name;
            private Response[] _responses;
            private int _count;

            // ПУБЛИЧНЫЕ СВОЙСТВА ТОЛЬКО ДЛЯ ЧТЕНИЯ
            public string Name => _name;

            // Возвращаем КОПИЮ массива ответов
            public Response[] Responses
            {
                get
                {
                    if (_responses == null) return new Response[0];

                    Response[] copy = new Response[_count];
                    for (int i = 0; i < _count; i++)
                    {
                        copy[i] = _responses[i];
                    }
                    return copy;
                }
            }

            // КОНСТРУКТОР
            public Research(string name)
            {
                _name = name;
                _responses = new Response[100]; // начальный размер
                _count = 0;
            }
            // МЕТОД ДЛЯ ДОБАВЛЕНИЯ ОТВЕТА
            public void Add(string[] answers)
            {
                if (answers == null || answers.Length < 3) return;

                Response newResponse = new Response(answers[0], answers[1], answers[2]);

                if (_count >= _responses.Length)
                {
                    // Увеличиваем массив
                    Response[] newArray = new Response[_responses.Length * 2];
                    for (int i = 0; i < _count; i++)
                    {
                        newArray[i] = _responses[i];
                    }
                    _responses = newArray;
                }

                _responses[_count] = newResponse;
                _count++;
            }

            // МЕТОД ДЛЯ ПОЛУЧЕНИЯ ТОП-5 ОТВЕТОВ
            public string[] GetTopResponses(int question)
            {
                if (question < 1 || question > 3) return new string[0];
                if (_count == 0) return new string[0];

                // Собираем все ответы на вопрос
                string[] allAnswers = new string[_count];
                int answerCount = 0;

                for (int i = 0; i < _count; i++)
                {
                    string answer = "";

                    // ОПРЕДЕЛЯЕМ ОТВЕТ ПО НОМЕРУ ВОПРОСА 
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

                    if (answer != null && answer.Length > 0)
                    {
                        allAnswers[answerCount] = answer;
                        answerCount++;
                    }
                }

                if (answerCount == 0) return new string[0];

                // Подсчитываем частоту ответов
                string[] uniqueAnswers = new string[answerCount];
                int[] frequencies = new int[answerCount];
                int uniqueCount = 0;

                for (int i = 0; i < answerCount; i++)
                {
                    string current = allAnswers[i];
                    bool found = false;

                    for (int j = 0; j < uniqueCount; j++)
                    {
                        if (uniqueAnswers[j] == current)
                        {
                            frequencies[j]++;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        uniqueAnswers[uniqueCount] = current;
                        frequencies[uniqueCount] = 1;
                        uniqueCount++;
                    }
                }

                // Сортируем по частоте (пузырьковая сортировка)
                for (int i = 0; i < uniqueCount - 1; i++)
                {
                    for (int j = 0; j < uniqueCount - i - 1; j++)
                    {
                        if (frequencies[j] < frequencies[j + 1])
                        {
                            // Меняем частоты
                            int tempFreq = frequencies[j];
                            frequencies[j] = frequencies[j + 1];
                            frequencies[j + 1] = tempFreq;

                            // Меняем ответы
                            string tempAns = uniqueAnswers[j];
                            uniqueAnswers[j] = uniqueAnswers[j + 1];
                            uniqueAnswers[j + 1] = tempAns;
                        }
                    }
                }

                // Берем до 5 самых частых
                int topCount = uniqueCount;
                if (topCount > 5)
                {
                    topCount = 5;
                }
                string[] topResponses = new string[topCount];

                for (int i = 0; i < topCount; i++)
                {
                    topResponses[i] = uniqueAnswers[i];
                }

                return topResponses;
            }

            // МЕТОД ДЛЯ ВЫВОДА
            public void Print()
            {
                Console.WriteLine($"Исследование: {Name}");
                Console.WriteLine($"Всего ответов: {_count}");

                if (_count > 0)
                {
                    Console.WriteLine("\nТОП-5 ответов по вопросам:");

                    string[] topAnimal = GetTopResponses(1);
                    Console.WriteLine("\n1. Животное, связанное с Японией:");
                    for (int i = 0; i < topAnimal.Length; i++)
                    {
                        Console.WriteLine($"   {i + 1}. {topAnimal[i]}");
                    }

                    string[] topTrait = GetTopResponses(2);
                    Console.WriteLine("\n2. Черта характера японцев:");
                    for (int i = 0; i < topTrait.Length; i++)
                    {
                        Console.WriteLine($"   {i + 1}. {topTrait[i]}");
                    }

                    string[] topConcept = GetTopResponses(3);
                    Console.WriteLine("\n3. Понятие/предмет, связанный с Японией:");
                    for (int i = 0; i < topConcept.Length; i++)
                    {
                        Console.WriteLine($"   {i + 1}. {topConcept[i]}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
