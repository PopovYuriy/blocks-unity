using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSapwner : MonoBehaviour {
    
	[SerializeField] MaterialsContainer _materialsContainer;
	int _materialIndex;
	[SerializeField, Range(0, 100)] int _boxCounter;
	[SerializeField] GameObject _boxPrefab;

	void Start () {
		SpawnBoxes(_boxCounter);
	}

	void SpawnBoxes(int count) {
		for (int i = 0; i < count; i++) {
			_materialIndex = Random.Range(0, _materialsContainer.materials.Count);
			SpawnBox(_boxPrefab, null, Vector3.zero, Vector3.zero, 1.5f * i, _materialIndex);
		}
	}

	void SpawnBox(GameObject objectPrefab, Transform parent, Vector3 position, Vector3 rotation, float step, int materialIndex) {
		GameObject boxGO = Instantiate(objectPrefab, position, Quaternion.Euler(rotation), parent);
		float newPosition = boxGO.transform.position.z + step;
		boxGO.transform.position = new Vector3(boxGO.transform.position.x, boxGO.transform.position.y, newPosition);
		boxGO.GetComponent<MeshRenderer>().material = _materialsContainer.materials[materialIndex];
	}
}
