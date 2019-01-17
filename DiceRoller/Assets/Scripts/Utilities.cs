using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Utilities
    {
        public enum Dice { D4, D6, D8, D10, D12, D20, D100 };

        public static int ToNearest90 (float rawValue)
        {
            if (rawValue < 0 + 45)
            {
                return 0;
            }
            else if (rawValue < 90 + 45)
            {
                return 90;
            }
            else if (rawValue < 180 + 45)
            {
                return 180;
            }
            else if (rawValue < 270 + 45)
            {
                return 270;
            }
            else if (rawValue < 360)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
