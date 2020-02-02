using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TimeManager
{

    static int minutes = 3;
    static float seconds = 0f;
    
    static public float timeLeft = minutes * 60;
    static public bool isTimeUp = false;
    
    public static void DisplayTime(Text timeDisplay)
    {
        if (timeLeft <= 0f)
        {
            Debug.Log("制限時間終了");
            isTimeUp = true;
            return;
        }
        minutes = (int)timeLeft / 60;
        seconds = timeLeft - minutes * 60;

        timeDisplay.text = minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
    }
}
