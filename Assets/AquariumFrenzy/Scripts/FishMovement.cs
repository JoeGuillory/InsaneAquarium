using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{
    private Vector2 _destination;
    void Start()
    { 
        InputSystem.actions.FindAction("Click").performed += OnClick;
    }

    void OnClick(InputAction.CallbackContext context)
    {
        _destination = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        print(_destination);
    }

}
