using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBoom : MonoBehaviour
{
    public GameObject cannonBall;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "cannonball")
        {
            Destroy(gameObject);
        }
    }
}
