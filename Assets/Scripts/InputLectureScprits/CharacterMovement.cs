using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //! Player Settings
    [Header("Player Settings")]
    [SerializeField] private Rigidbody2D playerRigidbody2D;
    [SerializeField] private float characterSpeed;
    [SerializeField] private float playerJumpForce;
    [SerializeField] private Animator playerAnimator;


    //! Ground Settings
    [Header("Ground Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;


    //! private 
    bool isGround;
    private Vector2 moveInput;

    //! Player Inputs
    private PlayerInput playerInput;



    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Jump.performed += PlayerJump;
    }

    private void PlayerJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed && isGround)
        {
            Jump();
        }
    }

    void Update()
    {
        PlayerMovement();
        PlayerScaleHandler();
    }

    private void PlayerScaleHandler()
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            playerAnimator.SetBool("isWalk", true);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            playerAnimator.SetBool("isWalk", true);

        }
        else
        {
            playerAnimator.SetBool("isWalk", false);
        }
    }

    private void PlayerMovement()
    {
        moveInput = playerInput.Player.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        playerRigidbody2D.linearVelocity = new Vector2(moveInput.x * characterSpeed, playerRigidbody2D.linearVelocity.y);
        isGround = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
    }

    private void Jump()
    {
        playerRigidbody2D.AddForce(Vector2.up * playerJumpForce,ForceMode2D.Impulse);
    }
}
