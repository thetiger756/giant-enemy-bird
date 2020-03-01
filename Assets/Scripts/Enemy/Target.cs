using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float startingHealth = 20f;
    public float health = 50f;

    [SerializeField]
    private float deathDelay = 5f;

    public AudioSource soundSource;
    public AudioClip stunSound;

    private void Start()
    {
        StartCoroutine(Stun());
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    IEnumerator Stun()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);

            if (health <= 0f)
            {
                GetComponent<GuardMovement>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;

                soundSource.clip = stunSound;
                soundSource.Play();

                yield return new WaitForSeconds(deathDelay);

                health = startingHealth;

                GetComponent<GuardMovement>().enabled = true;
                GetComponent<NavMeshAgent>().enabled = true;
            }
        }
    }
}
