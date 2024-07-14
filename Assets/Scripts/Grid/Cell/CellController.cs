

using System;
using TrapTheCat.Events;
using UnityEngine;

namespace TrapTheCat.Grid.Cell
{
    public class CellController
    {
        private CellView cellView;
        private Vector2Int gridPosition;
        private EventService eventService;
        public bool IsBlocked { get; set; }
        public CellController(CellView cellViewPrefab, Transform parentContainer, EventService eventService)
        {
            this.eventService = eventService;
            cellView = UnityEngine.Object.Instantiate(cellViewPrefab, parentContainer);
            cellView.SetController(this);
        }
      
        public void Block()
        {
            if (!IsBlocked)
            {
                IsBlocked = true;
                cellView.SetColor(Color.blue);
                eventService.OnBlockCell.InvokeEvent(gridPosition);
            }
        }
        public void SetGridPosition(Vector2Int positionToSet) => gridPosition = positionToSet;
        public Vector2Int GetGridPosition() => gridPosition;
        public void SetPosition(Vector3 spawnPosition)
        {
            cellView.transform.position = spawnPosition;
        }

        public Vector3 GetPosition()
        {
            return cellView.transform.position;
        }
    }
}
