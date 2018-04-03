using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour {

    public KeyCode moveL;
    public KeyCode moveR;
    public Rigidbody2D ballr;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(moveL))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-8, 0);
        }
        if (Input.GetKey(moveR))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(8, 0);
        }
        if( (!Input.GetKey(moveL)) && (!Input.GetKey(moveR)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("expand"))
        {
            GetComponent<Transform>().localScale = new Vector2(3, 1f);
        }
        if (other.gameObject.CompareTag("shrink"))
        {
            GetComponent<Transform>().localScale = new Vector2(1, 1f);
        }
        if(other.gameObject.CompareTag("fastball"))
        {
            ballr.AddForce(new Vector2(10,10));    
        }
        if (other.gameObject.CompareTag("slowball"))
        {
            ballr.AddForce(new Vector2(3, 3));
        }
    }

}
