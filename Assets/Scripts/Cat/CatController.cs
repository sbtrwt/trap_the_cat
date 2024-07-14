
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
        private bool isMoving;
        private Vector3 targetPosition;
        private float moveSpeed = 5f;
        public CatController(CatView catPrefab, Vector2Int position)
        {
            catView = UnityEngine.Object.Instantiate(catPrefab);
            catView.SetController(this);
            this.position = position;
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
        public void SetPosition(Vector3 positionToSet)
        {
            //catView.transform.position = positionToSet;
          
            targetPosition = positionToSet;
            isMoving = true;
            catView.SetMoveAnimation(true);

        }
        public Vector3 GetPosition()
        {
            return catView.transform.position;
        }
        public Vector2Int GetGridPosition()
        {
            return position;
        }
        public void SetGridPosition(Vector2Int positionToSet)
        {

            Vector3 localPosition = catView.transform.localScale;
            localPosition.x *= (position.x < positionToSet.x) ? -1 : 1;
            catView.transform.localScale = localPosition;
            position = positionToSet ;
        }
        public void UpdateCatMoving()
        {
            if (isMoving)
            {
                catView.transform.position = Vector3.Lerp(catView.transform.position, targetPosition, Time.deltaTime * moveSpeed);
                if (Vector3.Distance(catView.transform.position, targetPosition) < 0.01f)
                {
                    catView.transform.position = targetPosition;
                    isMoving = false;
                    catView.SetMoveAnimation(false);
                }
            }
        }
    }
}
