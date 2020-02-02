using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaterLevelManager : MonoBehaviour
{
    Text waterLevelText;
    float waterLevel = 0;
    float speed;
    int cracks;
    float drownSpeed;
    // Start is called before the first frame update

    public int CalculateCracks()
    {
        int newCrackNumber = 0;

        GameObject[] repairPipes;
        repairPipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in repairPipes)
        {
            if (pipe.GetComponent<Pipes>().IsBurst == true)
            {
                newCrackNumber = newCrackNumber + 1;
            }
        }
        return newCrackNumber;
    }

    void Start()
    {
        waterLevel = 0;
        speed = Time.deltaTime;
        cracks = 0;
        drownSpeed = 0f;
        waterLevelText = GetComponent<Text>();
        InvokeRepeating("OutputWaterSpeed", 1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        cracks = CalculateCracks();
        drownSpeed = speed * cracks;
        waterLevel += drownSpeed * 10;
        waterLevelText.text = ((int)waterLevel).ToString("000");
    }
}

