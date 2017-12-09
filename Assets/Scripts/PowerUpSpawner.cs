using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject speed;
    public GameObject shoot_speed;
    public GameObject hp;

    public float minTime = 10f;
    public float maxTime = 20f;

    private float ranX;
    private float ranY;
    private int type;
    private Vector2 ranPos;

    private float currentTime;
    private float spawnTime;

	// Use this for initialization
	void Start () {
        SetRandomTime();
        currentTime = minTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        currentTime += Time.deltaTime;

        if(currentTime >= spawnTime)
        {
            ranX = Random.Range(-10f, 10f);
            ranY = Random.Range(-9f, 9f);
            ranPos = new Vector2(ranX, ranY);

            SpawnObject();
            Debug.Log("Type: " + type);
            SetRandomTime();
        }
	}

    void SpawnObject()
    {
        type = Random.Range(1, 4);
        if (type == 1)
            Instantiate(speed, ranPos, speed.transform.rotation);
        if (type == 2)
            Instantiate(shoot_speed, ranPos, shoot_speed.transform.rotation);
        if (type == 3)
            Instantiate(hp, ranPos,hp.transform.rotation);
        currentTime = minTime;
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime) ;   // Odstęp pomiędzy spawnem
    }
}
