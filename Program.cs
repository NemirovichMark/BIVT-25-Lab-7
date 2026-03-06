namespace _03._03._26.практика
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sport sport1 = new Sport("defoult", 160);
            Formula Formulaone = new Formula("Germany", 76, "Great Britain");

            // Sport sport2 = new Sport(..) Yes
            // Formula Formulatwo = new Formula(..) No
            Sport hiddenFormula = new Formula("France", 75, "Great Britain");
            hiddenFormula.Simple();
            hiddenFormula.Print();

            //sport1.Simple();
            //sport1.Print();   

            //Formulaone.Simple();
            //Formulaone.Print();

            Sport[] all = new Sport[] { sport1, Formulaone, hiddenFormula };
            // в этом массиве хранятся объекты класса или структуры 
            for (int i = 0;i < all.Length; i++)
            {
                if (all[i] is Formula)
                {
                    Formula s = all[i] as Formula; // s приводит объект к тому типу, к которому привели
                }
            }
        }

    }
    public class Sport // угадай спорт по месту проведения, его возрасту и стране зарождения спорта
    {
        // поля
        protected string _place;// где проводится? страна
        protected int _age; // сколько лет спорту?


        // конструктор
        public Sport(string place, int age)
        {
            _place = place;
            _age = age;
        }
        public void Simple()
        {
            Console.WriteLine("Sport method");
        }
        public virtual void Print()
        {
            Console.WriteLine($"Sport: place = {_place},age = {_age}");
        }

    }
    public class Formula : Sport // наследник

    {

        private string _countryborn; // страна зарождения спорта
        // конструктор
        public Formula(string place, int age, string countryborn) : base(place, age) // помогает избегать дублирования кода
        {

            _countryborn = countryborn;
        }
        public  new void Simple()
        {
            Console.WriteLine("Formula method");
        }
        public  override void Print() // Переопределение метода
        {
            Console.WriteLine($"Formula: place = {_place},age = {_age}, countryborn = { _countryborn}");
        }



    }
}
