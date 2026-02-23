namespace SomeDogs;

class Program
{
    static void Main(string[] args)
    {
        Animal.Dog first = new Animal.Dog("A", 10, 10, "Orange", 9,"Haski");
        Animal.Dog second = new Animal.Dog("B", 10, 10, "Grew", 9,"Pudel");
        Animal.Dog third = new Animal.Dog("C", 10, 10, "Grew", 9,"Some");
        Animal.Dog fourth = new Animal.Dog("D", 10, 10, "Grew", 9,"Some");
        Animal.Dog five = new Animal.Dog("E", 10, 10, "Black", 7,"Taksa");
        Animal.Dog six = new Animal.Dog("F", 10, 10, "White", 9,"Pudel");
    }
}
