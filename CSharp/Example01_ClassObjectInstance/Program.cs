using System;

namespace Example01_ClassObjectInstance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Orc orc1 = new Orc();
            orc1.name = "상급오크";
            orc1.height = 240.2f;
            orc1.weight = 200;
            orc1.age = 140;
            orc1.gender = '남';
            orc1.isresting = false;

            Orc orc2 = new Orc();
            orc2.name = "하급오크";
            orc2.height = 140.4f;
            orc2.weight = 120;
            orc2.age = 60;
            orc2.gender = '여';
            orc2.isresting = true;

            orc1.Try();
            orc2.Try();

            //if (orc1.resting)
            //{
            //    orc1.jump();
            //    orc1.smash();
            //}
            //else
            //{
            //    orc1.busy();
            //}

            //if (orc2.resting)
            //{
            //    orc2.jump();
            //    orc2.smash();
            //}
            //else
            //{
            //    orc2.busy();
            //}
        }
    }


    class Orc
    {
        internal string name;
        internal float height;
        internal float weight;
        internal int age;
        internal char gender;
        internal bool isresting;

        public void Jump()
        {
            Console.WriteLine(this.name + "(이)가 점프했다!");
        }
        public void Smash()
        {
            Console.WriteLine(this.name + "(이)가 휘둘렀다!");
        }
        public void Busy()
        {
            Console.WriteLine(this.name + "(이)가 바쁘다.");
        }
        public void Try()
        {
            // this 키워드
            // 객체 자기자신을 참조하는 키워드
            if (this.isresting)
            {
                this.Jump();
                this.Smash();
            }
            else
            {
                this.Busy();
            }
        }
    }
}
