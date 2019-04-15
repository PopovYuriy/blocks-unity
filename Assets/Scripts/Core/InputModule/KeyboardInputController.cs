using UnityEngine;

namespace Core.InputModule
{
	public class KeyboardInputController : IGameInputController {

		public bool GetRightSlide()
		{
			return Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D);
		}

		public bool GetLeftSlide()
		{
			return Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A);
		}

		public bool GetUpSlide()
		{
			return Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W);
		}

		public bool GetDownSlide()
		{
			return Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S);
		}
	}
}
