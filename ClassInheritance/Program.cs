using System;
using System.Collections.Generic;

namespace ClassInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creature creature = new Creature();
            //creature.Breath();

            Human human1 = new Human();
            //string CraetureName = "CreatureName.txt";
            human1.name = "실험체1";
            human1.Breath();
            human1.Grow();
            human1.Grow();

            YellowMan yellowMan1 = new YellowMan();
            yellowMan1.name = "황인종1";
            yellowMan1.Grow();
            BlackMan blackMan1 = new BlackMan();
            blackMan1.name = "흑인종1";
            blackMan1.Grow();
            WhiteMan whiteMan1 = new WhiteMan();
            whiteMan1.name = "백인종1";
            whiteMan1.Grow();

            // 자식 객체는 부모타입으로 참조가 가능하다. (공변성)
            List<Human> men = new List<Human>();
            Human man1 = new YellowMan();
            men.Add(new YellowMan());
            men.Add(new BlackMan());
            men.Add(new WhiteMan());
            for (int i = 0; i < men.Count; i++)
            {
                men[i].name = $"사람{i + 1}";
                men[i].Grow();
            }

            List<ITwoLeggedWalker> twoLeggedWalkers = new List<ITwoLeggedWalker>();
            twoLeggedWalkers.Add(new YellowMan());
            twoLeggedWalkers.Add(new BlackMan());
            twoLeggedWalkers.Add(new WhiteMan());
            for (int i = 0; i < men.Count; i++)
            {
                twoLeggedWalkers[i].TwoLeggedWalk();
            }
        }
    }
}
