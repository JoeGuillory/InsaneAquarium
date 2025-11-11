using UnityEngine;
using UnityEngine.InputSystem;
public class FishMovement : MonoBehaviour
{
   private Vector2 targetposition;
   private InputAction clickaction;
   private GameObject target;
   
   void Start()
   {
      clickaction = InputSystem.actions.FindAction("Click");
      clickaction.performed += Click;
      target = transform.Find("TargetPosition").gameObject;
   }

   void Click(InputAction.CallbackContext context)
   {
      
      targetposition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
      target.transform.position = targetposition;
   }


}
