using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public List<GameObject> AllPrefab;
    public int nbOfGenerate;
    public float BorneMX;
    public float BornePX;
    public float BorneMZ;
    public float BornePZ;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Poping", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Poping()
    {
        GameObject pop;
        Vector3 randomPos;

            pop = Instantiate(AllPrefab[Random.Range(0, 3)]);
            randomPos = new Vector3(Random.Range(BorneMX, BornePX), -8f, Random.Range(BorneMZ, BornePZ));
            randomPos.x += transform.localPosition.x;
            randomPos.z
                += transform.localPosition.z;
            pop.transform.localPosition = randomPos;
    }
}
