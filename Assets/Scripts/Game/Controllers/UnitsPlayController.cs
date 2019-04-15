using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Events;
using Game.Data.Grid;
using UnityEngine;

namespace Game.Controllers
{

    public class UnitsPlayController : MonoBehaviour
    {
        private GridData _grid;

        private InteractionSystem _interactionSystem;
        private MovementSystem _movementSystem;

        private bool move;

        public void initialize(GridData grid)
        {
            _grid = grid;

            _interactionSystem = gameObject.AddComponent<InteractionSystem>();
            _interactionSystem.Initialize(_grid);

            _movementSystem = gameObject.AddComponent<MovementSystem>();
            _movementSystem.Initialize(_grid);

            initializeEventsHandlers();
        }

        private void OnDestroy()
        {
            disposeEventsHandlers();
            _grid = null;
        }

        private void initializeEventsHandlers()
        {
            EventManager.StartListening(ItemsMoveEvent.MOVE_UP,    upEventHandler);
            EventManager.StartListening(ItemsMoveEvent.MOVE_DOWN,  downEventHandler);
            EventManager.StartListening(ItemsMoveEvent.MOVE_LEFT,  leftEventHandler);
            EventManager.StartListening(ItemsMoveEvent.MOVE_RIGHT, rightEventHandler);
        }

        private void disposeEventsHandlers()
        {
            EventManager.StopListening(ItemsMoveEvent.MOVE_UP,    upEventHandler);
            EventManager.StopListening(ItemsMoveEvent.MOVE_DOWN,  downEventHandler);
            EventManager.StopListening(ItemsMoveEvent.MOVE_LEFT,  leftEventHandler);
            EventManager.StopListening(ItemsMoveEvent.MOVE_RIGHT, rightEventHandler);
        }

        private void upEventHandler()
        {
            if (move)
                return;
            _grid.currentDirection = GridData.DIRECTION.UP;
            moveItemsByDirection();
        }

        private void downEventHandler()
        {
            if (move)
                return;
            _grid.currentDirection = GridData.DIRECTION.DOWN;
            moveItemsByDirection();
        }

        private void rightEventHandler()
        {
            if (move)
                return;
            _grid.currentDirection = GridData.DIRECTION.RIGHT;
            moveItemsByDirection();
        }

        private void leftEventHandler()
        {
            if (move)
                return;
            _grid.currentDirection = GridData.DIRECTION.LEFT;
            moveItemsByDirection();
        }

        private void moveItemsByDirection()
        {
            StartCoroutine(processMove());
        }

        private IEnumerator processMove()
        {
            move = true;

            do
            {
                var interactionCoroutine = StartCoroutine(_interactionSystem.Run());
                yield return interactionCoroutine;
                var moveCoroutine = StartCoroutine(_movementSystem.Run());
                yield return moveCoroutine;
            } while (!_movementSystem.IsFinished || !_interactionSystem.IsFinished);

            move = false;
        }
    }
}