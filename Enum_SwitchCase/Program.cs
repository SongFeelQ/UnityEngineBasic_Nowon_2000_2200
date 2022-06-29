using System;
// enum (enumerated type) 열거형
// enum의 기본요소는 모두 int형
enum PlayerState
{
    Idle,
    Attack,
    Jump,
    Walk,
    Run,
    Dash,
    Home,
}

enum studentName
{
    철수,
    영희,
}

namespace Enum_SwitchCase
{
    internal class Program
    {
        static bool doAttack;
        static bool doJump;
        static bool doWalk;
        static bool doRun;
        static bool doDash;
        static bool doHome;

        static PlayerState initState = PlayerState.Attack;

        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            warrior.name = "지존전사";

            if (doAttack)
                warrior.Attack();
            else if (doJump)
                warrior.Jump();
            else if (doWalk)
                warrior.Walk();
            else if (doRun)
                warrior.Run();
            else if (doDash)
                warrior.Dash();
            else if (doHome)
                warrior.Home();
            else
                Console.WriteLine($"전사가 가만히 있음.");

            switch (initState) // switch () 안 조건에 따라 case 안의 내용을 실행함
            {
                case PlayerState.Idle:
                    break;
                case PlayerState.Attack:
                    warrior.Attack();
                    break;
                case PlayerState.Jump:
                    warrior.Jump();
                    break;
                case PlayerState.Walk:
                    warrior.Walk();
                    break;
                case PlayerState.Run:
                    warrior.Run();
                    break;
                case PlayerState.Dash:
                    warrior.Dash();
                    break;
                case PlayerState.Home:
                    warrior.Home();
                    break;
                default:
                    break; // break : 현재 구문을 빠져나오는 분기문
            }



        }
    }
    class Warrior
    {
        public string name;
        public void Attack()
        {
            Console.WriteLine($"{name} (이)가 공격함");
        }
        public void Jump()
        {
            Console.WriteLine($"{name} (이)가 점프함");
        }
        public void Walk()
        {
            Console.WriteLine($"{name} (이)가 걸어감");
        }
        public void Run()
        {
            Console.WriteLine($"{name} (이)가 달림");
        }
        public void Dash()
        {
            Console.WriteLine($"{name} (이)가 돌진함");
        }
        public void Home()
        {
            Console.WriteLine($"{name} (이)가 함");
        }
    }
}
