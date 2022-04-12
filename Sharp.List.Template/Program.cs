using System;

namespace Sharp.List.Template
{

    class Program
    {

        static void Main(string[] args)
        {

            List<int> list = new List<int>();

            for (int i = 0; i < 15; i++)
                list.Add(i, i);


            Console.WriteLine("Before");
            list.Print();

            list.SwapFirstWithLast();

            Console.WriteLine("After");
            list.Print();


        }
    
    }

}
