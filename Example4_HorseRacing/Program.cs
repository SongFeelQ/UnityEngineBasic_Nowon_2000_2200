using System;
using System.Threading;

// - 진행방식 -
//
// 프로그램 시작시
// 말 다섯마리를 만들고
// 각 다섯마리는 초당 10~20 (정수형) 범위 거리를 랜덤하게 움직임
// 각각의 말이 거리 200 에 도달하면 말의 이름과 등수를 출력해줌
   
// 말은
// 이름, 달린거리 를 멤버변수로
// 달리기 를 멤버 함수로 가짐.
// 달리기 멤버함수는 입력받은 거리를 달린거리에 더해주어서 달린거리를 누적시키는 역할을 함.
   
// 매초 달릴 때 마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌.
// 경주가 끝나면 1,2,3,4,5 등 말의 이름을 등수 순서대로 콘솔창에 출력해줌.
   
// - Hint -
   
//- System.Threading namespace 에 있는 Thread.Sleep(1000); 를 사용하면 현재 프로그램을 1초 지연시킬수 있음
// While 반복문에서 Thread.Sleep(1000); 을 추가하면 1초에 한번씩 반복문을 실행함.
//- 말들이 동시에 들어오는 경우에 대해서는 그냥 말 이름 순으로 등수 책정



namespace Example4_HorseRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int StartPoint = 0;
            int minSpeed = 10;
            int maxSpeed = 20;
            Random random = new Random();
            const int FinishPoint = 200;
            bool gameFinished = false;

            // 말 다섯마리를 만든다.
            Horse[] horse = new Horse[5];
            // 각각의 말 이름들도 해준다.
            for (int i = 0; i < 5; i++)
            {   
                horse[i] = new Horse();
                Console.Write($"{i+1}번 말 이름을 정해주세요 : ");
                horse[i].name = Console.ReadLine();
                horse[i].range = StartPoint;
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i+1}번 말 이름: {horse[i].name}");
            }

            // 경주
            int count = 0;
            while (gameFinished == false)
            {
                count++;
                Console.WriteLine($"===== 시작 {count} 초 경과 =====");
                for (int i = 0; i < 5; i++)
                {
                    if (horse[i].dontMove == false & horse[i].range < FinishPoint)
                    {
                        int tmpMoveDistance = random.Next(minSpeed, maxSpeed + 1);
                        horse[i].Run(tmpMoveDistance);
                        Console.Write($"{horse[i].name}가 달린 거리 :{tmpMoveDistance} / ");
                    }
                    Console.WriteLine($"{horse[i].name}의 현재 거리 :{horse[i].range}");

                    if (horse[i].range >= FinishPoint)
                    {
                        horse[i].dontMove = true;
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }

    public class Horse
    {
        internal string name;
        internal int range;
        internal bool dontMove;

        public void Run(int moveDistance)
        {
            range += moveDistance;
        }

    }
}
