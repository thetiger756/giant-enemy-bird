using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttack : MonoBehaviour
{

    //we make a private serializefield so that we can
    //change the value in the inspector while keeping this private.
    //we also do not initialize it to a value, because we don't
    //want to get confused between the value in the script vs the inspector.
    [SerializeField]
    private float attackDelay = 1.5f;

    public int attackDamage = 20;

    private bool playerInRange;

    GameObject player;
    PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay);

            if (playerInRange)
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        playerHealth.TakeDamage(attackDamage);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
}
