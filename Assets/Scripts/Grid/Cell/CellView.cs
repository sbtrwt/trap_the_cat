using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrapTheCat.Grid.Cell
{
    public class CellView : MonoBehaviour
    {
        private CellController controller;
        private SpriteRenderer spriteRenderer;
        public void SetController(CellController controller)
        {
            this.controller = controller;
        }
        public void SetColor(Color colortToSet) => spriteRenderer.color = colortToSet;
    }
}