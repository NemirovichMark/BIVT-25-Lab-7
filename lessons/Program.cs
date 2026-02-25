using System;
namespace Task_dogs;


public class Dogs
{
    

    public struct Dog
    {
        // <-----поля----->

        private string _name;
        private string _ears;
        private int _age;
        private double _weight;
        private double _height;
        private string _color;
        private static int _nextId = 0;
        private  int _id;

        // <-----методы гет----->

        public string Name=>_name;
        public int Age=>_age;
        public double Weight=>_weight;
        public double Height=>_height;
        public string Color=>_color;
        public string Ears=>_ears;
        public Dog(string name,int age, string color, double weight,double height, string ears)
    {
        _name=name;
        _age=age;
        _color=color;
        _weight=weight;
        _height=height;
        _ears=ears;
         _id = _nextId++;
    }
        public static Dog[] Sort(Dog[] dogs)
{
    Console.WriteLine("Введите поле для сортировки (Name, Age, Weight, Height, Color, Ears): ");
    string field = Console.ReadLine();

    Dog[] sortedDogs;

    switch (field)
    {
        case "Name":    sortedDogs = dogs.OrderBy(d => d.Name).ToArray(); break;
        case "Age":     sortedDogs = dogs.OrderBy(d => d.Age).ToArray(); break;
        case "Weight":  sortedDogs = dogs.OrderBy(d => d.Weight).ToArray(); break;
        case "Height":  sortedDogs = dogs.OrderBy(d => d.Height).ToArray(); break;
        case "Color":   sortedDogs = dogs.OrderBy(d => d.Color).ToArray(); break;
        case "Ears":    sortedDogs = dogs.OrderBy(d => d.Ears).ToArray(); break;
        default:
            Console.WriteLine("Неизвестное поле, сортировка по умолчанию (Name)");
            sortedDogs = dogs.OrderBy(d => d.Name).ToArray();
            break;
    }

    
    Console.WriteLine("\nОтсортированный список:");
    foreach (var dog in sortedDogs)
    {
        dog.Print();  
    }

    return sortedDogs; 
    }
        public void Print()
        {
            Console.WriteLine($"Name: {_name} \nAge: {_age} \nColor: {_color}"+ 
             $"\nWeight: {_weight} \nHeight: {_height} \nEars: {_ears} \nID: {_id}\n---------------");
        }
        
    }



}

