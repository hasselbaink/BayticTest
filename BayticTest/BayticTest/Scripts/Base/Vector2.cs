using System.Drawing;

namespace BayticTest
{
    public struct Vector2
    {
        public static Vector2 zero { get { return new Vector2(0, 0); } }
        public float x, y;

        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b){
            return new Vector2(a.x+b.x, a.y+b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }

        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }

        public static implicit operator Vector2(Size s)
        {
            return new Vector2(s.Width, s.Height);
        }
        public static implicit operator Vector2(Point p)
        {
            return new Vector2(p.X, p.Y);
        }
        public static implicit operator Point(Vector2 v)
        {
            return new Point((int)v.x, (int)v.y);
        }
        public static implicit operator Size(Vector2 v)
        {
            return new Size((int)v.x, (int)v.y);
        }
    }
}
