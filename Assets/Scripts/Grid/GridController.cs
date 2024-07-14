

using System;
using System.Collections.Generic;
using TrapTheCat.Events;
using TrapTheCat.Grid.Cell;
using UnityEngine;

namespace TrapTheCat.Grid
{
    public class GridController
    {
        private GridSO gridSO;
        private CellController [,] grid;
        private Transform gridContainer;
        private EventService eventService;
        public GridController(GridSO gridSO, EventService eventService)
        {
            this.gridSO = gridSO;
            this.eventService = eventService;
            InitializeGrid();
            SubscibeEvents();
            PreBlockRandomCells(gridSO.BlockedCellCount);
        }
     
        private void InitializeGrid()
        {
            gridContainer =  new GameObject("GridContainer").transform;
            grid = new CellController[gridSO.GridRow, gridSO.GridColumn];
            float totalWidth = gridSO.GridColumn * (gridSO.CellSize + gridSO.CellSpacing);
            float totalHeight = gridSO.GridRow * (gridSO.CellSize + gridSO.CellSpacing);

            for (int y = 0; y < gridSO.GridRow; y++)
            {
                for (int x = 0; x < gridSO.GridColumn; x++)
                {
                    float xPos = x * (gridSO.CellSize + gridSO.CellSpacing);
                    float yPos = y * (gridSO.CellSize + gridSO.CellSpacing); 

                    // Apply offset to even rows
                    if (gridSO.IsZigZag && y % 2 == 0)
                    {
                        xPos += gridSO.RowOffset;
                    }

                    Vector3 position = new Vector3(
                        xPos - (totalWidth / 2),
                        yPos - (totalHeight / 2),
                        0
                    );

                    grid[x, y] = new CellController(gridSO.CellViewPrefab, gridContainer, eventService);
                    grid[x, y].SetGridPosition(new Vector2Int(x, y));
                    grid[x, y].SetPosition(position);
                }
            }
        }

        public Vector3 GetCenterCellPosition()
        {
            return grid[gridSO.GridRow / 2, gridSO.GridColumn / 2].GetPosition();
        }
        public Vector2Int GetCenterGridPosition()
        {
            return new Vector2Int(gridSO.GridRow / 2, gridSO.GridColumn / 2);
        }
        public Vector3 GetCellPosition(Vector2Int gridPosition)
        {
            return grid[gridPosition.x, gridPosition.y].GetPosition();
        }
        private void SubscibeEvents()
        {
            eventService.OnBlockCell.AddListener(OnGridCellClick);
        }
        public void OnGridCellClick(Vector2Int gridPosition)
        {

        }

        public bool IsCellBlocked(int x, int y)
        {
            if (x < 0 || x >= gridSO.GridColumn || y < 0 || y >= gridSO.GridRow)
                return true;
            return grid[x, y].IsBlocked;
        }

        public float GetDistanceToGridEdge(Vector2Int pos)
        {
            int distanceX = Mathf.Min(pos.x, gridSO.GridColumn - 1 - pos.x);
            int distanceY = Mathf.Min(pos.y, gridSO.GridRow   - 1 - pos.y);
            return Mathf.Min(distanceX, distanceY);
        }
        public bool HasEscaped(Vector2Int position)
        {
            
            return position.x == 0 || position.x == gridSO.GridColumn - 1 ||
                   position.y == 0 || position.y == gridSO.GridRow - 1;
        }
        private void PreBlockRandomCells(int count)
        {
            List<Vector2Int> availableCells = new List<Vector2Int>();
            for (int y = 0; y < gridSO.GridRow; y++)
            {
                for (int x = 0; x < gridSO.GridColumn; x++)
                {
                    availableCells.Add(new Vector2Int(x, y));
                }
            }

            // Remove the center cell from available cells
            Vector2Int centerCell = GetCenterGridPosition();
            availableCells.Remove(centerCell);

            for (int i = 0; i < count && availableCells.Count > 0; i++)
            {
                int index = UnityEngine.Random.Range(0, availableCells.Count);
                Vector2Int cellToBlock = availableCells[index];
                grid[cellToBlock.x, cellToBlock.y].Block();
                availableCells.RemoveAt(index);
            }
        }
    }
}
