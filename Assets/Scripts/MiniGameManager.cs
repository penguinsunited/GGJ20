using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    PlayerController playerController;
    public Text timeText;
    
    void Awake()
    {
        timeText = GameObject.FindWithTag("Canvas").GetComponentInChildren<Text>();
    }


    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeManager.timeLeft -= Time.deltaTime;
        TimeManager.DisplayTime(timeText);
        if(playerController.Count == playerController.FinalCount)
        {
            SceneManager.LoadScene("Environment");
        }
        if (TimeManager.isTimeUp)
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
        }
    }
}
