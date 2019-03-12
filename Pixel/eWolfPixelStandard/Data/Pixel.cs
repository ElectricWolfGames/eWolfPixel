using System;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class Pixel
    {
        public static Pixel Black = new Pixel(255, 0, 0, 0);
        public static Pixel Red = new Pixel(255, 255, 0, 0);
        public static Pixel White = new Pixel(255, 255, 255, 255);

        public Pixel(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public byte A { get; set; }

        public byte B { get; set; }

        public byte G { get; set; }

        public bool IsBlackout
        {
            get
            {
                return (A == 255
               && B == 0
               && G == 0
               && R == 0);
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (A == 0
               && B == 0
               && G == 0
               && R == 0);
            }
        }

        public byte R { get; set; }

        public override bool Equals(object obj)
        {
            Pixel p = (Pixel)obj;
            if (A != p.A)
                return false;
            if (R != p.R)
                return false;
            if (G != p.G)
                return false;
            if (B != p.B)
                return false;

            return true;
        }
    }
}
