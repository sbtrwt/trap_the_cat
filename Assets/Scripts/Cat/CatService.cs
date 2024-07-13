using TrapTheCat.Events;
using TrapTheCat.Grid;
using UnityEngine;

namespace TrapTheCat.Cat
{
    public class CatService 
    {
        private EventService eventService;
        private GridService gridService;
        private CatController catController;
        public CatService(CatView catViewPrefab)
        {
            catController = new CatController(catViewPrefab);
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
