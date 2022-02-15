using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollideWithMachine : MonoBehaviour
{
    [Tooltip("0 > Head | 1 > Chest | 2 > Arm | 3 > Leg")] [Range(0, 3)] public int Type;
    public GameObject Modele;


    // Start is called before the first frame update
    void Start()
    {
        Modele = FindObjectOfType<GeneratesModel>().gameObject ;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<LifeTime>().holded == true) {
            string tagCollide = other.gameObject.tag;
            switch (Type)
            {
                case 3: //Leg
                    if (tagCollide == "Leg" && Modele.GetComponent<GeneratesModel>().ConstructLeg1 == null)
                    {
                        Modele.GetComponent<GeneratesModel>().ConstructLeg1 = GetComponent<Renderer>().sharedMaterial;
                    }
                    else
                    {
                        if (tagCollide == "Leg" && Modele.GetComponent<GeneratesModel>().ConstructLeg1 != null && Modele.GetComponent<GeneratesModel>().ConstructLeg2 == null)
                        {
                            Modele.GetComponent<GeneratesModel>().ConstructLeg2 = GetComponent<Renderer>().sharedMaterial;
                        }
                    }
                    break;
                case 2://Arm
                    if (tagCollide == "Arm" && Modele.GetComponent<GeneratesModel>().ConstructArm1 == null)
                    {
                        Modele.GetComponent<GeneratesModel>().ConstructArm1 = GetComponent<Renderer>().sharedMaterial;
                    }
                    else
                    {
                        if (tagCollide == "Arm" && Modele.GetComponent<GeneratesModel>().ConstructArm1 != null && Modele.GetComponent<GeneratesModel>().ConstructArm2 == null)
                        {
                            Modele.GetComponent<GeneratesModel>().ConstructArm2 = GetComponent<Renderer>().sharedMaterial;
                        }
                    }
                    break;
                case 1: //Chest
                    if (tagCollide == "Chest" && Modele.GetComponent<GeneratesModel>().ConstructChest == null)
                    {
                        Modele.GetComponent<GeneratesModel>().ConstructChest = GetComponent<Renderer>().sharedMaterial;
                    }
                    break;
                case 0://Head
                    if (tagCollide == "Head" && Modele.GetComponent<GeneratesModel>().ConstructHead == null)
                    {
                        Modele.GetComponent<GeneratesModel>().ConstructHead = GetComponent<Renderer>().sharedMaterial;
                    }
                    break;

            }
            if (tagCollide == "Leg" || tagCollide == "Arm" || tagCollide == "Head" || tagCollide == "Chest" || tagCollide == "Bin" || tagCollide == "Recycle")
            {
                GetComponent<LifeTime>().holded = false;
                GetComponentInParent<Holder>().holded = null;
                GetComponentInParent<Holder>().holdPossible = true;
                Destroy(this.gameObject, 0.75f);
            }
            
        } 
    }
}
