using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float rotationSpeed = 200.0f;
    public float movementSpeed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
    }
    
    void OnTriggerStay(Collider col)
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("You are interacting with this object");
        }
    }
}
