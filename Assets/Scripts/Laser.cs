using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float laserDamage = 10f;

    public Transform laser;
    public Missle missle;

    void Update()
    {
        if(laser.position.x > 10 || laser.position.x < -10 || laser.position.y > 10 || laser.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if(other.CompareTag("Missle"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1);
        }            
        }
    }
