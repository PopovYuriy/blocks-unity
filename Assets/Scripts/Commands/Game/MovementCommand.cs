using System.Collections;
using Game.Data.Grid;
using UnityEngine;

namespace Commands.Game
{
    public class MovementCommand : MonoBehaviour, ICommand<GridItemData>
    {
        private UnitEntity unit;

        [SerializeField] private Mover _mover;
        [SerializeField] private bool _movable;

        public bool Movable
        {
            get { return _movable; }
        }

        private void Awake()
        {
            unit = GetComponent<UnitEntity>();
        }

        public IEnumerator execute(GridItemData target)
        {
            if (!_movable)
            {
                yield break;
            }

            if (target == null)
            {
                yield break;
            }

            yield return StartCoroutine(_mover.moveCoroutine(unit, target.transform.position));
        }
    }
}