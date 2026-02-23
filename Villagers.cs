namespace ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public struct Villager
        {
            public enum Color
            {
                DarkGray = 1,
                LightGray = 2,
                Orange = 3,
                Black = 4,
                Green = 5
            }
            private string _name;
            private string _sex;
            private int _age;
            private bool _hasHat;
            private string _haircut;
            private Color _hairColor;
            private string _personalItem;
            private string _boots;
            private string _clothes;

            public string Name => _name;
            public string Sex => _sex;
            public int Age => _age;
            public bool HasHat => _hasHat;
            public string Haircut => _haircut;
            public Color HairColor => _hairColor;
            public string PersonalItem => _personalItem;
            public string Boots => _boots;
            public string Clothes => _clothes;

            public Villager(string name, string sex, int age, bool hasHat, string haircut, Color hairColor, string personalItem, string boots, string clothes)
            {
                _name = name;
                _sex = sex;
                _age = age;
                _hasHat = hasHat;
                _haircut = haircut;
                _hairColor = hairColor;
                _personalItem = personalItem;
                _boots = boots;
                _clothes = clothes;
            }
        }

        public struct Village
        {
            private string _name;
            private Villager[] _villagers;

            public string Name => _name;
            public Villager[] Villagers => _villagers;

            public Village(string name)
            {
                _name = name;
                _villagers = new Villager[0];
                var villagers = new Villager[]
                {
                    new Villager("Georgy", "Male", 54, true, "Long hair with beard", Villager.Color.DarkGray, "Bag", "Brown boots", "Blue mantia"),
                    // new Villager(default(Villager)),
                    // new Villager(default(Villager)),
                    // new Villager(default(Villager)),
                    // new Villager(default(Villager)),
                    // new Villager(default(Villager)),
                    // new Villager(default(Villager)),
                    // new Villager(default(Villager)),
                };
                AddVillager(villagers);

            }

            public void AddVillager(Villager villager)
            {
                if (villager == null) return;
                Array.Resize(ref _villagers, _villagers.Length+1);
                _villagers[^1] = villager;
            }
            public void AddVillager(Villager[] villagers)
            {
                foreach(Villager villager in villagers)
                {
                    AddVillager(villager);
                }
            }
        }
    }
}
