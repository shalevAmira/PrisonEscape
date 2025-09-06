using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int playerSpeed = 10;
    [SerializeField] int jumpForce = 20;
    InputSystem inputSystem;
    new Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    Animator animator;
    float movementDirectionX;
    bool isGrounded;

    private void Awake()
    {
        inputSystem = new();
    }

    private void OnEnable()
    {
        inputSystem.Player.Enable();
        inputSystem.Player.Move.performed += OnMovePerformed;
        inputSystem.Player.Move.canceled += OnMoveCanceled;
        inputSystem.Player.Jump.started += OnJumpStarted;
    }

    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        if (!isGrounded) return;
        isGrounded = false;
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        movementDirectionX = 0;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        movementDirectionX = context.ReadValue<Vector2>().x;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isGrounded = true;
        Events.OnPlayerDetected += StopGame;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnDisable()
    {
        inputSystem.Player.Disable();
        inputSystem.Player.Move.performed -= OnMovePerformed;
        inputSystem.Player.Move.canceled -= OnMoveCanceled;
        inputSystem.Player.Jump.started -= OnJumpStarted;
    }

    void StopGame(int x)
    {
        Time.timeScale = 0;
        Debug.Log("Game stopped: " + x);
    }
}
