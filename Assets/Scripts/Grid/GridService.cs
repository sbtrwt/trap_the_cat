using System;
using System.Collections;
using System.Collections.Generic;
using TrapTheCat.Events;
using UnityEngine;

namespace TrapTheCat.Grid
{
    public class GridService 
    {
        private GridController gridController;
        private EventService eventService;
        private GridSO gridSO;
        public GridService(GridSO gridData)
        {
            this.gridSO = gridData;
        }

        public void Init(EventService eventService)
        {
            this.eventService = eventService;
            gridController = new GridController(gridSO, eventService);
        }

        public Vector3 GetCenterCellPosition()
        {
            return gridController.GetCenterCellPosition();
        }
        public Vector3 GetCellPosition(Vector2Int gridPosition)
        {
            return gridController.GetCellPosition(gridPosition);
        }
        public bool IsCellBlocked(int x, int y)
        {
            return gridController.IsCellBlocked(x, y);
        }

        public Vector2Int GetCenterGridPosition()
        {
            return gridController.GetCenterGridPosition();
        }

        public float GetDistanceToGridEdge(Vector2Int pos)
        {
            return gridController.GetDistanceToGridEdge(pos);
        }
        public bool HasEscaped(Vector2Int position)
        {
           return gridController.HasEscaped(position);
            
        }
        public Vector2Int GetGridSize() {
            return new Vector2Int(gridSO.GridRow, gridSO.GridColumn);
        }
    }
}


