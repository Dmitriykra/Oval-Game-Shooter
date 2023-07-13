using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float damageRate = 25f;
    [SerializeField] float playerH = 100f;
    public bool isEnemyTouch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isAttack", true);
            isEnemyTouch = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isAttack", true);
            isEnemyTouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isAttack", false);
        isEnemyTouch = false;
    }
}
