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
    public int velocity;
    public int adjuster;
    GameObject[] waterObject;
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
        velocity = 10;
        adjuster = 2000;
        waterLevelText = GetComponent<Text>();
        InvokeRepeating("OutputWaterSpeed", 1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 temp;
        cracks = CalculateCracks();
        drownSpeed = speed * cracks;
        waterLevel += drownSpeed * velocity;
        waterLevelText.text = ((int)waterLevel).ToString("000");
        waterObject = GameObject.FindGameObjectsWithTag("Water");
        temp = waterObject[0].transform.position;
        temp.y = waterLevel / adjuster;
        waterObject[0].transform.position = temp;
    }
}

