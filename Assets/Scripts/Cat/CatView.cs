using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TrapTheCat.Cat
{
    public class CatView : MonoBehaviour
    {
        private CatController controller;
        public void SetController(CatController controller)
        {
            this.controller = controller;
        }
    }
}