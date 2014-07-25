
using System.Drawing;
using System.Xml.Serialization;
using LambdaMan.Common;

namespace LambdaMan.Simulator.Game
{
    public class GameSimulator
    {
        public const int Fruit1AppearsTick = 127 * 200;
        public const int Fruit2AppearsTick = 127 * 400;

        public const int Fruit1ExpiresTick = 127 * 280;
        public const int Fruit2ExpiresTick = 127 * 480;

        public const int FrightModeDuration = 127 * 20;

        public int CurrentTick { get; set; }

        public int Lives { get; set; }

        public int Score { get; set; }

        public bool InFrightMode { get; set; }

        public int FrightModeDeactivateTick { get; set; }

        public LambdaMan LambdaMan { get; set; }

        public Ghost[] Ghosts { get; set; }

        public void ExecuteTick()
        {
            // LambdaMan.Think()
            // foreach(var ghost in Ghosts)
            //   ghost.Think()

            if (InFrightMode && FrightModeDeactivateTick == CurrentTick)
                InFrightMode = false;

            switch (ElementAt(LambdaMan.Position))
            {
                case Element.Pill:
                    Score += 10;
                    RemoveElementAt(LambdaMan.Position);
                    break;

            }


        }

        public Element ElementAt(Point position)
        {
            return Element.Empty;
        }

        public void RemoveElementAt(Point position)
        {
            
        }
    }
}
