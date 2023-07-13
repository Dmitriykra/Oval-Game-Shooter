using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isShooting;
    [SerializeField] GameObject gun;
    Gun gunScript;
    public float fireRate = 15f;
    public float nextTimeToFire = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        gunScript = gun.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gunScript != null && isShooting)
        {            
            if(gunScript.multipleFire && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1.0f / fireRate;
                gunScript.Shoot();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isShooting = true;
        
        if(gunScript != null)
        {
            if(!gunScript.multipleFire)
            {
                gunScript.Shoot();
            }
        }    
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isShooting = false;
    }

}
