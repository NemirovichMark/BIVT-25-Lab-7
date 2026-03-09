using System.ComponentModel.Design;

namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            //fields
            private string _name;
            private string _surname;
            private int _place;

            //parameters
            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            //methods
            public void SetPlace(int place)
            {
                if (_place == 0) {_place = place;}
            }

            public void Print()
            {
                System.Console.WriteLine($"Name: {_name}, Surname: {_surname}, Place: {_place}");
            }

            //constructor
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }
        }

        public struct Team
        {
            //fields
            private string _name;
            private Sportsman[] _sportsmen;

            //parameters
            public string Name => _name;
            public Sportsman[] Sportsmen => (Sportsman[])_sportsmen.Clone();
            public int TotalScore {get { int res = 0; foreach (Sportsman man in _sportsmen) {res += Math.Clamp((man.Place - 6) * (-1), 0, 5);} return res; } }
            public int TopPlace { get { int[] places = new int[_sportsmen.Length]; for (int i = 0; i < places.Length; i++) {places[i] = _sportsmen[i].Place; } return places.Min(); } }
            
            private int _curr;

            //methods
            public void Add(Sportsman man)
            {
                if (_curr < 6)
                {
                    _sportsmen[_curr] = man;
                    _curr++;
                }
            }
            public void Add(Sportsman[] men)
            {
                foreach (Sportsman man in men) {Add(man);}
            }
            public void Print()
            {
                System.Console.WriteLine($"Name: {_name}");
            }

            public static void Sort(Team[] teams)
            {
                Array.Sort(teams, (a, b) => 
                {
                    int scorecomparsion = b.TotalScore.CompareTo(a.TotalScore);
                    if (scorecomparsion != 0) return scorecomparsion;
                    return a.TopPlace.CompareTo(b.TopPlace);
                });

            }

            //constructor
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _curr = 0;
            }
        }
    }
}