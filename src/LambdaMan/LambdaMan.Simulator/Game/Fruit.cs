using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaMan.Simulator.Game
{
    public class Fruit
    {
        public Point Position { get; set; }
        public int AppearsTick { get; set; }
        public int ExpiresTick { get; set; }
        public int Score { get; set; }
    }
}
