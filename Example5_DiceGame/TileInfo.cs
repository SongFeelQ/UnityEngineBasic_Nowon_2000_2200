using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example05_DiceGame
{
    internal class TileInfo
    {
        public int index;    // 몇번째 칸인지에 대한 정보
        public string name; // 칸의 이름 
        public string discription; // 칸에대한 설명 
        virtual public void OnTile() // 이 칸에 도착했을때 실행할 이벤트 함수
        {
            Console.WriteLine($"{index} 번 째 칸에 도착함. {name} : {discription}");
        }
    }

    internal class TileInfo_Star : TileInfo
    {
        public int starValue = 3; // 플레이어가 획득할 수 있는 샛별 갯수 정보

        public override void OnTile()
        {
            base.OnTile();
            starValue++;// 플레이어가 획득할 수 있는 샛별 증가
        }
    }
}
