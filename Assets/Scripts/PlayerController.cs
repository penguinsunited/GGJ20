using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;
    private int count;
    private int finalCount = 9;
    
    public int Count { get { return count;}}
    public int FinalCount { get { return finalCount;}}

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Crack"))
        {
            other.gameObject.SetActive (false);
            count = count +1;
        }

    }
}
