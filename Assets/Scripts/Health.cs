using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Health : MonoBehaviour
{
    public int health;

    public virtual void TakeDamage(int damage)
    {
        health = health - damage;
    }

    protected virtual void HitFeedBack()
    {
        Debug.Log("Hit Feed Back");
    }

    protected virtual void OnDeath()
    {
        Debug.Log("Death");
    }

    protected bool CheckIfWeDead()
    {
        if (health <= 0)
        {
            health = 0;
            return true;
        }
        return false;
    }

}
