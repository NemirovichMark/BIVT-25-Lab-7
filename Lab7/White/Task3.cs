using System.Collections;
using System.Xml.Linq;

namespace Lab7.White
{
    public class Task3
    {
        public struct Student
        {
            //поля
            private string _name;
            private string _surname;
            private int _skipped;
            private int[] _marks;

            //свойства
            //public string Name => _name;
            //public string Surname => _surname;
            //public int Skipped=>_skipped;
            public string Name 
            { 
                get
                {
                    return _name; 
                } 
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }
            public int Skipped
            {
                get
                {
                    return _skipped;
                }
            }
            //public int[] Marks
            //{
            //    get
            //    {
            //        if (_marks == null) return null ;
            //        int[] copy=new int[_marks.Length];
            //        for (int i = 0; i < copy.Length; i++)
            //        {
            //            copy[i] = _marks[i];
            //        }
            //        return copy;

            //    }


            //}
            //public int[] Marks => _marks.ToArray();
            public double AverageMark
            {
                get
                {
                    if(_marks == null || _marks.Length==0)
                        return 0;
                    double average = 0;
                    for(int i=0; i< _marks.Length; i++)
                    {
                        average += _marks[i];
                    }
                    average= average / _marks.Length;
                    return average;
                }
            }
            //конструктор
            public Student(string name,string surname)
            {
                _name=name;
                _surname=surname;
                //_skipped = 0;              
                //_marks = new int[0];
            }
            //метод
            public void Lesson(int mark)
            {
                if(mark == 0)
                {
                    _skipped++;
                }
                else
                {
                    //если массив не сущ создаем пустой
                    if (_marks == null)
                        _marks = new int[0];

                    Array.Resize(ref _marks, _marks.Length+1);
                    _marks[_marks.Length-1] = mark;
                }
                
            }
            public static void SortBySkipped(Student[] array)
            {
                if(array == null|| array.Length==0)
                    return;
                for(int i =0; i < array.Length; i++)
                {
                    for(int j = 1;j<array.Length;j++)
                    {
                        if (array[j - 1].Skipped < array[j].Skipped)
                        {
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine(_name);
                Console.WriteLine(_surname);
                Console.WriteLine(_skipped);
                Console.WriteLine(_marks);
                Console.WriteLine(AverageMark);
            }

        }



    }
}
