using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float vitesse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = new Vector3(0,0,0);
        if (Input.GetAxis("Horizontal") != 0)
        {
            speed.x = Input.GetAxis("Horizontal") * vitesse;
            GetComponent<Rigidbody>().velocity = speed;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            speed.z = Input.GetAxis("Vertical") * vitesse;
            GetComponent<Rigidbody>().velocity = speed;
        }
        if((Input.GetAxis("Horizontal") == 0) && (Input.GetAxis("Vertical") == 0))
        {
            speed = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = speed;
        }
        if (GetComponent<Rigidbody>().velocity != new Vector3(0, 0, 0))
        {
            
            Vector3 target = (transform.position + (GetComponent<Rigidbody>().velocity * 10)) ;
            transform.LookAt(target);
        }
    }

}
