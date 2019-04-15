using UnityEngine;

namespace Game.Data.Grid
{
    public class GridItemData : MonoBehaviour
    {
        [SerializeField] private UnitEntity unit;

        public UnitEntity Unit
        {
            get { return unit; }
            set { unit = value; }
        }
    }
}