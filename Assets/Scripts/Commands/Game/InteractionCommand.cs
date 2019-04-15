using System.Collections;
using System.Collections.Generic;
using Game.Data.Grid;
using UnityEngine;

namespace Commands.Game
{
    public class InteractionCommand : MonoBehaviour, ICommand<GridItemData>
    {
        private UnitEntity unit;

        [SerializeField] private List<InteractionType> _interactionTypes = new List<InteractionType>();
        [SerializeField] private Interaction _interaction;
        [SerializeField] private bool _interactable;

        private void Awake()
        {
            unit = GetComponent<UnitEntity>();
        }

        public bool Interactable
        {
            get { return _interactable; }
        }

        public List<InteractionType> InteractionTypes
        {
            get { return _interactionTypes; }
        }

        public IEnumerator execute(GridItemData target)
        {
            if (!_interactable)
            {
                yield break;
            }

            if (target == null || !target.Unit.Interaction.Interactable)
            {
                yield break;
            }

//            if (!checkInteractionType(_interaction.RequiredInteractionType))
//            {
//                yield break;
//            }

            if (!_interaction.checkCanInteract(unit, target.Unit))
            {
                yield break;
            }

            var targetUnit = target.Unit;
//            target.Unit = null;

            yield return StartCoroutine(_interaction.interactionCoroutine(targetUnit, target.Unit));
        }


        protected bool checkInteractionType(InteractionType type)
        {
            return _interactionTypes.Contains(type);
        }
    }
}