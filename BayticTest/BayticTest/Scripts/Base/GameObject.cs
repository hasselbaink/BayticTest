using System.Collections.Generic;

namespace BayticTest
{
    public class GameObject
    {
        public Rect Trans = new Rect();

        protected List<ControlCtrl> MyUIs = new List<ControlCtrl>();

        #region Init
        public GameObject(Vector2 pos)
        {
            Trans.Pos = pos;
            I();
        }
        public GameObject(Vector2 pos, Vector2 size)
        {
            Trans.Pos = pos;
            Trans.Size = size;
            I();
        }
        public GameObject()
        {
            I();
        }
        void I() {
            GOControl.AddGO(this);
            Init();
        }
        #endregion

        public virtual void Init() { 
            
        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void Destroy() {
            GOControl.RemoveGO(this);
        }

        public virtual void ChangeGUI() {

            for (int i = 0; i < MyUIs.Count; i++)
            {
                MyUIs[i].DrawRect.Pos = MyUIs[i].StartRect.Pos + Trans.Pos;
                MyUIs[i].DrawRect.Size = MyUIs[i].StartRect.Size + Trans.Size;
            }
        }
    }
}
