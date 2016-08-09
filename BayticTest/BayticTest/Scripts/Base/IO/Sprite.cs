using System.Drawing;

namespace BayticTest
{
    public class Sprite
    {
        Bitmap[] Textures;

        int i = 0;
        byte b = 0;

        public bool Loop = true;

        int IdleFrameCount = 3;

        public Sprite(Bitmap[] Texs) {
            Textures = Texs;
        }
        public Sprite(Bitmap[] Texs, int FC)
        {
            Textures = Texs;
            IdleFrameCount = FC;
        }

        public Bitmap GetTex() {
            if (i >= b * IdleFrameCount)
                if (b < Textures.Length - 1) b++;
                else {
                    if (Loop)
                        b = 0;
                    i = -1;
                }
            i++;
            return Textures[b];
        }
    }
}
