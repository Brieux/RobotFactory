using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    public float TimerBase;
    public TextMeshProUGUI text;
    public int Score;
    public bool isScore;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScore)
        {
            text.text = "Score : " + Score.ToString() + " !";
        }

    }
}
