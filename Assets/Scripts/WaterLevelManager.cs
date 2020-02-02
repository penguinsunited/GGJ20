using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterLevelManager : MonoBehaviour
{

    Text waterLevelText;
    float waterLevel = 0;
    float drownSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        waterLevelText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            drownSpeed += Time.deltaTime;
            waterLevel += drownSpeed * 100;
            waterLevelText.text = ((int)waterLevel).ToString("000");
        }
    }
}
