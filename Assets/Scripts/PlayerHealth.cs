using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float pHealth = 100f;
    bool isAlive = true;
    UiContriller ui;
    private void Start()
    {
        ui = FindObjectOfType<UiContriller>();
    }

    public void TakeDamage(float damage)
    {
        pHealth -= damage;
        if (pHealth <= 0)
        {
            if(ui!= null)
            {
                ui.GameOver();
            }
        }
    }

}
