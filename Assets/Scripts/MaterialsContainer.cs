using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialsContainer", menuName = "DGN/Data/Materials Container", order = 1)]
public class MaterialsContainer : UnityEngine.ScriptableObject {
	public List<Material> materials = new List<Material>();
}
