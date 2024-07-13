
using TrapTheCat.Cat;
using TrapTheCat.Events;
using TrapTheCat.Grid;
using UnityEngine;

namespace TrapTheCat
{
    public class GamaService : MonoBehaviour
    {
        private EventService eventService;
        private GridService gridService;
        private CatService catService;

        [SerializeField] private GridSO gridSO;
        [SerializeField] private CatView catViewPrefab;
        private void Start()
        {
            InitializeServices();
            InjectDependencies();
            SetCameraPosition();
        }

        private void InitializeServices()
        {
            eventService = new EventService();
            gridService = new GridService(gridSO);
            catService = new CatService(catViewPrefab);

        }
        private void InjectDependencies()
        {
            catService.Init(eventService, gridService);
        }

        private void SetCameraPosition()
        {
            float totalWidth = gridSO.GridColumn * (gridSO.CellSize + gridSO.CellSpacing);
            float totalHeight = gridSO.GridRow * (gridSO.CellSize + gridSO.CellSpacing);
            //Camera.main.transform.position = new Vector3(totalWidth / 2, totalHeight / 2, -10.0f);

            float smallerValue = Mathf.Max(totalWidth, totalHeight);
            Camera.main.orthographicSize = smallerValue * 0.6f;
        }
    }

}
