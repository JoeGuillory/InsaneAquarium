using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class FishStateMachine : MonoBehaviour 
{
    [SerializeField]
    float _maxWanderDistance = 3.0f;

    [SerializeField]
    private FishBase _fishScriptibleObject;

    [SerializeField]
    public GameObject _dotObject;

    InputAction _interact;

    private FishStats _fishStats;
    FishBaseState _currentState;
    FishStateFactory _states;
    Rigidbody2D _rb;


    public FishBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Rigidbody2D RigidBody { get { return _rb; } } 
    public FishStats FishStats { get { return _fishStats; } }
    public float MaxWanderDistance { get { return _maxWanderDistance; } }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _states = new FishStateFactory(this);
        _currentState = _states.Wander();
        _currentState.EnterState();
        _fishStats = _fishScriptibleObject.BaseStats;
        _dotObject = Instantiate(_dotObject);
        _interact = InputSystem.actions.FindAction("Interact");
    }


    private void Update()
    {
        _currentState.UpdateState();
        if (_currentState is FishWanderState currentstate)
        {
            if (_interact.WasReleasedThisFrame())
            {
                currentstate.GetNewPosition();
            }
        }

    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdateState();
    }

    private void TestThing(InputAction.CallbackContext context)
    {
      
    }
}
