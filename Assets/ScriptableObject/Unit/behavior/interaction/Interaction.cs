using System.Collections;
using UnityEngine;

public abstract class Interaction : ScriptableObject
{
    public InteractionType RequiredInteractionType;
    public abstract IEnumerator interactionCoroutine(UnitEntity current, UnitEntity target);
    public abstract bool checkCanInteract(UnitEntity current, UnitEntity target);
}