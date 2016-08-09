using System.Drawing;
using BayticTest.Properties;
using System.Windows.Forms;

namespace BayticTest
{
    public class Rocket : PhysicObj
    {
        Sprite FireDownS;
        Texture FireDown;
        Texture RocketTex;

        Texture Explosion;
        Sprite ExplosionS;

        bool Downed = true;

        public override void Init()
        {
            Trans.Size = new Vector2(1,1);
            FireDownS = new Sprite(new Bitmap[]{ Resources.Fire4, Resources.Fire3, Resources.Fire2, Resources.Fire1 }, 3);

            Explosion = IO.AddTexture(new Rect(0, 0, 8, 10), Resources.alpha_channel);
            Explosion.Visible = false;
            ExplosionS = new Sprite(new Bitmap[] { Resources.E1, Resources.E2, Resources.E3, Resources.E4, Resources.E5, Resources.E6, Resources.E7, Resources.E8, Resources.E9, Resources.E10, Resources.E11, Resources.E12, Resources.E13, Resources.E14, Resources.E15, Resources.E16 }, 1);

            FireDown = IO.AddTexture(new Rect(0, -10, 5, 10), Resources.Fire4);
            RocketTex = IO.AddTexture(new Rect(0, 0, 5, 10), Resources.Rocket);

            MyUIs.Add(Explosion.MyControl);
            MyUIs.Add(FireDown.MyControl);
            MyUIs.Add(RocketTex.MyControl);

            MainCollider = RocketTex.MyControl;

            Gravity = new Vector2((Velocity.x < 0) ? 0.001f : -0.001f ,- 0.1f);
        }

        public override void FixedUpdate()
        {
            Vector2 Move = new Vector2((IO.GetKey(Keys.D)) ? 1 : (IO.GetKey(Keys.A)) ? -1 : 0, (IO.GetKey(Keys.W)) ? 1 : /*(IO.GetKey(Keys.S)) ? -1 : */0);

            if (Move.x == 0 && Move.y == 0)
            {
                Downed = false;

                FireDown.BackgroundImage = Resources.alpha_channel;
            }
            else
            {
                if (!Downed)
                {
                    Started = true;
                    Move.x = Move.x / (FormMain.MainForm.Size.Width / (float)FormMain.MainForm.Size.Height);
                    Velocity += new Vector2(Move.x / 10f, Move.y / 5f);
                    FireDown.BackgroundImage = FireDownS.GetTex();
                }
            }

            base.FixedUpdate();

            if (End) return;

            bool[] B = PhysicsCalk.CheckCollidePoints(RocketTex.MyControl.RealRect, Finish.RealRect);
            if (B[7] && B[5])
            {
                GameBuilder.BuildGame(1);
            }
            else
            {
                if (PhysicsCalk.IsCollided(RocketTex.MyControl.RealRect, Finish.RealRect))
                    GameBuilder.BuildGame(2);
            }

            //Explosion.BackgroundImage = ExplosionS.GetTex();
        }
    }
}
