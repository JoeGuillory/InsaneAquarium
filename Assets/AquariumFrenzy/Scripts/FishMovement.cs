using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 40;
    [SerializeField] private float _accel = .02f;
    private Vector2 _destination;
    private Vector2 _velocity;
    private bool _destReached = true;

    private void Start()
    { 
        InputSystem.actions.FindAction("Click").performed += OnClick;
    }

    private void Update()
    {
        if (_destReached)
            return;
         
        Vector2 dir = (_destination - (Vector2)transform.position).normalized;
        _velocity = dir * _speed * _accel * Time.deltaTime;
        transform.Translate(_velocity, Space.Self);


        _destReached = HasReached(_destination);
    }


    private bool HasReached(Vector2 dest)
    {
        Vector3 currentPosition = transform.position;
        float lowerboundx = dest.x - .01f;
        float upperboundx = dest.x + .01f;
        float lowerboundy = dest.y - .01f;
        float upperboundy = dest.y + .01f;

        if (currentPosition.x > lowerboundx
            && currentPosition.x < upperboundx
            && currentPosition.y > lowerboundy
            && currentPosition.y < upperboundy)
            return true;

        return false;
    }


    void OnClick(InputAction.CallbackContext context)
    {
        _destination = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _destReached = false;
        print(_destination);
    }

}
