using System;
using System.Collections.Generic;
using System.Text;

namespace BayticTest
{
    public struct Rect
    {
        public Vector2 Pos;
        public Vector2 Size;

        public Rect(float PosX, float PosY, float SizeX, float SizeY)
        {
            Pos = new Vector2(PosX, PosY);
            Size = new Vector2(SizeX, SizeY);
        }

        public Rect(Vector2 pos, Vector2 size)
        {
            Pos  = pos ;
            Size = size;
        }

        public static Rect operator +(Rect a, Rect b)
        {
            return new Rect(a.Pos + b.Pos, a.Size + b.Size);
        }

        public static Rect operator -(Rect a, Rect b)
        {
            return new Rect(a.Pos - b.Pos, a.Size - b.Size);
        }

        public static Rect operator *(Rect a, Rect b)
        {
            return new Rect(a.Pos * b.Pos, a.Size * b.Size);
        }

        public static Rect operator /(Rect a, Rect b)
        {
            return new Rect(a.Pos / b.Pos, a.Size / b.Size);
        }
    }
}
