using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
   
    public void TakeDamage(int damage)
    {
        health = health - damage;
        CheckIfWeDead();
    }

    private void CheckIfWeDead()
    {
        if (health <= 0)
        {
            health = 0;
            Debug.Log("We are dead" + gameObject.name);
            Destroy(gameObject);
        }
    }
}
