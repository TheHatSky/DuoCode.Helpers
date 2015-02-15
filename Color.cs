using System;

namespace DuoCode.Helpers
{
    public struct Color
    {
        public readonly double R;
        public readonly double G;
        public readonly double B;

        public Color(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(int r, int g, int b)
            : this(FromByte(r), FromByte(g), FromByte(b))
        {
        }

        public static Color operator *(double k, Color v)
        {
            return new Color(k * v.R, k * v.G, k * v.B);
        }

        public static Color operator +(Color v1, Color v2)
        {
            return new Color(v1.R + v2.R, v1.G + v2.G, v1.B + v2.B);
        }

        public static Color operator *(Color v1, Color v2)
        {
            return new Color(v1.R * v2.R, v1.G * v2.G, v1.B * v2.B);
        }

        public static Color Violet = new Color(0xCC, 0x32, 0xCE);
        public static Color White = new Color(1.0, 1.0, 1.0);
        public static Color Grey = new Color(0.5, 0.5, 0.5);
        public static Color Black = new Color(0.0, 0.0, 0.0);
        public static Color Background = Black;
        public static Color DefaultColor = Black;

        private static int ToByte(double value)
        {
            value = value > 1 ? 1 : value;
            return (int)Math.Floor(value * byte.MaxValue);
        }

        private static double FromByte(int value)
        {
            if (value > byte.MaxValue)
                value = byte.MaxValue;

            if (value < 0)
                value = 0;

            return (double)value / byte.MaxValue;
        }

        public override string ToString()
        {
            return string.Format("rgb({0},{1},{2})", ToByte(R), ToByte(G), ToByte(B));
        }
    }
}