using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeText;
    
    void Awake()
    {
        timeText = GameObject.FindWithTag("Canvas").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeManager.timeLeft -= Time.deltaTime;
        TimeManager.DisplayTime(timeText);
        if (TimeManager.isTimeUp)
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
        }
    }
}
