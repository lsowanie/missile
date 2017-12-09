using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPowerUp : MonoBehaviour {

    public GameObject pickupEffect;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        HPChecking health = player.GetComponent<HPChecking>();
        health.hp += 1;

        Destroy(gameObject);
    }


}
