using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    public Rigidbody rb;
    
    public float moveSpeed;
    public float jumpHeight;

    private void Update()
    {
        Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y) 
                       * (moveSpeed * Time.deltaTime);
        
        rb.linearVelocity += move;
        
    }

    public void OnMove(InputValue input)
    {
        moveDirection = input.Get<Vector2>();
    }
}
