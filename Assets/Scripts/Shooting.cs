using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Rigidbody2D rb;
    public GameObject laser;
    public float laserSpeed = 5f;  
    public float fireRate = 0.6f;
    public float staticFireRate = 0.6f;

    // Use this for initialization
    void Start () {
          rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(fireRate > 0)
        {
            fireRate -= Time.deltaTime;
        }
        if(fireRate <= 0)
        {
            if (Input.GetMouseButton(0))
            {                
                laser.GetComponent<AudioSource>().Play();
                Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (Vector2)((worldMousePos - transform.position));
                direction.Normalize();

                float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                GameObject bullet = (GameObject)Instantiate(laser, transform.position, transform.rotation);
                bullet.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * laserSpeed * Time.deltaTime;
                fireRate = staticFireRate;
            }
        }
    }
}
