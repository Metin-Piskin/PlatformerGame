using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayJumpingAnim()
    {
        animator.SetBool("isJumping", true);
    }
    public void PlayIdleAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
    }
    public void PlayRunningAnim()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isJumping", false);
    }
    public void StopRunningAnim()
    {
        animator.SetBool("isRunning", false);
    }
    public void StopJumpingAnim()
    {
        animator.SetBool("isJumping", false);
    }
    public void TriggerAttackAnim()
    {
        animator.SetTrigger("Attacking");
    }
}
