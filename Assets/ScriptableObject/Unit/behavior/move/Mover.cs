using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : ScriptableObject
{
    public float velocity;

    public abstract IEnumerator moveCoroutine(UnitEntity target, Vector3 targetPosition);
}
