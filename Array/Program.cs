using System;

namespace Array
{
    internal class Program
    {
        // array
        // 형태 : 자료형[]
        // 자료형이 정적으로 나열되어있는 형태, 한번 크기를 정하면 바꿀 수 없다.
        static void Main(string[] args)
        {
            int[] arrInt = new int[3];
            int[] arrInt2 = { 1, 2, 3 };
            Console.WriteLine("Hello World!");
            arrInt = new int[5]; // arrInt의 크기를 바꾼것이 아니라, 새로 만들고 기존것을 해지한 것.
            float[] arrFloat = new float[4];

            // 배열의 인덱스 접근
            // 배열변수이름[인덱스숫자]
            // : 배열의 가장 첫번째 주소로부터 인덱스숫자 * 배열의 요소의 자료형 크기만큼
            // 뒤에 있는 배열 요소에 접근
            arrInt[0] = 1;
            arrInt[1] = 2;
            arrInt[2] = 3;
            // arrInt = 3; (x) : int[] 자체가 배열로 선언되었기 때문에 불가능하다. 
            Console.WriteLine(arrInt[0]);
            Console.WriteLine(arrInt[1]);
            Console.WriteLine(arrInt[2]);

            string[] arrString = new string[3];
            arrString[0] = "김아무개";
            arrString[1] = "이아무개";
            arrString[2] = "박아무개";
            Console.WriteLine(arrString[0]);
            Console.WriteLine(arrString[1]);
            Console.WriteLine(arrString[2]);

            char[] arrChar = { 'a', 'n', 'd' };
            String tmpString = new String(arrChar);
            Console.WriteLine(tmpString);
            string tmpString2 = "Luke"; 
            Console.WriteLine(tmpString2[0]);
            // string이 배열은 아니다. 배열로 인덱스 접근은 가능하지만, 배열은 아니다.
        } 
    }
}
