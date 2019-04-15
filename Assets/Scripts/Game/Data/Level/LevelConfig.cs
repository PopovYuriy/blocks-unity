using UnityEngine;

[System.Serializable]
public struct GridSize
{
	public int width;
	public int height;

	public GridSize(int width, int height)
	{
		this.width = width;
		this.height = height;
	}
}

public class LevelConfig : MonoBehaviour
{
	[SerializeField] private GridSize gridSize = new GridSize {width = 0, height = 0};

	public GridSize GridSize
	{
		get { return gridSize; }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
