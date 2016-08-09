using System;
using System.Collections.Generic;
using System.Text;

namespace BayticTest
{
    public static class PhysicsCalk
    {
        public static bool IsCollided(Rect a, Rect b)
        {
            bool[] bs = CheckCollidePoints(a, b);
            for (int i = 0; i < bs.Length; i++ )
                if (bs[i]) return true;
            return false;
        }

        public static bool[] CheckCollidePoints(Rect a, Rect b) 
        {
            bool[] Ans = new bool[8];
            if (CursorPos(a, b.Pos)) Ans[0] = true;
            //else
            if (CursorPos(a, new Vector2(b.Pos.x,b.Pos.y + b.Size.y))) Ans[1] = true;
            //else
            if (CursorPos(a, new Vector2(b.Pos.x + b.Size.x,b.Pos.y))) Ans[2] = true;
            //else
            if (CursorPos(a, new Vector2(b.Pos.x + b.Size.x, b.Pos.y + b.Size.y))) Ans[3] = true;
            //else
            if (CursorPos(b, a.Pos)) Ans[4] = true;
            //else
            if (CursorPos(b, new Vector2(a.Pos.x,a.Pos.y + a.Size.y))) Ans[5] = true;
            //else
            if (CursorPos(b, new Vector2(a.Pos.x + a.Size.x,a.Pos.y))) Ans[6] = true;
            //else
            if (CursorPos(b, new Vector2(a.Pos.x + a.Size.x, a.Pos.y + a.Size.y))) Ans[7] = true;
            return Ans;
        }
        static bool CursorPos(Rect r, Vector2 Coord)
        {
            if (r.Size.x < 0) { r.Pos.x += r.Size.x; r.Size.x *= -1; }
            if (r.Size.y < 0) { r.Pos.y += r.Size.y; r.Size.y *= -1; }
            return (Coord.x >= r.Pos.x && Coord.x <= r.Pos.x + r.Size.x && Coord.y >= r.Pos.y && Coord.y <= r.Pos.y + r.Size.y);
        }
    }
}
