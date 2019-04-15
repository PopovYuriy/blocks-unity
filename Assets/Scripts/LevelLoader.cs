using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space))
		{
			StartCoroutine(LoadYourAsyncScene());
//			SceneManager.LoadScene(1, LoadSceneMode.Additive);
		}
	}

	IEnumerator LoadYourAsyncScene()
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

		while (!asyncLoad.isDone)
		{
			Debug.Log(asyncLoad.progress);
			yield return null;
		}

		EventManager.TriggerEvent(LevelLoadingEvent.LEVEL_SCENE_LOADED);

//		Debug.Log("Level Loaded");
	}

}
