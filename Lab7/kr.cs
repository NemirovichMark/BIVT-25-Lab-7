// ﻿namespace Lab7.Blue
// {
//     public class Task1
//     {
//     }
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Human human1 = new Human("Dima", 15);
//             Student student1 = new Student("Vova", 22, "misis");
            

//         }
//     }
//     public class Human
//     {
//         protected string _name;
//         protected int _age;
//         public Human(string name, int age)
//         {
//             _name = name;
//             _age = age;
//         }
        
//         public virtual void Print()
//         {
//             Console.WriteLine($"Human: name = {_name}, age = {_age}");
//         }

//     }
    
    
//     public class Student : Human
//     {
//         private string _uni;
//         public Student(string name, int age, string uni): base(name,age)
//         {
//             _uni = uni;
//         }
//         public override void Print()
//         {
//             Console.WriteLine($"Human: name = {_name}, age = {_age}, uni = {_uni}");
//         }
//     }

// }
