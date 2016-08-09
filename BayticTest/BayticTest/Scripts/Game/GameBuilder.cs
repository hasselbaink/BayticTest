using System.Collections.Generic;
using BayticTest.Properties;
using System.Windows.Forms;
using System.Drawing;

namespace BayticTest
{
    public static class GameBuilder
    {
        #region NoLevels
        static Rocket R = null;
        public static int loadedLevel = -1;

        static LevCompl LC;
        static GameOver GO;
        public static Win WN;

        public static void BuildGame(int LevelNum) {
            bool Loaded = false;

            #region Reset
            if (loadedLevel > -1) {
                FormMain.MainForm.BackgroundImage = null;
                if (R != null) R.Destroy();
                R = null;
                IO.Reset();
                LC = new LevCompl();
                GO = new GameOver();
                WN = new Win();
            }
            #endregion

            #region NoGamePages
            if (LevelNum == 0){
                LoadMenu();
                Loaded = true;
            }

            if (LevelNum == 1){
                LC.CurLevel = loadedLevel;
                LoadLevelComplete();
                Loaded = true;
            }

            if (LevelNum == 2)
            {
                GO.CurLevel = loadedLevel;
                LoadGameOver();
                Loaded = true;
            }

            if (LevelNum == 3)
            {
                //WN.CurLevel = loadedLevel;
                LoadWin();
                Loaded = true;
            }
            #endregion

            if (!Loaded) 
                Loaded = LLevs(LevelNum);

            if (Loaded) 
                loadedLevel = LevelNum;
        }

        public static void Upd()
        {

            if (loadedLevel == 0)
                Menu.Upd();
            if (loadedLevel == 1)
                LC.Upd();
            if (loadedLevel == 2)
                GO.Upd();
            if (loadedLevel == 3)
                WN.Upd();
            //if (loadedLevel >= 1 && loadedLevel <= 3)
                //NoGamePage.Upd();
        }

        #region NoGamePages
        static void LoadMenu() {
            FormMain.MainForm.BackgroundImage = Resources.fon;

            Menu.ExitBut  = IO.AddButton(new Rect(5, 10, 30, 10), "Выход" , WidthAnchor.Right, HeightAnchor.Down, 0.8f/*, BS: 1*/);
            Menu.StartBut = IO.AddButton(new Rect(5, 25, 30, 10), "Играть", WidthAnchor.Right, HeightAnchor.Down, 0.8f);
        }

        static void LoadGameOver() {
            GO.Next = IO.AddButton(new Rect(30, 25, 35, 10), "Меню", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false /*, BS : 1*/);
            GO.Retry = IO.AddButton(new Rect(0, 14, 35, 10), "Переиграть", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false);
            GO.Back = IO.AddButton(new Rect(-30, 25, 35, 10), "Предыдущий", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false);

            if (GO.CurLevel < 5)
                GO.Back.Visible = false;

            GO.StriteTex = IO.AddTexture(new Rect(0, 10, 25, 40), Resources.alpha_channel, WidthAnchor.Center, HeightAnchor.Up);
            Sprite Sprt = new Sprite(new Bitmap[] { Resources.Exp0, Resources.Exp1, Resources.Exp2, Resources.Exp3, Resources.Exp4, Resources.Exp5, Resources.Exp6, Resources.Exp7, Resources.Exp8, Resources.Exp9, Resources.Exp10, Resources.Exp11, Resources.Exp12});
            GO.Exp = Sprt;

            IO.AddButton (new Rect(0, 0, 100, 10), "Вы проиграли :(", WidthAnchor.Center, HeightAnchor.Up, WidthSizeCalkH: false, Texture: Resources.alpha_channel).ForeColor = Color.Red;
        }

