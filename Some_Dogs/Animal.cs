using System.ComponentModel;

namespace SomeDogs;

public class Animal
{
    public struct Dog
    {
        private string _name;
        private int _age;
        private int _weight;
        private string _color;
        private int _hight;
        private string _sort;
        private int _sound;
        private  int _id;

        private static int _count; 
        
        
        public string Name => _name;
        public int Age => _age;
        public int Weight => _weight;
        public string Color => _color;
        public int Hight => _hight;
        public string Sort => _sort;

        public int  Id => _id;
        
        private static int Count =>  _count;
        
        public Dog(string name, int age, int weight, string color, int hight, string sort)
        {
            _name = name;
            _age = age;
            _weight = weight;
            _color = color;
            _hight = hight;
            _sort = sort;
            
            _count++;
            _id = _count;
            
        }

        public void Print()
        {
            Console.WriteLine(_name,  _age, _weight, _color, _hight, _sort);
        }

    }
    
    public struct GroupOfDogs
    {
        private Dog[] _dogs;
        public Dog[] Dogs => _dogs.ToArray();

        public void Add(Dog dog)
        {
            Array.Resize(ref _dogs, _dogs.Length + 1);
            _dogs[^1] = dog;
        }

        public void Add(Dog[] dogs)
        {
            foreach (var dog in dogs)
            {
                Add(dog);
                
            }
        }

        public Dog SearchId(int id)
        {
            foreach (var dog in _dogs)
            {
                if (dog.Id == id)
                {
                    return dog;
                }
            }

            return default;

        }

        public void Print()
        {
            foreach (var dog in _dogs)
                dog.Print();
        }


    }
}