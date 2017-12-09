using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Missle : MonoBehaviour {

    public float rotateSpeed = 200f;
    public float missleSpeed = 5f;
    public float missleHealth = 30f;
    private bool played;


    public ParticleSystem explosion;
    private Transform Target;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
        played = false;
         Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector2 direction = (Vector2)Target.position - rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * missleSpeed;
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            if (played == false)
            {             
                Instantiate(explosion, transform.position, transform.rotation);
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                played = true;
            }
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 2);
        }
        if(collider.CompareTag("Laser"))
        {
            missleHealth -= collider.gameObject.GetComponent<Laser>().laserDamage;
            if(missleHealth <= 0)
            {
                if(played == false)
                {
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.Play();
                    Instantiate(explosion, transform.position, transform.rotation);
                    played = true;
                }
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject,2);
            }
        }
    }

}
