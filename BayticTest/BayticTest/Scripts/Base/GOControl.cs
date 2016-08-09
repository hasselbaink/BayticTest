using System;
using System.Collections.Generic;
using System.Text;

namespace BayticTest
{
    public static class GOControl
    {
        static List<GameObject> AllGOs = new List<GameObject>();

        public static void AddGO(GameObject GO){
            AllGOs.Add(GO);
        }

        public static void RemoveGO(GameObject GO)
        {
            AllGOs.Remove(GO);
        }

        public static void UpdForGOs () {
            for (int i = 0; i < AllGOs.Count; i++)
                AllGOs[i].FixedUpdate();
            for (int i = 0; i < AllGOs.Count; i++)
                AllGOs[i].ChangeGUI();
        }
    }
}
