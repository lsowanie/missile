using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movingSpeed = 4f;

    void Update ()
    {

        if (Input.GetKey("w"))
        {
            if(transform.position.y < 8.9f)
            {
                transform.position += Vector3.up * movingSpeed * Time.deltaTime;
            }
                
        }

        if (Input.GetKey("a"))
        {
            if (transform.position.x > -9.3f)
            {
                transform.eulerAngles = new Vector3(0, 0, 12);
                transform.position += Vector3.left * movingSpeed * Time.deltaTime;
            }
               
        }

        if (Input.GetKey("d"))
        {
            if (transform.position.x < 9.3f)
            {
                transform.eulerAngles = new Vector3(0, 0, -12);
                transform.position += Vector3.right * movingSpeed * Time.deltaTime;
            }                
        }     

        if (Input.GetKey("s"))
        {
            if (transform.position.y > -8.9f)
            {
                transform.position += Vector3.down * movingSpeed * Time.deltaTime;
            }
                
        }    
     } 
}
