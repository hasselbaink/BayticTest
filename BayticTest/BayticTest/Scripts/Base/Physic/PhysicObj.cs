using System.Collections.Generic;
using System.Windows.Forms;

namespace BayticTest
{
    public class PhysicObj : GameObject
    {
        public List<ControlCtrl> CollideControls = new List<ControlCtrl>();
        public ControlCtrl MainCollider;

        public Vector2 Velocity;
        public Vector2 Gravity;

        public ControlCtrl Start;
        public ControlCtrl Finish;

        protected bool Started = false;
        protected bool End = false;

        public override void FixedUpdate()
        {
            Gravity.x = System.Math.Abs(Gravity.x);
            if (Velocity.x > 0) Gravity.x *= -1;
            Velocity += Gravity;

            #region CheckBlock
            
            for (int i = 0; i < CollideControls.Count; i++ )
            {
                if (CheckCols(PhysicsCalk.CheckCollidePoints(MainCollider.RealRect, CollideControls[i].RealRect)))
                {
                    if (Started)
                    {
                        GameBuilder.BuildGame(2);
                        End = true;
                        return;
                    }
                }
            }
            #endregion

            CheckCols(PhysicsCalk.CheckCollidePoints(MainCollider.RealRect, Start.RealRect));
            CheckCols(PhysicsCalk.CheckCollidePoints(MainCollider.RealRect, Finish.RealRect));

            Trans.Pos += Velocity;
        }

        bool CheckCols(bool[] ColPoint)
        {
            bool BR = false;
            bool BL = false;
            bool BU = false;
            bool BD = false;

            if (ColPoint[0] || ColPoint[7])
            {
                BR = true;
                BD = true;
            }

            if (ColPoint[1] || ColPoint[6])
            {
                BR = true;
                BU = true;
            }

            if (ColPoint[2] || ColPoint[5])
            {
                BL = true;
                BD = true;
            }

            if (ColPoint[3] || ColPoint[4])
            {
                BL = true;
                BU = true;
            }

            return CheckBlock(BR,BL,BU,BD);
        }

        bool CheckBlock(bool BR, bool BL, bool BU, bool BD)
        {
            bool b = false;
            if ((BR && Velocity.x > 0) || (BL && Velocity.x < 0)) { Velocity.x = 0; b = true; }
            if ((BU && Velocity.y > 0) || (BD && Velocity.y < 0)) { Velocity.y = 0; b = true; }

            return b;
        }
    }
}
