
using TrapTheCat.Events;
using TrapTheCat.Grid;
using UnityEngine;

namespace TrapTheCat.Cat
{
    public class CatController
    {
        private CatView catView;
        private Vector2Int position;
        private EventService eventService;
        private GridService gridService;
        public CatController(CatView catPrefab)
        {
            catView = UnityEngine.Object.Instantiate(catPrefab);
            catView.SetController(this);
        }
        public void Init(EventService eventService, GridService gridService)
        {
            this.eventService = eventService;
            this.gridService = gridService;
            SubscriveEvents();
        }
        private void SubscriveEvents()
        {
           
        }
    }
}