        static void LoadLevelComplete()
        {
            LC.Retry = IO.AddButton(new Rect(30, 25, 35, 10), "Переиграть", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false /*, BS : 1*/);
            LC.Next = IO.AddButton(new Rect(0, 14, 35, 10), "Далее", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false);
            LC.Back = IO.AddButton(new Rect(-30, 25, 35, 10), "Предыдущий", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false);

            if (LC.CurLevel < 5)
                LC.Back.Visible = false;

            if (LC.CurLevel >= EndLevel)
                LC.End = true;

            LC.StriteTex = IO.AddTexture(new Rect(0, 10, 25, 40), Resources.alpha_channel, WidthAnchor.Center, HeightAnchor.Up);
            Sprite Sprt = new Sprite(new Bitmap[] { Resources.FA1, Resources.FA2, Resources.FA3, Resources.FA4, Resources.FA5, Resources.FA6, Resources.FA7, Resources.FA6, Resources.FA5, Resources.FA4, Resources.FA3, Resources.FA2, Resources.FA1 }, 6);
            LC.Exp = Sprt;

            IO.AddButton(new Rect(0, 0, 100, 10), "Уровень пройден!", WidthAnchor.Center, HeightAnchor.Up, WidthSizeCalkH: false, Texture: Resources.alpha_channel).ForeColor = Color.FromArgb(0,255,0);
        }

        static void LoadWin()
        {
            WN.Retry = IO.AddButton(new Rect(30, 25, 35, 10), "Переиграть", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false /*, BS : 1*/);
            WN.Next = IO.AddButton(new Rect(0, 14, 35, 10), "Меню", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false);
            WN.Back = IO.AddButton(new Rect(-30, 25, 35, 10), "Предыдущий", WidthAnchor.Center, HeightAnchor.Center, WidthSizeCalkH: false);

            IO.AddTexture(new Rect(0, 10, 65, 40), Resources.EndWinBack, WidthAnchor.Center, HeightAnchor.Up);

            if (WN.CurLevel < 5)
                WN.Back.Visible = false;

            IO.AddButton(new Rect(0, 0, 100, 10), "Вы прошли игру!", WidthAnchor.Center, HeightAnchor.Up, WidthSizeCalkH: false, Texture: Resources.alpha_channel).ForeColor = Color.FromArgb(0, 255, 0);
        }
        #endregion
        #endregion

        public static int EndLevel = 8;

        static bool LLevs(int LN)
        {
            #region Lev1
            if (LN == 4)
            {
                Level1();
                return true;
            }
            #endregion

            #region Lev2
            if (LN == 5)
            {
                Level2();
                return true;
            }
            #endregion

            #region Lev3
            if (LN == 6)
            {
                Level3();
                return true;
            }
            #endregion

            #region Lev4
            if (LN == 7)
            {
                Level4();
                return true;
            }
            #endregion

            #region Lev5
            if (LN == 8)
            {
                Level5();
                return true;
            }
            #endregion

            return false;
        }

        static void Level1() {
            ControlCtrl Start;
            ControlCtrl Finish;

            List<ControlCtrl> AllObjs = new List<ControlCtrl>();

            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Down, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Right, HeightAnchor.Up, false).MyControl);

            Start = IO.AddTexture(new Rect(-45, 1, 6, 3), Resources.Finish1).MyControl;
            Finish = IO.AddTexture(new Rect(40, 1, 8, 3), Resources.Finish1).MyControl;

            R = new Rocket();
            R.Trans.Pos.x = -45;
            R.Trans.Pos.y = 3;

            R.Finish = Finish;
            R.Start = Start;

            for (int i = 0; i < AllObjs.Count; i++)
                R.CollideControls.Add(AllObjs[i]);

