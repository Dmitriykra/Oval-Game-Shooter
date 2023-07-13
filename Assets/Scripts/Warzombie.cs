using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Warzombie : MonoBehaviour
{
    [SerializeField] Rigidbody[] rbs;
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] float damageRate = 25f;
    [SerializeField] ZombieAttack zombieAttack;

    bool isEnemyAlive;
    CapsuleCollider capsule;

    // Start is called before the first frame update
    void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
        DesableRagdoll();

        //mainCamera = FindObjectOfType<Camera>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if(gameObject.activeInHierarchy)
        {
            isEnemyAlive = true;
        }
    }

    // Update is called once per frame
    
    void DesableRagdoll()
    {
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic = true;
            
        }

        animator.enabled = true;
        navMeshAgent.enabled = true;
        isEnemyAlive = true;

        StartCoroutine(FindPathToPlayer());
    }

    IEnumerator FindPathToPlayer()
    {
        while(true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 3.0f));
            Debug.Log("StartCorutine");
            if (isEnemyAlive && player != null && navMeshAgent != null)
            {
                navMeshAgent.SetDestination(player.position);
            }
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EnableRagdoll();
        }
    }

    public void EnableRagdoll()
    {
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
        }

        animator.enabled = false;
        navMeshAgent.enabled = false;
        isEnemyAlive = false;
        capsule.enabled = false;
    }

    public void Attack()
    {
        if (playerHealth != null && zombieAttack.isEnemyTouch)
        {
            playerHealth.TakeDamage(damageRate);

        }
    }
}
