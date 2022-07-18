using System;

namespace ConditionStatements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool condition1 = false;
            bool condition2 = false;
            bool condition3 = true;
            
            if (condition1) // (조건)
            {
                // 조건 1이 참일 때 실행할 내용
                Console.WriteLine("조건 1을 참이다");
            }
            else if (condition2)
            {
                // 조건 2가 참일 때 실행할 내용
                Console.WriteLine("조건 1은 거짓이고, 조건 2는 참이다");
            }
            else if (condition3)
            {
                // 조건 3이 참일 때 실행할 내용
                Console.WriteLine("조건 1,2는 거짓이고, 조건 3는 참이다");
            }
        }
    }
}
