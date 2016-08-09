using System.Collections.Generic;
using System.Windows.Forms;
using BayticTest.Properties;
using System.Drawing;

namespace BayticTest
{
    public static class Game
    {
        public static void Init() {
            GameBuilder.BuildGame(0);
        }

        static int r, g, b = 122;
        static byte byt = 0;

        public static void FixedUpdate()
        {
            if (byt == 0) { r ++; if (r >= 255) { byt++; r = 255; } }
            if (byt == 1) { g ++; if (g >= 255) { byt++; g = 255; } }
            if (byt == 2) { b ++; if (b >= 255) {byt++;b = 255; }  }
            if (byt == 3) { r --; if (r <= 0)   {byt++;r = 0; }  }
            if (byt == 4) { g --; if (g <= 0)   {byt++;g = 0; }  }
            if (byt == 5) { b --; if (b <= 0) { byt++; b = 0; } }
            if (byt == 6) { byt = 0; }
            if (FormMain.MainForm.BackgroundImage == null) FormMain.MainForm.BackColor = Color.FromArgb(r, g, b);
            IO.UpdSize();
            GameBuilder.Upd();
            GOControl.UpdForGOs();
        }
    }
}
