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

            public int CountVotes(Response[] responses, int questionNumber)
            {

                return 0;
            }

            public Response(string Animal, string CharacterTrait, string Concept)
            {
                if(string.IsNullOrWhiteSpace(Animal) || string.IsNullOrWhiteSpace(CharacterTrait) || string.IsNullOrWhiteSpace(Concept))
                _animal = Animal;
                _characterTrait = CharacterTrait;
                _concept = Concept;
            }


            public void Print()
            {
                Console.WriteLine("");
            }
        }
    }
}