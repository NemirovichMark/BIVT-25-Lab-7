using System.Diagnostics;
using System.Runtime;
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
            internal string ReturnResponse(int number)
            {
                switch (number)
                {
                    case 1:
                        return this.Animal;
                    case 2:
                        return this.CharacterTrait;
                    case 3:
                        return this.Concept;
                    default:
                        return null;
                }
            }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                int SameVote = 0;
                if (this.ReturnResponse(questionNumber) != null)
                {
                    foreach (Response response in responses)
                    {
                        if(this.ReturnResponse(questionNumber).CompareTo(response.ReturnResponse(questionNumber))==0)
                            SameVote++;
                    }  
                }
                return SameVote;
            }
            public void Print()
            {
                Console.WriteLine($"{_animal}  {_characterTrait}  {_concept}");
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
                Array.Resize(ref _responses, _responses.Length+1);
                _responses[^1] = new Response(answers[0], answers[1], answers[2]);
            }
            public string[] GetTopResponses(int question)
            {
                string[] TopResponses = new string[0];
                for (int i = 0; i < _responses.Length;i++)
                {
                    for (int j = i; j>0 && _responses[j].CountVotes(_responses,question) > _responses[j-1].CountVotes(_responses,question);j--)
                    {
                        (_responses[j], _responses[j - 1]) = (_responses[j - 1], Responses[j]);
                    }
                }
                foreach(Response response in _responses)
                {
                    bool uniqe = true;
                    foreach (string answer in TopResponses)
                    {
                        if (response.ReturnResponse(question) == null || response.ReturnResponse(question).CompareTo(answer) == 0)
                            { uniqe = false; break; }
                    }
                    if (response.ReturnResponse(question) != null && uniqe && TopResponses.Length<5)
                    {
                        Array.Resize(ref TopResponses, TopResponses.Length + 1);
                        TopResponses[^1] = response.ReturnResponse(question);
                    }
                }
                return TopResponses;
            }
            public void Print()
            {

            }
        }
    }
}
