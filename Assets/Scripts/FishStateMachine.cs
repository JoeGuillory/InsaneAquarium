using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishStateMachine : MonoBehaviour 
{
    [SerializeField]
    float _wanderDistance = 3.0f;

    FishBaseState _currentState;
    FishStateFactory _states;
    Rigidbody2D _rb;
    public FishBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Rigidbody2D RigidBody { get { return _rb; } } 
    public float WanderDistance { get { return _wanderDistance; } }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _states = new FishStateFactory(this);
        _currentState = _states.Wander();
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdateState();
    }
}
