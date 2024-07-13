using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrapTheCat.Grid
{
    public class GridService 
    {
        private GridController gridController;
        public GridService(GridSO gridData)
        {
            gridController = new GridController(gridData);
        }

       
    }
}


