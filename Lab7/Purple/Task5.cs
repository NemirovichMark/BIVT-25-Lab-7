using System.Collections.Immutable;
using System.Runtime;
using System.Xml.Linq;

namespace Lab7.Purple
{
  public class Task5
  {
    public struct Response
    {
      // Поля
      private string _animal;
      private string _characterTrait;
      private string _concept;

      // Свойства
      public string Animal => _animal;
      public string CharacterTrait => _characterTrait;
      public string Concept => _concept;

      // Методы
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
          if ((questionNumber == 1) && (responses[i].Animal != null))
            count++;
          else if ((questionNumber == 2) && (responses[i].CharacterTrait != null))
            count++;
          else if ((questionNumber == 3) && (responses[i].Concept != null))
            count++;
        }
        return count;
      }
      public void Print()
      {
        Console.Write($"Animal:{_animal}  CharacterTrait:{_characterTrait}  Concept:{_concept}");
      }
    }
    public struct Research
    {
      // Поля
      private string _name;
      private Response[] _responses;

      // Свойства
      public string Name => _name;
      public Response[] Responses => _responses;

      // Методы
      public Research(string name)
      {
        _name = name;
        _responses = new Response[0];
      }
      public void Add(string[] answers)
      {
        Array.Resize(ref _responses, _responses.Length + 1);
        _responses[_responses.Length - 1] = new Response(answers[0], answers[1], answers[2]);
      }
      public string[] GetTopResponses(int question)
      {
        Dictionary<string, int> question1 = new Dictionary<string, int>();
        Dictionary<string, int> question2 = new Dictionary<string, int>();
        Dictionary<string, int> question3 = new Dictionary<string, int>();
        for (int i = 0; i < _responses.Length; i++)
        {
          if ((_responses[i].Animal != null) && (!question1.ContainsKey(_responses[i].Animal)))
            question1[_responses[i].Animal] = 1;
          else if (_responses[i].Animal != null)
            question1[_responses[i].Animal]++;
        }
        for (int i = 0; i < _responses.Length; i++)
        {
          if ((_responses[i].CharacterTrait != null) && (!question2.ContainsKey(_responses[i].CharacterTrait)))
            question2[_responses[i].CharacterTrait] = 1;
          else if (_responses[i].CharacterTrait != null)
            question2[_responses[i].CharacterTrait]++;
        }
        for (int i = 0; i < _responses.Length; i++)
        {
          if ((_responses[i].Concept != null) && (!question3.ContainsKey(_responses[i].Concept)))
            question3[_responses[i].Concept] = 1;
          else if (_responses[i].Concept != null)
            question3[_responses[i].Concept]++;
        }
        question1 = question1.OrderByDescending(q => q.Value).ToDictionary<string, int>();
        question2 = question2.OrderByDescending(q => q.Value).ToDictionary<string, int>();
        question3 = question3.OrderByDescending(q => q.Value).ToDictionary<string, int>();

        Dictionary<string, int> q = new Dictionary<string, int>();
        if (question == 1) q = question1;
        else if (question == 2) q = question2;
        else if (question == 3) q = question3;
        string[] answer = new string[Math.Min(5, q.Count)];

        int count = 0;
        foreach (var i in q)
        {
          answer[count++] = i.Key;
          if (count == 5) break;
        }
        return answer;
      }
      public void Print()
      {
        Console.Write($"Name:{_name}  \nResponses:");
        for (int i = 0; i < _responses.Length; i++)
          Console.Write(_responses[i] + " ");
        Console.WriteLine();
      }
    }
  }
}
