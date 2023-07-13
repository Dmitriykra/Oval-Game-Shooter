using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float pHealth = 100f;
    bool isAlive = true;

    public void TakeDamage(float damage)
    {
        pHealth -= damage;
        if (pHealth <= 0)
        {
            
        }
    }

}
