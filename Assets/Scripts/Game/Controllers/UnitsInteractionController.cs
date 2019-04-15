using Events;
using Game.Data.Grid;
using UnityEngine;

namespace Game.Controllers
{
    struct InteractionData
    {
        public GridItemData current;
        public UnitEntity target;

        public InteractionData(GridItemData current, UnitEntity target)
        {
            this.current = current;
            this.target = target;
        }
    }


    public class UnitsInteractionController : MonoBehaviour
    {
        private GridData grid;

        public void initialize(GridData gridData)
        {
            grid = gridData;
            initializeEvetListeners();
        }

        private void OnDestroy()
        {
            removeEventListeners();
            grid = null;
        }

        private void initializeEvetListeners()
        {
            EventManager.StartListening(ItemsMoveEvent.MOVE_COMPLETE, onItemsMoveCompleteHandler);
        }

        private void removeEventListeners()
        {
            EventManager.StopListening(ItemsMoveEvent.MOVE_COMPLETE, onItemsMoveCompleteHandler);
        }

        private void onItemsMoveCompleteHandler()
        {
            switch (grid.currentDirection)
            {
                    case GridData.DIRECTION.UP:
                        grid.forEachByDirection(interactionUp);
                        break;
                    case GridData.DIRECTION.DOWN:
                        grid.forEachByDirection(interactionDown);
                        break;
                    case GridData.DIRECTION.LEFT:
                        grid.forEachByDirection(interactionLeft);
                        break;
                    case GridData.DIRECTION.RIGHT:
                        grid.forEachByDirection(interactionRight);
                        break;
            }
        }

        private void interactionUp(GridItemData gridItemData, int rowIndex, int collumnIndex)
        {

        }

        private void interactionDown(GridItemData gridItemData, int rowIndex, int collumnIndex)
        {

        }

        private void interactionLeft(GridItemData gridItemData, int rowIndex, int collumnIndex)
        {

        }

        private void interactionRight(GridItemData gridItemData, int rowIndex, int collumnIndex)
        {

        }

    }
}