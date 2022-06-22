using System;

namespace OperatorMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OperatorMethods.Sum(1, 2));
            Console.WriteLine(OperatorMethods.Sub(1, 2));
            Console.WriteLine(OperatorMethods.Mul(5, 3));
            Console.WriteLine(OperatorMethods.Div(5, 3));
            Console.WriteLine(OperatorMethods.Mod(5, 3));
            int a = 1;
            Console.WriteLine(OperatorMethods.Increase(a));
            Console.WriteLine(OperatorMethods.Decrease(a));
            Console.WriteLine(a);
            Console.WriteLine(OperatorMethods.isSame(1, a));
        }
    }
}
