

using UnityEngine;

namespace TrapTheCat.Grid.Cell
{
    public class CellController
    {
        private CellView cellView;
        private Vector2Int gridPosition;
        public bool IsBlocked { get; set; }
        public CellController(CellView cellViewPrefab, Transform parentContainer)
        {
            cellView = Object.Instantiate(cellViewPrefab, parentContainer);
            cellView.SetController(this);
        }
        public void Block()
        {
            IsBlocked = true;
            cellView.SetColor(Color.blue);
        }
        public void SetGridPosition(Vector2Int positionToSet) => gridPosition = positionToSet;
        public Vector2Int GetGridPosition() => gridPosition;
        public void SetPosition(Vector3 spawnPosition)
        {
            cellView.transform.position = spawnPosition;
        }
    }
}
