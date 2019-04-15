using System.Collections;
using System.Collections.Generic;
using Game.Data.Grid;
using UnityEngine;

namespace DefaultNamespace
{
    struct InteractionItemData
    {
        public GridItemData currentItem;
        public GridItemData targetItem;

        public InteractionItemData(GridItemData currentItem, GridItemData targetItem)
        {
            this.currentItem = currentItem;
            this.targetItem = targetItem;
        }
    }

    public class InteractionSystem : MonoBehaviour
    {
        private GridData _gridData;

        private List<InteractionItemData> _interactionDataList;

        private bool _isFinished;

        public bool IsFinished
        {
            get { return _isFinished; }
        }

        public void Initialize(GridData grid)
        {
            _gridData = grid;
            _interactionDataList = new List<InteractionItemData>();
        }

        public IEnumerator Run()
        {
            _isFinished = false;
            _gridData.forEachByDirection(processItem);

            if (_interactionDataList.Count == 0)
            {
                _isFinished = true;
                yield break;
            }

            yield return StartCoroutine(doInteraction());

        }

        private void processItem(GridItemData currentGridItem, int rowIndex, int collumnIndex)
        {
            if (currentGridItem.Unit == null)
                return;

            switch (_gridData.currentDirection)
            {
                case GridData.DIRECTION.UP:
                    rowIndex--;
                    break;
                case GridData.DIRECTION.DOWN:
                    rowIndex++;
                    break;
                case GridData.DIRECTION.LEFT:
                    collumnIndex--;
                    break;
                case GridData.DIRECTION.RIGHT:
                    collumnIndex++;
                    break;
            }

            var target = _gridData.GetGridItem(rowIndex, collumnIndex);

            if (target == null || target.Unit == null)
                return;

            _interactionDataList.Add(new InteractionItemData(currentGridItem, target));
        }

        private IEnumerator doInteraction()
        {
            var coroutines = new List<Coroutine>();
            foreach (var currentInteraction in _interactionDataList)
                coroutines.Add(StartCoroutine(currentInteraction.targetItem.Unit.Interaction.execute(currentInteraction.currentItem)));
            foreach (var coroutine in coroutines)
                yield return coroutine;
            _interactionDataList.Clear();
        }
    }
}