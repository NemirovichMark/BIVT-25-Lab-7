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
                if (responses == null) return 0;
                int count = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (questionNumber == 1 &&
                        responses[i].Animal == _animal) count++;
                    if (questionNumber == 2 &&
                        responses[i].CharacterTrait == _characterTrait) count++;
                    if (questionNumber == 3 &&
                        responses[i].Concept == _concept) count++;
                }
                return count;
            }

            public void Print()
            {
                System.Console.WriteLine($"animal: {_animal}");
                System.Console.WriteLine($"character trait: {_characterTrait}");
                System.Console.WriteLine($"concept: {_concept}");
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses => (Response[])_responses.Clone();

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null) return;
                Array.Resize(ref _responses, _responses.Length+1);
                var response = new Response(answers[0], answers[1], answers[2]);
                _responses[^1] = response;
            }

            public string[] GetTopResponses(int question)
            {
                if (question < 1 || question > 3) return [];
                switch (question)
                {
                    case 1:
                        return _responses
                            .Select(r => r.Animal)
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .GroupBy(s => s, StringComparer.CurrentCultureIgnoreCase)
                            .OrderByDescending(g => g.Count())
                            .Take(5)
                            .Select(g => g.First())
                            .ToArray();
                    
                    case 2:
                        return _responses
                            .Select(r => r.CharacterTrait)
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .GroupBy(s => s, StringComparer.CurrentCultureIgnoreCase)
                            .OrderByDescending(g => g.Count())
                            .Take(5)
                            .Select(g => g.First())
                            .ToArray();
                    
                    case 3:
                        return _responses
                            .Select(r => r.Concept)
                            .Where(s => !string.IsNullOrWhiteSpace(s))
                            .GroupBy(s => s, StringComparer.CurrentCultureIgnoreCase)
                            .OrderByDescending(g => g.Count())
                            .Take(5)
                            .Select(g => g.First())
                            .ToArray();
                }
                return [];
            }

            public void Print()
            {
                System.Console.WriteLine($"research: {_name}");
                System.Console.WriteLine($"responses: {_responses.Length}");
            }
        }
    }
}