using UnityEngine;

public class UnitInteraction : MonoBehaviour
{
    [SerializeField] private Interaction interaction;

    public Interaction Interaction
    {
        get { return interaction; }
    }
}
