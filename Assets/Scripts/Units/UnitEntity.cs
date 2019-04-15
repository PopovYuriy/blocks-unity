using Commands.Game;
using UnityEngine;


public class UnitEntity : MonoBehaviour
{
	[SerializeField] private UnitType _unitType;

	private MovementCommand _movment;
	private InteractionCommand _interaction;

	public UnitType UnitType
	{
		get { return _unitType; }
	}

	private void Awake()
	{
		_movment = GetComponent<MovementCommand>();
		_interaction = GetComponent<InteractionCommand>();
	}

	/*
	 *  Getters.
	 */

	public InteractionCommand Interaction
	{
		get { return _interaction; }
	}

	public MovementCommand Movement
	{
		get { return _movment; }
	}
}