            AllObjs.Add(Start);
            AllObjs.Add(Finish);
        }

        static void Level2()
        {
            ControlCtrl Start;
            ControlCtrl Finish;

            List<ControlCtrl> AllObjs = new List<ControlCtrl>();

            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Down, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Right, HeightAnchor.Up, false).MyControl);


            AllObjs.Add(IO.AddTexture(new Rect(0, 0, 5, 50), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);
            

            Start = IO.AddTexture(new Rect(-45, 1, 6, 3), Resources.Finish1).MyControl;
            Finish = IO.AddTexture(new Rect(10, 1, 8, 3), Resources.Finish1).MyControl;

            R = new Rocket();
            R.Trans.Pos.x = -45;
            R.Trans.Pos.y = 3;

            R.Finish = Finish;
            R.Start = Start;

            for (int i = 0; i < AllObjs.Count; i++)
                R.CollideControls.Add(AllObjs[i]);

            AllObjs.Add(Start);
            AllObjs.Add(Finish);
        }

        static void Level3()
        {
            ControlCtrl Start;
            ControlCtrl Finish;

            List<ControlCtrl> AllObjs = new List<ControlCtrl>();

            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Down, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Right, HeightAnchor.Up, false).MyControl);


            AllObjs.Add(IO.AddTexture(new Rect(-35, 0, 5, 70), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);
            
            AllObjs.Add(IO.AddTexture(new Rect(-7, 64.7f, 60, 5), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);

            AllObjs.Add(IO.AddTexture(new Rect(25, 30, 5, 40), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);


            Start  = IO.AddTexture(new Rect(-45, 1, 6, 3), Resources.Finish1).MyControl;
            Finish = IO.AddTexture(new Rect(-28, 1, 8, 3), Resources.Finish1).MyControl;

            R = new Rocket();
            R.Trans.Pos.x = -45;
            R.Trans.Pos.y = 3;

            R.Finish = Finish;
            R.Start = Start;

            for (int i = 0; i < AllObjs.Count; i++)
                R.CollideControls.Add(AllObjs[i]);

            AllObjs.Add(Start);
            AllObjs.Add(Finish);
        }

        static void Level4()
        {
            ControlCtrl Start;
            ControlCtrl Finish;

            List<ControlCtrl> AllObjs = new List<ControlCtrl>();

            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Down, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Right, HeightAnchor.Up, false).MyControl);


            AllObjs.Add(IO.AddTexture(new Rect(-35, 0, 5, 70), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);

            AllObjs.Add(IO.AddTexture(new Rect(-7, 64.7f, 60, 5), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);

            AllObjs.Add(IO.AddTexture(new Rect(25, 30, 5, 40), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);

            AllObjs.Add(IO.AddTexture(new Rect(2, 30, 45, 5), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);


            Start = IO.AddTexture(new Rect(-45, 1, 6, 3), Resources.Finish1).MyControl;
            Finish = IO.AddTexture(new Rect(17, 35, 8, 3), Resources.Finish1).MyControl;

            R = new Rocket();
            R.Trans.Pos.x = -45;
            R.Trans.Pos.y = 3;

            R.Finish = Finish;
            R.Start = Start;

            for (int i = 0; i < AllObjs.Count; i++)
                R.CollideControls.Add(AllObjs[i]);

            AllObjs.Add(Start);
            AllObjs.Add(Finish);
        }


        static void Level5()
        {
            ControlCtrl Start;
            ControlCtrl Finish;

            List<ControlCtrl> AllObjs = new List<ControlCtrl>();

            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(0, -4, 100, 5), Resources.Black, WidthAnchor.Left, HeightAnchor.Down, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Left, HeightAnchor.Up, false).MyControl);
            AllObjs.Add(IO.AddTexture(new Rect(-4, 0, 5, 100), Resources.Black, WidthAnchor.Right, HeightAnchor.Up, false).MyControl);


            AllObjs.Add(IO.AddTexture(new Rect(-35, 0, 5, 70), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);

            AllObjs.Add(IO.AddTexture(new Rect(-7, 64.7f, 60, 5), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);

            AllObjs.Add(IO.AddTexture(new Rect(25, 30, 5, 40), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);

            AllObjs.Add(IO.AddTexture(new Rect(-5, 0, 30, 40), Resources.Black, WidthAnchor.Center, HeightAnchor.Down, false).MyControl);


            Start = IO.AddTexture(new Rect(-45, 1, 6, 3), Resources.Finish1).MyControl;
            Finish = IO.AddTexture(new Rect(-27, 1, 8, 3), Resources.Finish1).MyControl;

            R = new Rocket();
            R.Trans.Pos.x = -45;
            R.Trans.Pos.y = 3;

            R.Finish = Finish;
            R.Start = Start;

            for (int i = 0; i < AllObjs.Count; i++)
                R.CollideControls.Add(AllObjs[i]);

            AllObjs.Add(Start);
            AllObjs.Add(Finish);
        }

    }
}
