
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Behavior/Interaction/InteractionType", fileName = "InteractionType")]
public class InteractionType : ScriptableObject
{
    [SerializeField] private string _type;

    public static bool operator ==(InteractionType iType1, InteractionType iType2)
    {
        return iType1._type == iType2._type;
    }

    public static bool operator !=(InteractionType iType1, InteractionType iType2)
    {
        return iType1._type != iType2._type;
    }
}