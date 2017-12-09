using UnityEngine;
using UnityEngine.UI;

public class HPChecking : MonoBehaviour {

    public Text hp_number;
    public int hp;
    public int max_hp;
    public GameObject gameover;
    public GameObject spawner;
    public GameObject powerup;

    void Start()
    {
        hp_number.text = max_hp.ToString();
    }

    void Update()
    {
        if (hp < 0)
            hp++;
        if(hp>max_hp)
        {
            hp--;
        }
        hp_number.text = hp.ToString();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Missle"))
            {
            hp--;
            hp_number.text = hp.ToString();
            if(hp_number.text == 0.ToString())
            {
                gameover.SetActive(true);
                spawner.SetActive(false);
                powerup.SetActive(false);
            }
        }
    }

}
