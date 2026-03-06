namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vipechka vipechka = new Vipechka(100, 1);
            vipechka.Print();
            Sochnik sochnik = new Sochnik(100, 1, 150);
            sochnik.Print();
            Vipechka vipechka2 = new Sochnik(100, 1, 50);
            vipechka2.Print();
            Vipechka[] vipechkas = new Vipechka[] { vipechka, sochnik };
            Vipechka hidesochnik = new Sochnik(100, 1, 50);
            Console.WriteLine(hidesochnik as Sochnik);
        }
    }
    public class Vipechka
    {
        protected int  _flour;
        protected int _egg;
       

        public Vipechka(int flour, int egg)
        {
            _flour = flour;
            _egg = egg;
            
        }
        public void Time()
        {
            Console.WriteLine("1 hour");
        }
        public virtual void Weight()
        {
            Console.WriteLine(_egg + _flour);
        }
        public virtual void Print()
        {
            Console.WriteLine($"My vipechka: flour {_flour} egg {_egg}");
        }
        
    }
    public class Sochnik : Vipechka
    { 
        private int _shugar;
        private int _solt;
        public Sochnik(int flour, int egg, int shugar):base(flour, egg)
        {
            _shugar = shugar;
            _solt = 10;
        }
        public override void Weight()
        {
            Console.WriteLine(_egg + _flour  + _shugar);
        }
        public override void Print() 
            {
            Console.WriteLine($"My sochnik: flour {_flour} egg {_egg} shugar {_shugar}");
            }
    }
}
