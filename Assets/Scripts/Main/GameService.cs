
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

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;
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
            gridService.Init(eventService);
            catService.Init(eventService, gridService, uiService);
            UIService.Init(eventService);
        }

        private void SetCameraPosition()
        {
            float totalWidth = gridSO.GridColumn * (gridSO.CellSize + gridSO.CellSpacing);
            float totalHeight = gridSO.GridRow * (gridSO.CellSize + gridSO.CellSpacing);
          

            float smallerValue = Mathf.Max(totalWidth, totalHeight);
            Camera.main.orthographicSize = smallerValue * 0.6f;
        }
    }

}
