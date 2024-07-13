using TrapTheCat.Grid.Cell;
using UnityEngine;

namespace TrapTheCat.Grid
{
    [CreateAssetMenu(fileName = "GridScriptableObject", menuName = "ScriptableObjects/GridScriptableObject")]
    public class GridSO : ScriptableObject
    {
        public int GridRow;
        public int GridColumn;
        public float RowOffset;
        public float CellSize;
        public float CellSpacing;
        public bool IsZigZag;
        public CellView CellViewPrefab;
    }
}
