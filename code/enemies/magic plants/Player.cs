using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))] //Need this to animate player
[RequireComponent(typeof(Rigidbody))] //Need this for physics
[RequireComponent(typeof(CapsuleCollider))] //Need this for collision
public class Player : MonoBehaviour
{
	Rigidbody _rb;
	Animator _animator;

	[SerializeField]
	protected float _speed = 1;

	protected bool _hasWheelbarrow = false; //TODO: toggle this state when the player grabs the wheelbarrow. //Possibly make a getter/setter so we can change the animator states to match this.

	Vector3 _facing = Vector3.forward;

	[Header("Player Inventory")]

	[SerializeField]
	protected GameObject[] _inventory;

	[Header("Player Reticle Settings")]

	[SerializeField]
	[Tooltip("This is that child object that is placed around the interaction target")]
	protected Transform _playerInteractionReticle;

	[SerializeField]
	float _playerInteractionRange = 60f;

	[SerializeField]
	float _playerInteractionReticleRotationSpeed = 1f;

	int _maxInteractionsToCheck = 30; // This determines how many colliders near the player can be checked to be made the "active" interaction item
	Transform _interactTarget; // Uses _maxInteractionsToCheck as array length
	Collider[] _possibleInteractions; // Interaction Trigger near the player

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody>();
	}
	void Start() {
		_possibleInteractions = new Collider[_maxInteractionsToCheck];
	}

	void Update() {

		transform.rotation = Quaternion.LookRotation(_facing, Vector3.up);

		CheckForIneractiveTargets();
	}

	void CheckForIneractiveTargets()
	{
		Transform prevTarget = _interactTarget;
		_interactTarget = null;
		int numInteractions = Physics.OverlapCapsuleNonAlloc(transform.position + Vector3.up * 50, transform.position + Vector3.down * 50, _playerInteractionRange, _possibleInteractions, LayerMask.GetMask("Player Interaction Triggers"));
		Vector3 closestGoal = transform.position + transform.forward * (_playerInteractionRange / 2); //Using half the player interaction range as the target goal for what the player most wants to interact with.
		float distance = Mathf.Infinity;
		PlayerInteraction p;
		for (int i = 0; i < numInteractions; i++)
		{
			if (!_possibleInteractions[i].TryGetComponent<PlayerInteraction>(out p))
				Debug.LogError("An object the player is going to interact with needs to inherit from PlayerInteraction so universal properties can be shared.");
			
			if (_possibleInteractions[i].transform == transform || !_possibleInteractions[i].enabled || !p.active)
				continue; //We don't want to target ourself or any disabled colliders or this interaction has been disabled.

			//Get the closest interaction to the front of the player
			if (Vector3.Distance(_possibleInteractions[i].transform.position, closestGoal) < distance)
			{
				_interactTarget = _possibleInteractions[i].transform;
				distance = Vector3.Distance(_possibleInteractions[i].transform.position, closestGoal);
			}
		}

		if (_interactTarget != prevTarget && _interactTarget != null) // new target object
			_playerInteractionReticle.gameObject.SetActive(true);
				
		if (_interactTarget != null) // same target
		{
			_playerInteractionReticle.transform.Rotate(Vector3.up, _playerInteractionReticleRotationSpeed);
			_playerInteractionReticle.transform.position = _interactTarget.position;
		}
		else
			_playerInteractionReticle.gameObject.SetActive(false); 
	}

	public void OnMove(InputValue val) {
		Vector2 move = val.Get<Vector2>();
		
		if (_hasWheelbarrow) //move with wheelbarrow
		{
			_animator.SetFloat("Horizontal", move.x);
			_animator.SetFloat("Vertical", Mathf.Clamp(move.y, 0f, 1f)); //Clamp move.y because the player can't move backwards with the wheelbarrow
		}
		else //Move normal
		{
			if (move.sqrMagnitude > 0f) 
				_facing = new Vector3(move.x, 0, move.y); //only update facing if the player is inputing movement. This prevents the player from looking at 0,0,0 when no input is being given.
			_animator.SetFloat("Speed", Mathf.Clamp(move.magnitude, 0f, 1f)); //tells the animator how fast we are going
		}	
	}

	public void OnNextItem(InputValue val) {
		if (val.Get<float>() > 0)
		{

		}
	}

	public void OnPrevItem(InputValue val) {
		if (val.Get<float>() > 0)
		{

		}
	}

	public void OnScrollWheel(InputValue val) {
		var scroll = val.Get<Vector2>();
		print(scroll);
	}

	public void OnFire(InputValue val) {
		if (val.Get<float>() == 0)
			return;

		if (_interactTarget == null) //Player hasn't selected anything.
			return;
		
		//TODO: This plant animation's root drops a bit lower than the other animations... Fix root drop.
		_animator.SetTrigger("Plant");
		_interactTarget.GetComponent<PlayerInteraction>().active = false;

		if (_inventory.Length > 0)
		{
			Instantiate(_inventory[0], _interactTarget.position, Quaternion.identity);
		}
	}

	/// <summary>
	/// Draw Player Gizmos
	/// </summary>
	void OnDrawGizmosSelected()
	{
		//Draw a wire sphere representing the player's interaction range.
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, _playerInteractionRange);

		if(_interactTarget != null)
		{
			Gizmos.DrawSphere(_interactTarget.position, 2f);
		}
	}
}
