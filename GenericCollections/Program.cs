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

            // LinkedList
            // 단방향 : Singly linkedlist / 양방향 : Doubly linkedlist
            // C#에서 제공하는 LinkedList는 양방향. Node 간 서로간의 정보를 가지고 있다.
            LinkedList<int> linkedlist = new LinkedList<int>();

            // 추가 : 첫번째나 마지막 노드로 추가한 뒤, 링크를 추가
            // AddFirst() : 첫번째 노드에 추가
            // AddLast() : 마지막 노드에 추가
            linkedlist.AddLast(0);
            linkedlist.AddFirst(1);

            // 삽입 : 노드와 노드 사이에 추가한 뒤, 링크를 수정
            // AddBefore() : 이전 노드에 추가
            // AddAfter() : 다음 노드에 추가
            linkedlist.AddBefore(linkedlist.Find(0), 3);
            Console.WriteLine(linkedlist.First);

            // 탐색 : 첫 노드(혹은 마지막 노드) 부터 하나씩 확인하여 탐색함.
            // Find() : 첫번째 노드부터 탐색
            // FindLast() : 마지막 노드부터 탐색
            // Contains() : 

            // 삭제 : 노드를 삭제한 뒤, 삭제한 노드의 전 후 노드의 링크를 수정.
            // Remove(value) : 해당 value 값을 지니고 있는 노드를 탐색 후 해당 노드를 삭제
            // Remove(Node) : 해당 노드를 선택해서 삭제
            // RemoveFirst() : 
            // RemoveLast() : 
            linkedlist.RemoveLast();

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
                // hash 충돌이 일어난 value들을 linkedlist 형태로 관리하는 방법.
                // 2. 오픈어드레싱
                // Linear probing : n번째 중복될경우 +n만큼의 Key값에 할당한다.
                // Quadratic Probing : n번째 중복될 경우 n의 제곱을 더한 Key값에 할당한다. 
            // ==========
            // Dictionary : Generic 타입의 Hashtable을 사용한다.


            // Queue

            // Stack
        }
    }
}
