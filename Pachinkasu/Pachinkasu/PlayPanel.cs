using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pachinkasu
{
    public class PlayPanel
    {
        protected Boolean[,] playArea;
        protected int[] result;
        protected Random rand;
        protected int len;
        protected int height;
        public PlayPanel(int length, Random rand) //how many input slots. must be greater than equal 2
        {
            this.rand = rand;
            this.len = length;
            playArea = new bool[length, length];
            result = new int[length];
        }
        public PlayPanel(int length, int height, Random rand)
        {
            this.rand = rand;
            this.len = length;
            this.height = height;
            playArea = new bool[length, height];
            result = new int[len]; // basically representing the -1 layer as an int array "catching" the balls
        }
        //goes to layer 0 if no layer height given
        public void SwapPin(int loc)
        {
            playArea[loc, 0] = !playArea[loc, 0];
        }
        public void SwapPin(int x, int y)
        {
            playArea[x, y] = !playArea[x, y];
        }
        public void SetPin(int x, int y)
        {
            playArea[x, y] = true;
        }
        public void SetPin(int x, int y, Boolean toBe)
        {
            playArea[x, y] = toBe;
        }
        // user drops one ball at a valid location, get exit location and result is updated
        // %^%^ programming for one layer is a great way to understand programming multiple recursive layers. start from the bottom and work your way up.
        public int DropBall(int loc)
        {
            return DropBall(this.height - 1, loc);

        }
        protected int DropBall(int layerHeight, int loc)
        {

            if (layerHeight == -1)
            {
                result[loc] += 1;
                return loc;
            }
            else if (layerHeight < -1)
            {
                throw new Exception("I was not expecting to go down this many layers");
            }
            else
            {
                if (playArea[loc, layerHeight])
                {
                    int flip = ((rand.Next() % 2) * 2) - 1;
                    loc += flip;
                    if (loc <= -1) loc += 2;
                    if (loc >= len) loc -= 2;
                }
                //the following two lines would be redundant if not for the possibility that the area is 1 wide. maybe it is better to throw an exception...
                //loc = Math.Max(0, loc);
                //loc = Math.Min(loc, this.len - 1);
                return DropBall(layerHeight - 1, loc);
            }
        }
        public void DropEveryLocation()
        {
            for (int i = 0; i < this.len; i++)
            {
                DropBall(i);
            }
        }
        public void DropBallRanks(int[] ranks)
        {
            if (ranks.Length != this.len)
                return;
            for(int i =0; i< this.len; i++)
            {
                for (int j = 0; j < ranks[i]; j++)
                {
                    DropBall(i);
                }
            }
        }
        public int GetLength()
        {
            return this.len;
        }
        public int GetHeight()
        {
            return this.height;
        }

        public int[] GetResult()
        {
            return this.result;
        }
    }
}
