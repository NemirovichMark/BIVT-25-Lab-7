using Task_dogs;
using static Task_dogs.Dogs;

class Test
{
    public static void Main()
    {
    Dog d1 = new Dog(name: "Princes of pancakes", 12, "brown", 28.5, 60.3, "down");
    Dog d2= new Dog(name:"Death",9,"white",20.67,53.8,"down");
    Dog d3= new Dog(name:"Alex",11,"black",23.4,55.7,"up"); 
    d1.Print(); d2.Print(); d3.Print();
    Dog[] dogs = {d1,d2,d3};
    Dog.Sort(dogs);

    

    
    }
    
}