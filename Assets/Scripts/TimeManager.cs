using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    Text timeDisplay;
    int minutes = 10;
    float seconds = 0f;
    float timeLimit;
    float oldSeconds;

    // Start is called before the first frame update
    void Start()
    {
        timeLimit = minutes * 60 + seconds;
        oldSeconds = 0f;
        timeDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLimit <= 0f)
        {
            return;
        }
        timeLimit = minutes * 60 + seconds;
        timeLimit -= Time.deltaTime;
        minutes = (int)timeLimit / 60;
        seconds = timeLimit - minutes * 60;

        if ((int)seconds != (int)oldSeconds)
        {
            timeDisplay.text = minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        if (timeLimit <= 0f)
        {
            Debug.Log("制限時間終了");
        }
    }
}
