using UnityEngine;

[CreateAssetMenu(menuName = "Game/Unit/UnitType", fileName = "InteractionType")]
public class UnitType : ScriptableObject
{
    [SerializeField] private string _type;

    public static bool operator ==(UnitType iType1, UnitType iType2)
    {
        return iType1._type == iType2._type;
    }

    public static bool operator !=(UnitType iType1, UnitType iType2)
    {
        return iType1._type != iType2._type;
    }
}