using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Guard")
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(10);
        }

        else if (other.tag == "Macguffin")
        {
            GameObject.Find("GameController Holder").GetComponent<GameController>().hasMacguffin = true;
        }
    }
}
