using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpeedPowerUp : MonoBehaviour {

    public GameObject pickupEffect;
    public float multiplier=2f;
    public float duration = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        Shooting speed = player.GetComponent<Shooting>();
        speed.staticFireRate /= 2f;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        speed.staticFireRate *= multiplier;

        Destroy(gameObject);
    }

}
