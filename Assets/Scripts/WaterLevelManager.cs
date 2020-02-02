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
    void Start()
    {
        waterLevel = 0;
        speed = Time.deltaTime;
        cracks = 0;
        drownSpeed = 0f;
        waterLevelText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            cracks += 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (cracks > 0)
            {
                cracks -= 1;
            }
        }
        drownSpeed = speed * cracks;
        waterLevel += drownSpeed * 10;
        waterLevelText.text = ((int)waterLevel).ToString("000");
    }
}