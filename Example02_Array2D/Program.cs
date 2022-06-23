using System;

namespace Example02_Array2D
{
    internal class Program
    {
        // 0은 갈수 있는 길, 1은 벽
        static int[,] map = new int[5, 5]
        {
            { 0, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0 },
            { 0, 1, 0, 0, 0 }
        };

        static void Main(string[] args)
        {
            Player player = new Player();
            player.x = 3;
            player.y = 0;
            Console.WriteLine("시작되었습니다.");
            player.MoveLeft(map);
        }
    }
    class Player
    {
        public int x;
        public int y;

        public void MoveLeft(int[,] map)
        {
            if (x - 1 < 0)
            {
                Console.WriteLine($"플레이어를 왼쪽으로 이동시킬 수 없습니다. (맵의 경계)");
            }
            else if (map[y, x - 1] == 0)
            {
                x--;
                Console.WriteLine($"플레이어 왼쪽으로 한칸 이동. 현재 위치 {x}, {y}");
            }
            else if (map[y, x - 1] == 1)
            {
                Console.WriteLine($"플레이어를 왼쪽으로 이동시킬 수 없습니다. (벽)");
            }
        }
        public void MoveRight(int[,] map)
        {
            if (x + 1 > 4)
            {
                Console.WriteLine($"플레이어를 오른쪽으로 이동시킬 수 없습니다. (맵의 경계)");
            }
            else if (map[y, x + 1] == 0)
            {
                x++;
                Console.WriteLine($"플레이어 오른쪽으로 한칸 이동. 현재 위치 {x}, {y}");
            }
            else if (map[y, x - 1] == 1)
            {
                Console.WriteLine($"플레이어를 오른쪽으로 이동시킬 수 없습니다. (벽)");
            }
        }
        public void MoveUp(int[,] map)
        {
            if (y - 1 < 0)
            {
                Console.WriteLine($"플레이어를 위쪽으로 이동시킬 수 없습니다. (맵의 경계)");
            }
            else if (map[y - 1, x] == 0)
            {
                y--;
                Console.WriteLine($"플레이어 위쪽으로 한칸 이동. 현재 위치 {x}, {y}");
            }
            else if (map[y - 1, x] == 1)
            {
                Console.WriteLine($"플레이어를 위쪽으로 이동시킬 수 없습니다. (벽)");
            }
        }
        public void MoveDown(int[,] map)
        {
            if (y + 1 > 4)
            {
                Console.WriteLine($"플레이어를 아래쪽으로 이동시킬 수 없습니다. (맵의 경계)");
            }
            else if (map[y + 1, x] == 0)
            {
                y++;
                Console.WriteLine($"플레이어 아래쪽으로 한칸 이동. 현재 위치 {x}, {y}");
            }
            else if (map[y + 1, x] == 1)
            {
                Console.WriteLine($"플레이어를 아래쪽으로 이동시킬 수 없습니다. (벽)");
            }
        }
    }
}