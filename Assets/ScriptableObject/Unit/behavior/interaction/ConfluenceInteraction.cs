using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Behavior/Interaction/ConfluenceInteraction", fileName = "ConfluenceInteraction")]
public class ConfluenceInteraction : Interaction
{
    public float velocity;

    public override IEnumerator interactionCoroutine(UnitEntity current, UnitEntity target)
    {
        var targetPosition = target.transform.position;
        while (true)
        {
            Vector3 newPosition = Vector3.MoveTowards(current.transform.position, targetPosition, velocity);
            current.transform.position = newPosition;
            if (newPosition.x != targetPosition.x || newPosition.z != targetPosition.z)
            {
                yield return null;
            }
            else
            {
                Destroy(target.gameObject);
                break;
            }
        }
    }

    public override bool checkCanInteract(UnitEntity current, UnitEntity target)
    {
        return current.UnitType == target.UnitType;
    }
}