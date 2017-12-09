using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour {

    public float multiplier = 1.4f;
    public float duration = 2f;
    public GameObject pickupEffect;
    
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

        PlayerController speed = player.GetComponent<PlayerController>();
        Shooting laser = player.GetComponent<Shooting>();

        speed.movingSpeed *= multiplier;
        laser.laserSpeed *= multiplier * 1.5f;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        speed.movingSpeed /= multiplier;
        laser.laserSpeed /= multiplier * 1.5f;

        Destroy(gameObject);
    }

}
