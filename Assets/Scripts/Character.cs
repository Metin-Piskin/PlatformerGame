using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CharacterMovementController;

public class Character : MonoBehaviour
{
    CharacterMovementController characterMovement;
    CharacterAnimationController characterAnimation;
    CharacterCombat characterCombat;
    Health health;

    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovementController>();
        characterAnimation = GetComponent<CharacterAnimationController>();
        characterCombat = GetComponent<CharacterCombat>();
        health = GetComponent<Health>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetCharacterState();
        if(Input.GetMouseButtonDown(0) && characterMovement.movementState != MovementStates.Jumping)
        {
            StartCoroutine(AttackOrder());
        }
    }

    private void SetCharacterState()
    {
        if (characterCombat.isAttacking)
            return;
        if (characterMovement.isGrounded())
        {
            if (rigidBody2D.velocity.x == 0)
            {
                //play Idle
                //characterMovement.movementState = MovementStates.Idle;
                characterMovement.SetMovementState(MovementStates.Idle);
            }
            else if (rigidBody2D.velocity.x > 0)
            {
                //play run
                characterMovement.facingDirection = FacingDirection.Right;
                //characterMovement.movementState = MovementStates.Running;
                characterMovement.SetMovementState(MovementStates.Running);
            }
            else if (rigidBody2D.velocity.x < 0)
            {
                characterMovement.facingDirection = FacingDirection.Left;
                //characterMovement.movementState = MovementStates.Running;
                characterMovement.SetMovementState(MovementStates.Running);
            }
        }
        else
        {
            //play jump
            //characterMovement.movementState = MovementStates.Jumping;
            characterMovement.SetMovementState(MovementStates.Jumping);
        }
    }

    private IEnumerator AttackOrder()
    {
        if(characterCombat.isAttacking)
            yield break;

        characterCombat.isAttacking = true;
        characterMovement.movementState=MovementStates.Attacking;
        characterAnimation.TriggerAttackAnim();

        yield return new WaitForSeconds(0.8f);

        characterCombat.Attack();
        characterCombat.isAttacking=false;

        yield break;
    }
}
