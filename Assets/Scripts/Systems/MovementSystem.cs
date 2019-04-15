using System.Collections;
using System.Collections.Generic;
using Game.Data.Grid;
using UnityEngine;

namespace DefaultNamespace
{
    struct MoveData
    {
        public UnitEntity item;
        public GridItemData target;

        public MoveData(UnitEntity item, GridItemData target)
        {
            this.item = item;
            this.target = target;
        }
    }

    public class MovementSystem : MonoBehaviour
    {
        private GridData _gridData;

        private List<MoveData> _moveDataList;

        private bool _isFinished;

        public bool IsFinished
        {
            get { return _isFinished; }
        }

        public void Initialize(GridData grid)
        {
            _gridData = grid;
            _moveDataList = new List<MoveData>();
        }

        public IEnumerator Run()
        {
            _isFinished = false;
            _gridData.forEachByDirection(processItem);

            if (_moveDataList.Count == 0)
            {
                _isFinished = true;
                yield break;
            }

            yield return StartCoroutine(doMove());
        }

        private void processItem(GridItemData currentGridItem, int rowIndex, int collumnIndex)
        {
            if (currentGridItem.Unit == null || !currentGridItem.Unit.Movement.Movable)
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

            var targetGridItem = _gridData.GetGridItem(rowIndex, collumnIndex);

            if (targetGridItem == null || targetGridItem.Unit != null)
                return;

            _moveDataList.Add(new MoveData(currentGridItem.Unit, targetGridItem));
            replaceGridItem(currentGridItem, targetGridItem);
        }

        private IEnumerator doMove()
        {
            var coroutines = new List<Coroutine>();
            foreach (var currentInteraction in _moveDataList)
                coroutines.Add(StartCoroutine(currentInteraction.item.Movement.execute(currentInteraction.target)));
            foreach (var coroutine in coroutines)
                yield return coroutine;
            _moveDataList.Clear();
        }

        private void replaceGridItem(GridItemData from, GridItemData to)
        {
            if (from == null || to == null)
                return;

            if (to.Unit == null)
            {
                to.Unit = from.Unit;
                from.Unit = null;
            }
        }
    }
}