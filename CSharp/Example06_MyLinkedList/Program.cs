using System;
using System.Collections;
using System.Collections.Generic;

namespace Example06_MyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            myLinkedList.AddFirst(1);
            myLinkedList.AddFirst(2);
            myLinkedList.AddBefore(1, 3);

            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }

            foreach (var sub in myLinkedList.GetAllNodes())
            {
                Console.WriteLine(sub.value);
            }
            LinkedList<int> list = new LinkedList<int>();
            foreach (var item in list)
            {

            }

            Console.WriteLine("yield test");
            EnumeratorTest testInscance = new EnumeratorTest();
            foreach (var item in testInscance.E_GetFactorial(5))
            {
                Console.WriteLine(item);
            }
        }
    }

    public class EnumeratorTest
    {
        // FSM 
        public IEnumerator<int> E_GetFactorial(int num)
        {
            int tmpResult = 1;
            for (int i = 1; i <= num; i++)
            {
                tmpResult *= i;
                yield return tmpResult;
            }
            yield return 1;
            yield return 2;
        }

        public int GetFactorial(int num)
        {
            int tmpResult = 1;
            for (int i = 1; i <= num; i++)
            {
                tmpResult *= i;
            }
            return tmpResult;
        }
    }
}
