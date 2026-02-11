namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team(string name)
        {
            readonly string name = name;
            public readonly string Name => this.name;
            public readonly string Scores => null;

            public readonly int TotalScore => 0;

            public void PlayMatch(int result)
            {

            }

            public readonly void Print() => Console.WriteLine(this.ToString()); // 0 refs -- метод такой типа: "Я никому не ужин"

            override public readonly string ToString() =>
                $"Team{{Name: \"{this.name}\", Scores: \"{this.Scores}\", TotalScore: {this.TotalScore}}}";
        }

        public struct Group
        {

        }
    }
}