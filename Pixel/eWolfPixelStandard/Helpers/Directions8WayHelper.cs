using System;
using eWolfPixelStandard.Data;

namespace eWolfPixelStandard.Helpers
{
    public static class Directions8WayHelper
    {
        public static Directions8Way GetDirectionFromGrid(int x, int y)
        {
            if (y == 0)
            {
                if (x == 0)
                    return Directions8Way.UpLeft;
                if (x == 1)
                    return Directions8Way.Up;
                if (x == 2)
                    return Directions8Way.UpRight;
            }
            if (y == 1)
            {
                if (x == 0)
                    return Directions8Way.Left;
                if (x == 2)
                    return Directions8Way.Right;
            }
            if (y == 2)
            {
                if (x == 0)
                    return Directions8Way.DownLeft;
                if (x == 1)
                    return Directions8Way.Down;
                if (x == 2)
                    return Directions8Way.DownRight;
            }
            return Directions8Way.None;
        }

        public static int GetDirectionIndex(Directions8Way dir)
        {
            return (int)dir;
        }
    }
}
