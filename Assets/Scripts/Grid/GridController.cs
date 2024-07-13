

using TrapTheCat.Grid.Cell;
using UnityEngine;

namespace TrapTheCat.Grid
{
    public class GridController
    {
        private GridSO gridSO;
        private CellController [,] grid;
        private Transform gridContainer;
        public GridController(GridSO gridSO)
        {
            this.gridSO = gridSO;
            
            InitializeGrid();
        }

        void InitializeGrid()
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

                    grid[x, y] = new CellController(gridSO.CellViewPrefab, gridContainer);
                    grid[x, y].SetGridPosition(new Vector2Int(x, y));
                    grid[x, y].SetPosition(position);
                }
            }
        }
    }
}
