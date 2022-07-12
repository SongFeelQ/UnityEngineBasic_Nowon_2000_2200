﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example05_DiceGame
{
    class TileMap
    {
        public Dictionary<int, TileInfo> tiles = new Dictionary<int, TileInfo>();
        public void MapSetup(int maxTileNum)
        {
            for (int i = 0; i < maxTileNum; i++)
            {
                if (i % 5 == 0)
                {
                    // 샛별 칸 생성
                    TileInfo tileInfo_Star = new TileInfo_Star();
                    tileInfo_Star.index = i;
                    tileInfo_Star.name = "샛별";
                    tileInfo_Star.discription = "샛별을 획득할 수 있는 칸입니다.";
                    tiles.Add(i, tileInfo_Star);
                }
                else 
                { 
                    // 일반 칸 생성
                    TileInfo tileInfo = new TileInfo();
                    tileInfo.index = i;
                    tileInfo.name = "일반";
                    tileInfo.discription = "이 칸은 이벤트가 없습니다.";
                    tiles.Add(i, tileInfo);
                }
            }
        }

        public bool TryGetTileInfo(int index, out TileInfo tileInfo)
        {
            return tiles.TryGetValue(index, out tileInfo);
        }
    }
}
