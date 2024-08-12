using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GatherInput : MonoBehaviour
{
    private Control controls;
     public bool jumpInput;
    public float value;
    // Start is called before the first frame update
   public void Awake()
    {
        controls = new Control();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable(){
        controls.Player.Move.performed += StartMove;
        controls.Player.Move.canceled += StopMove;
        controls.Player.Jump.performed += JumpStart;
        controls.Player.Jump.canceled += JumpStop;
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Move.performed -= StartMove;
        controls.Player.Move.canceled -= StopMove;
        controls.Player.Jump.performed -= JumpStart;
        controls.Player.Jump.canceled -= JumpStop;
        controls.Player.Disable();
    }


      private void StartMove(InputAction.CallbackContext ctx) {
        value = ctx.ReadValue<float>();
    }
     private void StopMove(InputAction.CallbackContext ctx){
         value = 0;
     }

    private void JumpStart(InputAction.CallbackContext ctx)
    {
        jumpInput = true;
    }

    private void JumpStop(InputAction.CallbackContext ctx)
    {
        jumpInput = false;
    }
}
