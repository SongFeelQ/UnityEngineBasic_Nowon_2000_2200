using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorMethods
{
    class OperatorMethods
    {
        static public int Sum(int a, int b)
        {
            return a + b;
        }
        static public int Sub(int a, int b)
        {
            return a - b;
        }
        static public float Mul(float a, float b)
        {
            return a * b;
        }
        // 함수 오버로딩
        // 같은 기능을 수행하는 함수의 이름을 똑같이 하면서
        // 파라미터가 다르면 동일한 이름의 함수도 여러개 정의할 수 있는 기능
        static public int Div(int a, int b)
        {
            return a / b;
        }
        static public float Div(float a, float b)
        {
            return a / b;
        }
        static public int Mod(int a, int b)
        {
            return a % b;
        }
        static public int Increase(int a)
        {
            return ++a;
        }
        static public int Decrease(int a)
        {
            return --a;
        }
        static public bool isSame(int a, int b)
        {
            return (a == b);
        }
    }
}
