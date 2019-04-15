using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Behavior/Move/MoveLinear", fileName = "MoveLinear")]
public class MoveItemLinear : Mover
{
	public override IEnumerator moveCoroutine(UnitEntity target, Vector3 targetPosition)
	{
		while (true)
		{
			Vector3 newPosition = Vector3.MoveTowards(target.transform.position, targetPosition, velocity);
			target.transform.position = newPosition;
			if (newPosition.x != targetPosition.x || newPosition.z != targetPosition.z)
				yield return null;
			else
				break;
		}
	}
}
