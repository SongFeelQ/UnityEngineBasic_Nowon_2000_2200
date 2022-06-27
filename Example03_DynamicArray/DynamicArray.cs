using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example03_DynamicArray
{
    internal class DynamicArray
    {
        // const : constant. 해당 변수를 상수형태로 취급하겠다는 키워드.
        private const int DEFAULT_SIZE = 1;
        private int[] _data = new int[DEFAULT_SIZE];

        public int this[int index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }

        public int Length; // 실제 데이터의 개수
        
        // 프로퍼티 : 필드의 값을 쓰거나 읽을 때 get 함수나 set 함수를 용이하게 만들어서 접근할 수 있는
        // get 접근자와 set 접근자를 구현할 수 있는 멤버
        public int Capacity // _data 의 길이
        {
            set
            {
                int tmp = value;
                // do nothing;
            }
            get
            {
                return _data.Length;
            }
        }

        //public void SetCapacity(int value)
        //{
        //    Capacity = value;
        //}
        //public int GetCapacity()
        //{
        //    return _data.Length;
        //}

        // 이렇게 하는 이유는 C#이 객체지향형 프로그래밍인데
        // 외부 클래스에서 직접 멤버 변수에 접근하는것은 올바르지 않기 때문.
        // public는 외부 클래스에서 사용할 수 있다고 설계되었다는 의미로 통할 수 있다./

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

        public bool Remove(int item)
        {
            bool  isFounded = false;
            for (int i = 0; i < Length; i++)
            {
                if (_data[i] == item)
                {
                    isFounded = true;
                    RemoveAt(i);
                    break;
                }
            }
            return isFounded;
        }

        public void RemoveAt(int index)
        {
            for(int i = index; i < Length - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Length - 1] = default(int);
            Length--;
        }
    }
}
