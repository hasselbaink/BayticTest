using System.Windows.Forms;

namespace BayticTest
{
    public static class Menu
    {
        public static MyButton StartBut;
        public static MyButton ExitBut;

        public static void Upd() {
            if (StartBut)
                GameBuilder.BuildGame(4);
            if (ExitBut) 
                Application.Exit();
        }
    }

    public class LevCompl
    {
        public int CurLevel;

        public MyButton Next;
        public MyButton Retry;
        public MyButton Back;

        public bool End = false;

        public Sprite Exp = null;
        public Texture StriteTex;

        public void Upd()
        {
            if (Next || IO.GetKey(Keys.S))
                if (!End)
                    GameBuilder.BuildGame(CurLevel + 1);
                else
                {
                    GameBuilder.BuildGame(3);
                    GameBuilder.WN.CurLevel = CurLevel;
                }

            if (Retry || IO.GetKey(Keys.R))
                GameBuilder.BuildGame(CurLevel);

            if (Back || IO.GetKey(Keys.Q))
                GameBuilder.BuildGame(CurLevel - 1);

            if (Exp != null)
                StriteTex.BackgroundImage = Exp.GetTex();
        }
    }

    public class GameOver
    {
        public int CurLevel;

        public MyButton Next;
        public MyButton Retry;
        public MyButton Back;

        public Sprite Exp = null;
        public Texture StriteTex;

        public void Upd()
        {
            if (Next || IO.GetKey(Keys.Q))
                GameBuilder.BuildGame(0);

            if (Retry || IO.GetKey(Keys.S))
                GameBuilder.BuildGame(CurLevel);

            if (Back || IO.GetKey(Keys.R))
                GameBuilder.BuildGame(CurLevel - 1);

            if (Exp != null)
                StriteTex.BackgroundImage = Exp.GetTex();
        }
    }

    public class Win
    {
        public int CurLevel;

        public MyButton Next;
        public MyButton Retry;
        public MyButton Back;

        public Sprite Exp = null;
        public Texture StriteTex;

        public void Upd()
        {
            if (Next/* || IO.GetKey(Keys.S)*/)
                GameBuilder.BuildGame(0);

            if (Retry || IO.GetKey(Keys.R))
                GameBuilder.BuildGame(CurLevel);

            if (Back || IO.GetKey(Keys.Q))
                GameBuilder.BuildGame(CurLevel - 1);

            if (Exp != null)
                StriteTex.BackgroundImage = Exp.GetTex();
        }
    }

    /*public static class NoGamePage
    {
        public static MyButton Next;
        public static MyButton Retry;
        public static MyButton Back;

        public static int CurLevel;
        public static bool Nextable = false;
        public static bool Menuble = false;
        public static bool End = false;
        public static Sprite Exp = null;
        public static Texture StriteTex;

        public static void Upd()
        {
            int LL = GameBuilder.loadedLevel;

            //LL == 
            //1 - LevComplete
            //2 - GameOver
            //3 - Win

            bool N = false, R = false, B = false;

            if (LL == 1 || LL == 3)
            {
                if (LL != 3) 
                    N = IO.GetKey(Keys.S);
                R = IO.GetKey(Keys.R);
                B = IO.GetKey(Keys.Q);
            }

            if (LL == 2)
            {
                N = IO.GetKey(Keys.Q);
                R = IO.GetKey(Keys.S);
            }

            if (End && (Next || N))
                GameBuilder.BuildGame(3);

            if (Nextable && (Next || N))
                GameBuilder.BuildGame(CurLevel + 1);

            if (Menuble && (Next || N))
                GameBuilder.BuildGame(0);
            
            if (Retry || R)
                GameBuilder.BuildGame(CurLevel);
            
            if (Back || B)
                GameBuilder.BuildGame(CurLevel - 1);
            
            if (Exp != null)
                StriteTex.BackgroundImage = Exp.GetTex();
        }
    }*/
}
