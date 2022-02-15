using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
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
        else
        {
            TimerBase -= Time.deltaTime;
            text.text = (Mathf.RoundToInt(TimerBase)).ToString();
        }
    }
}
