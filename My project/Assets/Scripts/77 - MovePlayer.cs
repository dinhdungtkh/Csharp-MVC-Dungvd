using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
  public float speed = 5f;
  public float jumpSpeed = 10f;
  public float gravity = 20f;
  private Vector3 moveDirection = Vector3.zero;
  public float rotationSpeed = 100f;

  void Update()
  {
    CharacterController controller = GetComponent<CharacterController>();
    if (controller.isGrounded)
    {
      moveDirection = new Vector3(0, 0, TouchControl.playerMoveAxisTouch);
      moveDirection = transform.TransformDirection(moveDirection);  
      moveDirection *= speed;
      if (Input.GetButton("Jump"))
        moveDirection.y = jumpSpeed;
    }
    moveDirection.y -= gravity * Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);
    
   //Rotate Player 
   transform.Rotate(0, TouchControl.playerTurnAxisTouch, 0);
  
  }

    
   

}
