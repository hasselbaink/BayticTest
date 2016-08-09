using System.Drawing;
using System.Windows.Forms;
using BayticTest.Properties;

namespace BayticTest
{
    public delegate void SetSize();

    public class ControlCtrl
    {
        public event SetSize SetSizeEvent;

        public Rect RealRect { get { return new Rect(MyControl.Location, MyControl.Size); } }

        #region Vars
        public Control MyControl;
        public Rect StartRect = new Rect();
        public Rect DrawRect = new Rect();
        public WidthAnchor MyWidthAnchor;
        public HeightAnchor MyHeightAnchor;
        public bool WidthSizeCalkH;
        #endregion

        #region Init
        public ControlCtrl(Control ctrl)
        {
            MyControl = ctrl;
        }
        #endregion

        public void SetSize()
        {
            Vector2 FormSize = FormMain.MainForm.ClientSize;

            MyControl.Size = new Size((int)(((WidthSizeCalkH) ? FormSize.y : FormSize.x) * (DrawRect.Size.x / 100f)), (int)(FormSize.y * DrawRect.Size.y / 100f));

            Vector2 MoveSize = new Vector2((FormSize.x / 100) * DrawRect.Pos.x, (FormSize.y / 100) * DrawRect.Pos.y);

            switch (MyWidthAnchor)
            {
                case WidthAnchor.Left: break;
                case WidthAnchor.Center: MoveSize.x += FormSize.x / 2 - MyControl.Size.Width / 2; break;
                case WidthAnchor.Right: MoveSize.x = FormSize.x - MoveSize.x - MyControl.Size.Width; break;
            }

            switch (MyHeightAnchor)
            {
                case HeightAnchor.Up: break;
                case HeightAnchor.Center: MoveSize.y += FormSize.y / 2 - MyControl.Size.Height / 2; break;
                case HeightAnchor.Down: MoveSize.y = FormSize.y - MoveSize.y - MyControl.Size.Height; break;
            }

            MyControl.Location = MoveSize;

            if (SetSizeEvent != null) SetSizeEvent();
        }
    }
}
