using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public bool holdPossible;
    public GameObject holded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && holdPossible && holded != null)
        {
            holded.GetComponent<LifeTime>().holded = true;
            holded.transform.SetParent(transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Parts")
        {
            holdPossible = true;
            holded = other.gameObject;
        }
        if (other.gameObject.tag == "Recycle")
        {
            FindObjectOfType<GeneratesModel>().gameObject.GetComponent<GeneratesModel>().reset();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Parts")
        {
            holdPossible = false;
            holded = null;
        }
    }
}
