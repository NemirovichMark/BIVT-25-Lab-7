namespace ConsoleApp7
{


    public class Robot
    {
        private string _name;
        private int _age;
        private string _surname;
        private static int _id;
        private static int _count;
        private string _version;


        public string Name=> _name;

        public int Age => _age;
        public string Surname => _surname;
        public string Version => _version;
        public static int Id => _id;
        public Robot(string name, int age, string surname, string version)
        {
            _name = name;
            _age = age;
            _surname = surname;
            _version = version;
            _count++;
            _id = _count;
        }
        public virtual void Method()
        {
            Console.WriteLine("Метод класса Robot");
            
        }
        public void Print()
        { 
            Console.WriteLine($"Привет, я робот по имени {Name} и мне {Age} лет. Моя фамилия {Surname} и моя версия {Version}. Мой ID: {Id}");
            
        }
    }


    
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot Egor = new Robot("Egor", 18, "Serov", "1.0");
            Console.WriteLine($"{Egor.Version}");
            Egor.Print();
            WarRobot WarAnatAli = new WarRobot("Tolik", 20, "Ybivashka", "2.0", "AK-47", "Heavy", "High agressive",false);
            Egor.Method();
            WarAnatAli.Print();
            WarAnatAli.Method();

        }


    }
    public class WarRobot : Robot
    {
        private string _weapon;
        private string _agressive;
        private string _armor;
        private bool _isValid;

        public string Weapon => _weapon;
        public string Agressive => _agressive;
        public string Armor => _armor;

        public WarRobot(string name, int age, string surname, string version, string weapon,string armor, string agressive) : base(name, age, surname, version)   
        {
            _weapon = weapon;
            _agressive = agressive;
            _armor = armor;
            _isValid = true;
            

        }
        public WarRobot(string name, int age, string surname, string version, string weapon, string armor,string agressive,bool isValid) : this (name, age, surname, version, weapon, armor, agressive)
        {
            _isValid = isValid;
        }
        public override void Method()
        {
            Console.WriteLine("Метод класса WarRobot");
             
        }
    }
}
