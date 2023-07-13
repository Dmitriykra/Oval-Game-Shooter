using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    float damage = 10f;
    float range = 100f;
    public bool multipleFire;
    [SerializeField] Camera fpsCamera;
    public Text buttonFireRateText;
    public ParticleSystem muzzleEffect;
    public GameObject impact;
    public int ammoMax = 30;
    public Animation animator;
    float impuctForce = 50f;
    
    private void Start() {
        FireTempState();
    }

    public void FireTempState()
    {
        multipleFire = !multipleFire;

        if(multipleFire) 
        {
            buttonFireRateText.text = "III";
        } 
        else 
        {
            buttonFireRateText.text = "I";
        }
    }

    public void Shoot()
    {

        //RaycastHit give info about object that our ray is hit
        RaycastHit raycastHit;

        //если мы кудато попали, то:
        if(
            Physics.Raycast(

            //откуда идет выстрел, начальная точка
            fpsCamera.transform.position,
            
            //в каком направлении выстрел (вперед)
            fpsCamera.transform.forward, 

            //где сохранить инфу о выстреле и попдании (в переменную raycastHit)
            out raycastHit, 

            //как далеко будет доставать выстрел
            range))

            {
                SetDamage(raycastHit);
            }
    }

    private void SetDamage(RaycastHit raycastHit)
    {        
        Target targetScript = raycastHit.transform.GetComponent<Target>();

        if(targetScript != null)
        {
            Debug.Log(raycastHit.transform.name);
            targetScript.GetDamage(damage);
        }

        if(raycastHit.rigidbody != null)
        {
            raycastHit.rigidbody.AddForce(raycastHit.normal * impuctForce);
        }

        GameObject impuctBullety = Instantiate(impact, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
        //устанавливаю иерархию в Gun
        impuctBullety.transform.SetParent(this.transform);

        Destroy(impuctBullety, 1.5f);
    }

    
    // Update is called once per frame
    void Update()
    {
        PlayMuzzleEffect();
        
    }

    private void PlayMuzzleEffect()
    {
    
        
        /*{
            muzzleEffect.Play();
        }
        else 
        {
            muzzleEffect.Stop();
        }*/
    }
}
