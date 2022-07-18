/*  파란 글자는 키워드
    미리 정의되어 있는 단어
    이미 문법 용도로 사용되고 있기 때문에 식별용으로 개발자가 쓸 수 없다.

    흰 글자는 식별문자(이름). 
    참조가 있는 명시적 표현이 흰 글자로 나타난다.

    청록색 글자는 클래스 타입 식별문자.

    노란색 글자는 함수 식별문자.

    하늘색 글자는 함수의 파라미터(매개변수)의 식별문자

    주황색 글자는 문자열 상수.

    참조가 없어서 생략 가능한 암시적 표현은 어두운 글자로 나타난다.
 */

/*  using 키워드
    특정 namespace를 사용하기 위한 키워드.
    형식) using namespace이름
 */
using System;

/*  namespace 키워드
    공간을 구분하기 위한 키워드.
    내부 식별자를 가지고 namespace로 묶인 변수, 함수, 클래스, 인터페이스 등을 구분함.
 */
namespace FirstProject // Note: actual namespace depends on the project name.
{
    /*  internal 키워드
        동일 어셈블리에서만 접근 가능한 키워드.

        class 키워드
        객체를 만들기 위한 타입을 정의하는 키워드.
     */
    internal class Program
    {
        /*  static 키워드
	        정적 키워드, 메모리에 동적 할당이 불가능한 속성을 부여함.
	
	        void 키워드
	        아무것도 없음. (반환값이 없음)
	
	        Main 함수
	        실행파일(.exe)을 실행했을 때 가장 먼저 실행되는 함수
         */
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
        }
    }
}