using System.Collections;
using Core.InputModule;
using Game.Controllers.api;
using UnityEngine;

namespace Game
{
    public enum GameState
    {
        START,
        IDLE,
        PAUSE,
        MOVE,
        FINISH
    }

    public enum SlideDirection
    {
        NONE,
        RIGHT,
        LEFT,
        DOWN,
        UP
    }
    
    public class GameController : MonoBehaviour, IGameController
    {
        private GameState _currentState;
        private IGameInputController _gameInputController;

        public void Initialize(IGameInputController gameInputController)
        {
            _gameInputController = gameInputController;
        }

        private void Start()
        {
            _currentState = GameState.IDLE;
        }

        private void Update()
        {
            if (_currentState == GameState.IDLE)
            {
                checkInput();
            }   
        }

        private void checkInput()
        {
            SlideDirection direction = SlideDirection.NONE;
            if (_gameInputController.GetUpSlide())
            {
                direction = SlideDirection.UP;
            } 
            else if(_gameInputController.GetDownSlide())
            {
                direction = SlideDirection.DOWN;
            }
            else if(_gameInputController.GetLeftSlide())
            {
                direction = SlideDirection.LEFT;
            }
            else if(_gameInputController.GetRightSlide())
            {
                direction = SlideDirection.RIGHT;
            }

            StartCoroutine(playMove_co(direction));
        }

        private IEnumerator playMove_co(SlideDirection direction)
        {
            if (direction == SlideDirection.NONE) 
                yield break;
            
            _currentState = GameState.MOVE;
            
            Debug.Log(_currentState);
            Debug.Log(direction);
            
            _currentState = GameState.IDLE;
            yield return null;
        }
    }
}