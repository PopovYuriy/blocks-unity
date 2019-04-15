using System.Collections.Generic;
using Game.Controllers;
using Game.Data.Grid;
using UnityEngine;

namespace Game.Managers
{
	public class GameManager : MonoBehaviour
	{
		private UnitsPlayController _unitsPlayController;
		private UnitsInteractionController _unitsInteractionController;

		private GridData gridData;
		private LevelConfig levelConfig;

		void Start () {
			EventManager.StartListening(LevelLoadingEvent.LEVEL_SCENE_LOADED, levelLoadedHandler);
		}

		private void OnDestroy()
		{
			EventManager.StopListening(LevelLoadingEvent.LEVEL_SCENE_LOADED, levelLoadedHandler);
			Destroy(_unitsPlayController);
			Destroy(_unitsInteractionController);
		}

		private void levelLoadedHandler()
		{
			initializeLevelConfig();
			initializeGrid();
			addUnitsToGrid();
			initializeControllers();
		}

		private void initializeLevelConfig()
		{
			levelConfig = FindObjectOfType<LevelConfig>();
		}

		private void initializeGrid()
		{
			gridData = new GridData(levelConfig.GridSize);
			GameObject gridItemsContainer = GameObject.Find("Grid");
			foreach (Transform child in gridItemsContainer.transform)
			{
				int row = (int)child.position.x;
				int collumn = (int)child.position.z;

				gridData.AddGridItem(child.gameObject.GetComponent<GridItemData>(), row, collumn);
			}
		}

		private void addUnitsToGrid()
		{
			GridItemData gridItem;
			GameObject itemsContainer = GameObject.Find("Items");
			foreach (Transform child in itemsContainer.transform)
			{
				gridItem = gridData.GetGridItem((int) child.position.x, (int) child.position.z);
				if (gridItem == null)
					continue;
				gridItem.Unit = child.gameObject.GetComponent<UnitEntity>();
			}
		}

		private void initializeControllers()
		{
			initializeUnitsMoveController();
			initializeUnitsInteractionController();
		}

		/*
	 	* Units Move Controller.
	 	*/

		private void initializeUnitsMoveController()
		{
			_unitsPlayController = gameObject.AddComponent<UnitsPlayController>();
			_unitsPlayController.initialize(gridData);
		}

		/*
	 	* Units Interaction Controller.
	 	*/

		private void initializeUnitsInteractionController()
		{
			_unitsInteractionController = gameObject.AddComponent<UnitsInteractionController>();
			_unitsInteractionController.initialize(gridData);
		}
	}
}
