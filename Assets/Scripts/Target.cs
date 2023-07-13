using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Warzombie warzombie;
    public float health = 50f;
    
    public void GetDamage(float amountDamage)
    {
        Debug.Log("Try to damage");
        health -= amountDamage;


        if (health <= 0)
        {
            warzombie.EnableRagdoll();
            Invoke("DesableEnemy", 5f);

        }
    }
    void DesableEnemy()
    {
        this.gameObject.SetActive(false);
    }

}
