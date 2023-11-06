using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public enum MovementStates
    {
        Idle,
        Running,
        Jumping,
        Attacking
    }
    public enum FacingDirection
    {
        Right,
        Left
    }

    [Header("Movement Values")]
    public float momentSpeed;
    public float jumpForce;

    [Header("Raycast length and layerMask")]
    public float isGroundedRayLength;
    public LayerMask platformLayerMask;

    [Header("Movement States")]
    public MovementStates movementState;
    public FacingDirection facingDirection;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private CharacterAnimationController animController;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animController = GetComponent<CharacterAnimationController>();
    }

    void Update()
    {
        HandleJump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        PlayAnimationsBasedOnState();
        SetCharacterDirection();
    }

    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rigidBody2D.velocity = Vector2.up * jumpForce;
        }
    }

    private void HandleMovement()
    {
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody2D.velocity = new Vector2(-momentSpeed, rigidBody2D.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidBody2D.velocity = new Vector2(+momentSpeed, rigidBody2D.velocity.y);
            }
            else
            {
                rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
                rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; // dondur
            }
        }
    }

    public bool isGrounded()
    {
        //collider çarýþtýrýcý
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(
            spriteRenderer.bounds.center,
            spriteRenderer.bounds.size,
            0f,
            Vector2.down,
            isGroundedRayLength,
            platformLayerMask
            );
        return raycastHit2D.collider != null;
    }


    private void SetCharacterDirection()//karakter yönü ayarlama
    {
        switch (facingDirection)
        {
            case FacingDirection.Right:
                spriteRenderer.flipX = false;
                break;
            case FacingDirection.Left:
                spriteRenderer.flipX = true;
                break;
        }
    }

    private void PlayAnimationsBasedOnState()
    {
        switch (movementState)
        {
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;
            case MovementStates.Running:
                animController.PlayRunningAnim();
                break;
            case MovementStates.Jumping:
                animController.PlayJumpingAnim();
                break;
            case MovementStates.Attacking:
                break;
            default:
                break;
        }
    }

    public void SetMovementState(MovementStates movementStates)
    {
        movementState = movementStates;
    }
}
