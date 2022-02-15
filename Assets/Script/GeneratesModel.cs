using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratesModel : MonoBehaviour
{
    [Header("Random")]
    public List<GameObject> Heads;
    public List<GameObject> Chests;
    public List<GameObject> Arms;
    public List<GameObject> Legs;
    [Header("Placement")]
    public GameObject headParent;
    public GameObject chestParent;
    public GameObject armParent1;
    public GameObject armParent2;
    public GameObject legParent1;
    public GameObject legParent2;
    [Header("Modele")]
    public GameObject modelHead;
    public GameObject modelChest;
    public GameObject modelArm1;
    public GameObject modelArm2;
    public GameObject modelLeg1;
    public GameObject modelLeg2;
    [Header("Construct")]
    public Material ConstructHead;
    public Material ConstructChest;
    public Material ConstructArm1;
    public Material ConstructArm2;
    public Material ConstructLeg1;
    public Material ConstructLeg2;
    [Header("Bravo")]
    public ParticleSystem NS1;
    public ParticleSystem NS2;

    // Start is called before the first frame update
    void Start()
    {
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (ConstructArm1 != null && ConstructArm2 != null && ConstructLeg1 != null && ConstructLeg2 != null && ConstructChest != null && ConstructHead != null)
        {
            check();
        }
    }

    public void generate()
    {

        modelHead = Instantiate(Heads[Random.Range(0, 3)], headParent.transform);
        modelChest = Instantiate(Chests[Random.Range(0, 3)], chestParent.transform);
        modelArm1 = Instantiate(Arms[Random.Range(0, 3)], armParent1.transform);
        modelArm2 = Instantiate(Arms[Random.Range(0, 3)], armParent2.transform);
        modelLeg1 = Instantiate(Legs[Random.Range(0, 3)], legParent1.transform);
        modelLeg2 = Instantiate(Legs[Random.Range(0, 3)], legParent2.transform);

        modelHead.GetComponent<LifeTime>().model = true;
        modelChest.GetComponent<LifeTime>().model = true;
        modelArm1.GetComponent<LifeTime>().model = true;
        modelArm2.GetComponent<LifeTime>().model = true;
        modelLeg1.GetComponent<LifeTime>().model = true;
        modelLeg2.GetComponent<LifeTime>().model = true;
    }

    public void check()
    {
        if  (
            (ConstructHead == modelHead.GetComponent<Renderer>().sharedMaterial) && 
            (ConstructChest == modelChest.GetComponent<Renderer>().sharedMaterial) && 
            (ConstructArm1 == modelArm1.GetComponent<Renderer>().sharedMaterial) &&
            (ConstructArm2 == modelArm2.GetComponent<Renderer>().sharedMaterial) && 
            (ConstructLeg1 == modelLeg1.GetComponent<Renderer>().sharedMaterial) && 
            (ConstructLeg2 == modelLeg2.GetComponent<Renderer>().sharedMaterial)
            ){
            FindObjectOfType<Scorer>().gameObject.GetComponent<Scorer>().Score += 1;
            FindObjectOfType<Timer>().gameObject.GetComponent<Timer>().TimerBase += 30;
            Debug.Log("Bravo");
            NS1.Play();
            NS2.Play();
        }
        else
        {
            Debug.Log("Dommage");
        }
        reset();

    }
    public void reset()
    {
        Destroy(modelHead); Destroy(modelChest); Destroy(modelArm1); Destroy(modelArm2); Destroy(modelLeg1); Destroy(modelLeg2);

        generate();
        ConstructHead = null;
        ConstructChest = null;
        ConstructArm1 = null;
        ConstructArm2 = null;
        ConstructLeg1 = null;
        ConstructLeg2 = null;
    }
}
