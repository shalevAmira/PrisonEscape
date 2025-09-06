using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int playerSpeed = 10;
    [SerializeField] int jumpForcee = 20;
    InputSystem inputSystem;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    Animator animator;
    float movementDirectionX;

    private void Awake()
    {
        inputSystem = new();
    }

    private void OnEnable()
    {
        inputSystem.Player.Enable();
        inputSystem.Player.Move.performed += OnMovePerformed;
        inputSystem.Player.Move.canceled += OnMoveCanceled;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        movementDirectionX = 0;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        movementDirectionX = context.ReadValue<Vector2>().x;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementAnimation();
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocityX = movementDirectionX * playerSpeed;
        if (movementDirectionX != 0)
        {
            spriteRenderer.flipX = rigidbody.linearVelocity.x < 0;
        }
    }

    void HandleMovementAnimation()
    {
        animator.SetFloat("speed", rigidbody.linearVelocityX);
    }
}
