using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace BayticTest
{
    public static class IO
    {
        static List<ControlCtrl> Els = new List<ControlCtrl>();
        static List<Keys> TupKeys = new List<Keys>();

        public static Vector2 mousePos { get { return Control.MousePosition; } }

        public static MyButton AddButton(Rect r, string Text = "", WidthAnchor WA = WidthAnchor.Left, HeightAnchor HA = HeightAnchor.Up, float FontSize = 1, bool WidthSizeCalkH = true, Bitmap Texture = null)
        {
            MyButton NewB = new MyButton();

            NewB.BackColor = Color.Transparent;

            NewB.TabStop = false;

            if (Texture != null)
            {
                NewB.FlatAppearance.BorderSize = 0;
                NewB.FlatAppearance.MouseDownBackColor = Color.Transparent;
                NewB.FlatAppearance.MouseOverBackColor = Color.Transparent;
                NewB.FlatStyle = FlatStyle.Flat;

                NewB.BackgroundImage = Texture;
                NewB.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                //NewB.FlatAppearance.BorderSize = BS;
                NewB.BackColor = Color.FromArgb(90, 255, 255, 255);
                NewB.FlatStyle = FlatStyle.Flat;
            }

            NewB.Text = Text;
            NewB.FontSize = FontSize;

            NewB.MyControl = new ControlCtrl(NewB);
            NewB.MyControl.MyWidthAnchor = WA;
            NewB.MyControl.MyHeightAnchor = HA;
            NewB.MyControl.WidthSizeCalkH = WidthSizeCalkH;
            NewB.MyControl.StartRect = r;
            NewB.MyControl.DrawRect = r;
            FormMain.MainForm.Controls.Add(NewB);

            NewB.Init();

            NewB.MyControl.SetSize();

            Els.Add(NewB.MyControl);

            return NewB;
        }
        public static Label AddLabel(Rect r, string Text = "", WidthAnchor WA = WidthAnchor.Left, HeightAnchor HA = HeightAnchor.Up, float FontSize = 1, bool WidthSizeCalkH = true)
        {
            MyLabel NewB = new MyLabel();

            NewB.BackColor = Color.Transparent;

            NewB.Text = Text;
            NewB.FontSize = FontSize;

            NewB.MyControl = new ControlCtrl(NewB);
            NewB.MyControl.MyWidthAnchor = WA;
            NewB.MyControl.MyHeightAnchor = HA;
            NewB.MyControl.WidthSizeCalkH = WidthSizeCalkH;
            NewB.MyControl.StartRect = r;
            NewB.MyControl.DrawRect = r;
            FormMain.MainForm.Controls.Add(NewB);

            NewB.Init();

            NewB.MyControl.SetSize();

            Els.Add(NewB.MyControl);

            return NewB;
        }
        public static Texture AddTexture(Rect r, Bitmap Texture, WidthAnchor WA = WidthAnchor.Center, HeightAnchor HA = HeightAnchor.Down, bool WidthSizeCalkH = true)
        {
            Texture NewB = new Texture();

            NewB.BackColor = Color.Transparent;

            NewB.BackgroundImage = Texture;
            NewB.BackgroundImageLayout = ImageLayout.Stretch;

            NewB.MyControl = new ControlCtrl(NewB);
            NewB.MyControl.MyWidthAnchor = WA;
            NewB.MyControl.MyHeightAnchor = HA;
            NewB.MyControl.WidthSizeCalkH = WidthSizeCalkH;
            NewB.MyControl.StartRect = r;
            NewB.MyControl.DrawRect = r;
            FormMain.MainForm.Controls.Add(NewB);

            NewB.MyControl.SetSize();

            Els.Add(NewB.MyControl);

            return NewB;
        }

        public static void RemoveControl(ControlCtrl Ctrl) {
            FormMain.MainForm.Controls.Remove(Ctrl.MyControl);
            Els.Remove(Ctrl);
        }

        public static bool GetKey(Keys KeyCode) {
            return TupKeys.Contains(KeyCode);
        }

        public static void KeyDown(Keys KeyCode) {
            if (!GetKey(KeyCode))
                TupKeys.Add(KeyCode);
        }
        public static void KeyUp(Keys KeyCode)
        {
            TupKeys.Remove(KeyCode);
        }

        public static void UpdSize() {
            for (int i = 0; i < Els.Count; i++)
                Els[i].SetSize();
        }

        public static void Reset()
        {
            for (int i = 0; i < Els.Count; i++ )
                FormMain.MainForm.Controls.Remove(Els[i].MyControl);
            Els.Clear();
        }
    }
}
