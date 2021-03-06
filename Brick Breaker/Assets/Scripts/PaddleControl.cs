﻿using System.Collections;
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
        if (Application.platform == RuntimePlatform.Android)
        {
            transform.Translate(Input.acceleration.x, 0, 0);
        }
        else
        {
            if (Input.GetKey(moveL))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-8, 0);
            }
            if (Input.GetKey(moveR))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(8, 0);
            }
            if ((!Input.GetKey(moveL)) && (!Input.GetKey(moveR)))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        } 
        
        if(transform.position.x > 12.5)
        {
            transform.position = new Vector2(12.5f,transform.position.y);
        }
        if (transform.position.x < -12.5)
        {
            transform.position = new Vector2(-12.5f, transform.position.y);
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
            ballr.velocity = new Vector2(ballr.velocity.x * 2, ballr.velocity.y * 2);    
        }
        if (other.gameObject.CompareTag("slowball"))
        {
            ballr.velocity = new Vector2(ballr.velocity.x * 0.5f, ballr.velocity.y * 0.5f);
        }
    }

}
