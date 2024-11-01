using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector2 movementInput;
    private Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        //rigidbody2D.AddForce(new Vector2(movementInput.x * speed , ForceMode2D.Impulse));       
        rigidbody2D.AddForce(movementInput * speed, ForceMode2D.Force);

    }
    public void ReadDirection(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
