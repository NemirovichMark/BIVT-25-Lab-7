namespace Lab7.Blue
{
    public class Task1
    { public struct Response
        {
            // приватные поля только мои никто не трогает 
            private string _name;
            private string _surname;
            private int _votes;

            private int VotesCounter
            {
                set
                {
                    _votes = value; //когда пытаемся записать голос то он передается но его изменить нельзя тк только сет нету гет 
                    //в почтовый ящик (_votes) кладут письмо (например 5 или VALUE) и set его забирает
                }
            }
            //свойства приват в публик
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;
        
            //конструктор что делает 
            public Response (string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0; //голосов нет пока что 
            }

            public int CountVotes(Response[] responses)
            {
                if (responses.Length == 0 || responses == null) return 0;
                int count = 0;

                foreach (var response in responses) //коробка с яблоками, первое это задаем переменную для яблока и перебираем в коробке 
                {
                    if (response.Name == _name && response.Surname == _surname) count++;
                }

                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == _name && responses[i].Surname == _surname) responses[i].VotesCounter = count;
                }

                return count;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Votes}");
            }
        }
    }
}
