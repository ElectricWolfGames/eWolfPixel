namespace eWolfPixelStandard.Items
{
    public class Pixel
    {
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
        public byte R { get; set; }
    }
}
