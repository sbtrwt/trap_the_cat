using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrapTheCat.Grid.Cell
{
    public class CellView : MonoBehaviour
    {
        private CellController controller;
        [SerializeField]private SpriteRenderer spriteRenderer;
        public void SetController(CellController controller)
        {
            this.controller = controller;
        }
        public void SetColor(Color colortToSet) => spriteRenderer.color = colortToSet;
        void OnMouseDown()
        {
            controller.Block();
        }
    }
}