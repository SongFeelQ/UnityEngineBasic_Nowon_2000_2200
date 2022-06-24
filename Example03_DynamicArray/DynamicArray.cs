using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example03_DynamicArray
{
    internal class DynamicArray
    {
        // const : constant. 해당 변수를 상수형태로 사용.
        private const int DEFAULT_SIZE = 1;
        private int[] _data = new int[DEFAULT_SIZE];

        public int Length; // 실제 데이터의 개수
        public int Capacity; // 배열의 크기

        public void Add(int item)
        {
            // Capacity가 모자라면 배열 크기 늘림
            if (Length >= Capacity)
            {
                int[] tmp = new int[Capacity * 2];
                for (int i = 0; i < Length; i++)
                {
                    tmp[i] = _data[i];
                }
                _data = tmp;
            }
            _data[Length] = item;
            Length++;
        }

    }
}
