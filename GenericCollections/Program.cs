using System;
using System.Collections.Generic;

// Generic : 일반화
// 다양한 자료형에 대해서 유동적으로 갖다쓸수 있도록 만드는 형태
// 1 + 1 + 1 + 1 + 1
// 2 + 2 + 2 + 2 + 2
// 3 + 3 + 3 + 3 + 3
// 4 + 4 + 4 + 4 + 4
// n + n + n + n + n

namespace GenericCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 박싱 : 자료형을 객체타입으로 변환하는 과정
            // 언박싱 : 객체타입을 원래 자료형으로 변환하는 과정
            // System.Collections 를 더이상 사용하지 않는 이유는
            // 박싱은 기본형 단순 할당과정보다 20배정도 처리속도가 느리고
            // 언박싱은 4배정도 느리기 때문에 Generic을 사용할것을 권장한다.
            // ===============
            // (박싱 / 언박싱 문제 때문에 쓰지않음)
            System.Collections.ArrayList arrList = new System.Collections.ArrayList();
            arrList.Add(3);
            arrList.Add("철수");
            arrList.Add('A');
            

            // List
            List<int> list_int = new List<int>(); // List를 int 형태로 만듬
            List<float> list_float = new List<float>(); // List를 flaot 형태로 만듬
            List<List<int>> list_list_int = new List<List<int>>(); // List 안에 List를 int 형태로 만듬
            // 추가
            list_int.Add(0);
            list_float.Add(1.0f);
            list_list_int.Add(list_int);
            list_list_int.Add(new List<int>());
            // 삭제
            list_int.Remove(0);
            list_list_int.RemoveAt(1);
            // 검색
            //list_int.Find(x => x == 0);
            list_int.Contains(0);

            for (int i = 0; i < list_int.Count; i++)
            {

            }

            // LinkedList
            // 단방향 : Singly linkedList / 양방향 : Doubly linkedList
            // C#에서 제공하는 LinkedList는 양방향. Node 간 서로간의 정보를 가지고 있다.
            LinkedList<int> linkedList = new LinkedList<int>();

            // 추가 : 첫번째나 마지막 노드로 추가한 뒤, 링크를 추가
            // AddFirst() : 첫번째 노드에 추가
            // AddLast() : 마지막 노드에 추가
            linkedList.AddLast(0);
            linkedList.AddFirst(1);

            // 삽입 : 노드와 노드 사이에 추가한 뒤, 링크를 수정
            // AddBefore() : 이전 노드에 추가
            // AddAfter() : 다음 노드에 추가
            linkedList.AddBefore(linkedList.Find(0), 3);
            Console.WriteLine(linkedList.First);

            // 탐색 : 첫 노드(혹은 마지막 노드) 부터 하나씩 확인하여 탐색함.
            // Find() : 첫번째 노드부터 탐색
            // FindLast() : 마지막 노드부터 탐색
            // Contains() : 

            // 삭제 : 노드를 삭제한 뒤, 삭제한 노드의 전 후 노드의 링크를 수정.
            // Remove(value) : 해당 value 값을 지니고 있는 노드를 탐색 후 해당 노드를 삭제
            // Remove(Node) : 해당 노드를 선택해서 삭제
            // RemoveFirst() : 
            // RemoveLast() : 
            linkedList.RemoveLast();

            // ==========
            // Hash : 고유 Key값
            // Hash함수 : Hash를 뽑아내는 함수
            // 문자열 키값으로 해시를 뽑아내는 해시함수 구현 방식
            // 1. 입력 문자열의 각 문자의 정수형태로 전부 더한다.
            //  (부가적으로 충돌을 줄이기 위해서 자릿수를 곱하거나 자릿수의 승수를 곱하는 등의 연산을 추가할 수 있다)
            // 2. 1의 값에 해시테이블 크기로 모듈러연산을 한다.
            // 3. 2의 결과를 해시로 반환한다.
            // 적당한 크기와 적당한 충돌빈도가 있는 해시함수가 이상적인 함수다. 구조적으로 충돌이 일어날수밖에 없기때문.
            // 충돌 빈도를 줄이는 방법
                // 1. 체이닝
                // hash 충돌이 일어난 value들을 linkedList 형태로 관리하는 방법.
                // 해당 value들을 Buket이라는 단위로 관리한다.
                // 2. 오픈어드레싱
                // Linear probing : n번째 중복될경우 +n만큼의 Key값에 할당한다.
                // Quadratic Probing : n번째 중복될 경우 n의 제곱을 더한 Key값에 할당한다. 
            // ==========

            // Hashtable (박싱 / 언박싱 문제 때문에 쓰지않음)
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("철수", 90);

            // Dictionary : Generic 타입의 Hashtable을 사용한다.
            Dictionary<string, char> grades = new Dictionary<string, char>();
            // 추가
            grades.Add("철수", 'A');
            grades.Add("영희", 'B');
            if (grades.TryAdd("영희", 'C'))
            {
                Console.WriteLine("영희 점수 C 추가");
            }
            else
            {
                Console.WriteLine($"영희 점수 이미 있음 : {grades["영희"]}");
            }

            foreach (var sub in grades)
            {
                Console.WriteLine(sub.Key);
                Console.WriteLine(sub.Value);
            }

            foreach (var sub in grades.Keys)
            {
                Console.WriteLine(sub);
                Console.WriteLine(grades[sub]);
            }

            //foreach (var sub in grades.Values)
            // 불가능한것은 아니지만, 사전에서 설명으로 단어를 찾는것처럼 비효율적이다.


            // 삭제
            grades.Remove("철수");

            //
            if (grades.ContainsKey("영희"))
            {
                Console.WriteLine("영희 점수 있음");
            }
            if (grades.TryGetValue("영희", out char grade))
            {
                Console.WriteLine(grade);
            }

            // Queue
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1); // queue 제일 뒤에 아이템 추가
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue(); // 제일 앞에 있는 아이템 반환 빛 제거
            Console.WriteLine(queue.Dequeue());
            queue.Peek(); // 제일 앞에 있는 아이템 반환
            queue.TryPeek(out int peek);

            // Stack
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1); // 가장 마지막에 아이템 추가
            stack.Pop(); // 가장 마지막에 추가된 아이템 제거 및 반환
            stack.Peek(); // 가장 마지막에 추가된 아이템 반환
            stack.TryPop(out int result);
        }
    }
}
