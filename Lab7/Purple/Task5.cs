using System.Runtime;
using System.Xml.Linq;

namespace Lab7.Purple
{
    public class Task5
    {
        public struct Response
        {
            private string _animal; private string _trait;
            private string _concept;
            public string Animal => _animal; public string CharacterTrait => _trait;
            public string Concept => _concept;
            public Response(string animal, string trait, string concept)
            {
                _animal = animal;
                _trait = trait;
                _concept = concept;
            }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                int k = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (questionNumber == 1)
                    {
                        if (_animal == responses[i].Animal) k++;
                    }
                    if (questionNumber == 2)
                    {
                        if (_trait == responses[i].CharacterTrait) k++;
                    }
                    if (questionNumber == 3)
                    {
                        if (_concept == responses[i].Concept) k++;
                    }
                }
                return k;
            }
            public void Print()
            { Console.Write($"Animal: {Animal}\nCharacterTrait: {CharacterTrait}\nConcept: {Concept}\n\n"); }
        }
        public struct Research
        {
            private string _name; private Response[] _responses;
            public string Name => _name; public Response[] Responses => (Response[])_responses.Clone();
            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }
            public void Add(string[] answers)
            {
                Array.Resize(ref _responses, _responses.Length + 1);
                var response= new Response(answers[0], answers[1], answers[2]);
                _responses[^1] = response;
            }
            public string[] GetTopResponses(int question)
            {
                string[] result = new string[0];
                if (question == 1)
                {
                    string[] mas1 = new string[0];
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Animal != null)
                        { Array.Resize(ref mas1, mas1.Length + 1);
                            mas1[^1] = _responses[i].Animal; }
                    }
                    int[] ints = new int[0]; string[] an = new string[0];
                    for (int i = 0; i < mas1.Length; i++)
                    {
                        string a = mas1[i]; int v = 0;
                        if (A(a, an))
                        {
                            for (int j = 0; j < mas1.Length; j++)
                                if (mas1[j] == a)
                                    v++;
                            Array.Resize(ref ints, ints.Length + 1); ints[^1] = v;
                            Array.Resize(ref an, an.Length + 1); an[^1] = a;
                        }
                    }
                    result = new string[5];
                    Sort(ints, an);
                    if (an.Length >= 5)
                    {
                        for (int i = 0; i < 5; i++)
                            result[i] = an[i];
                    }
                    else result = an;
                }
                if (question == 2)
                {
                    string[] mas1 = new string[0];
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].CharacterTrait != null)
                        {
                            Array.Resize(ref mas1, mas1.Length + 1);
                            mas1[^1] = _responses[i].CharacterTrait;
                        }
                    }
                    int[] ints = new int[0]; string[] an = new string[0];
                    for (int i = 0; i < mas1.Length; i++)
                    {
                        string a = mas1[i]; int v = 0;
                        if (A(a, an))
                        {
                            for (int j = 0; j < mas1.Length; j++)
                                if (mas1[j] == a)
                                    v++;
                            Array.Resize(ref ints, ints.Length + 1); ints[^1] = v;
                            Array.Resize(ref an, an.Length + 1); an[^1] = a;
                        }
                    }
                    result = new string[5];
                    Sort(ints, an);
                    if (an.Length >= 5)
                    {
                        for (int i = 0; i < 5; i++)
                            result[i] = an[i];
                    }
                    else result = an;
                }
                if (question == 3)
                {
                    string[] mas1 = new string[0];
                    for (int i = 0; i < _responses.Length; i++)
                    {
                        if (_responses[i].Concept != null)
                        {
                            Array.Resize(ref mas1, mas1.Length + 1);
                            mas1[^1] = _responses[i].Concept;
                        }
                    }
                    int[] ints = new int[0]; string[] an = new string[0];
                    for (int i = 0; i < mas1.Length; i++)
                    {
                        string a = mas1[i]; int v = 0;
                        if (A(a, an))
                        {
                            for (int j = 0; j < mas1.Length; j++)
                                if (mas1[j] == a)
                                    v++;
                            Array.Resize(ref ints, ints.Length + 1); ints[^1] = v;
                            Array.Resize(ref an, an.Length + 1); an[^1] = a;
                        }
                    }
                    result = new string[5];
                    Sort(ints, an);
                    if (an.Length >= 5)
                    {
                        for (int i = 0; i < 5; i++)
                            result[i] = an[i];
                    }
                    else result = an;              
                }
                return result;
            }
            private bool A(string a, string[] an)
            {   
                for (int i=0;i<an.Length;i++)
                    if (a == an[i])
                        return false; 
                return true;
            }
            private static void Sort(int[] ints, string[] an)
            {
                for (int i = 0; i < ints.Length - 1; i++)
                    for (int j = 0; j < ints.Length - i - 1; j++)
                        if (ints[j] < ints[j + 1])
                        {
                            (ints[j], ints[j + 1]) = (ints[j + 1], ints[j]);
                            (an[j], an[j + 1]) = (an[j + 1], an[j]);
                        }
            }
            public void Print()
            { Console.Write($"Name: {_name}\nResponses: {_responses}\n\n"); }
        }
    }
}
