using System.Collections;
using System.Collections.Generic;
using Core.InputModule;
using Game;
using UnityEngine;

public class GameControllerBuilder : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		GameController gameController = gameObject.AddComponent<GameController>();
		gameController.Initialize(new KeyboardInputController());
	}
}
