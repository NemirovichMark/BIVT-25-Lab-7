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
                int cnt = 0;
                switch (questionNumber)
                {
                    case 1:
                        {
                            foreach (var res in responses)
                            {
                                if (_animal == res.Animal) cnt++;
                            }
                            break;
                        }
                    case 2:
                        {
                            foreach (var res in responses)
                            {
                                if (_characterTrait == res.CharacterTrait) cnt++;
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach (var res in responses)
                            {
                                if (_concept == res.Concept) cnt++;
                            }
                            break;
                        }
                }

                return cnt;
            }
            public void Print()
            {
                Console.WriteLine($"animal: {_animal}, character trait: {_characterTrait}, concept: {_concept}");
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
                Response r = new Response(answers[0], answers[1], answers[2]);
                if (answers == null || answers.Length != 3) return;
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = r;
            }
            public string[] GetTopResponses(int question)
            {
                if (_responses == null || _responses.Length == 0) return new string[0];
                string[] all_ans = new string[_responses.Length];
                switch (question)
                {
                    case 1:
                        for (int i = 0; i < _responses.Length; i++)
                        {
                            all_ans[i] = _responses[i].Animal;
                        }
                        break;
                    case 2:
                        for (int i = 0; i < _responses.Length; i++)
                        {
                            all_ans[i] = _responses[i].CharacterTrait;
                        }
                        break;
                    case 3:
                        for (int i = 0; i < _responses.Length; i++)
                        {
                            all_ans[i] = _responses[i].Concept;
                        }
                        break;
                }
                string[] no_repeat = all_ans.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();

                int n = no_repeat.Length;
                int[] reps = new int[n];
                int k = 0;
                foreach (string s in no_repeat)
                {
                    reps[k++] = all_ans.Count(w => w == s);
                }
                for (int i = 0; i < n-1; i++)
                {
                    for (int j = 0; j < n-1-i; j++)
                    {
                        if (reps[j+1] > reps[j])
                        {
                            (no_repeat[j + 1], no_repeat[j]) = (no_repeat[j], no_repeat[j + 1]);
                            (reps[j + 1], reps[j]) = (reps[j], reps[j + 1]);

                        }
                    }
                }
                int size = Math.Min(5, n);
                string[] res = new string[size];
                Array.Copy(no_repeat, res, size);
                return res;

            }
            public void Print()
            {
                Console.WriteLine($"name: {_name}");
                foreach (var s in _responses)
                {
                    s.Print();
                }
            }
            
            
        }
    }
}
