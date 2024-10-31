using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public float speed = 0.5f;
    public float jumpForce;
    private Vector2 movementInput;
    private Rigidbody2D rigidbody2D;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }
    void Update()
    {
        CheckIfGrounded();
        //rigidbody2D.AddForce(new Vector2(movementInput.x * speed , ForceMode2D.Impulse));       
        rigidbody2D.AddForce(movementInput * speed, ForceMode2D.Force);
    }
    public void ReadDirection(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void readJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
        }
    }
    void Jump()
    {
        rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
}
