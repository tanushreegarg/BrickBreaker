﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public float speed=5f;    
	// Use this for initialization
	void Start ()
    {
        
	}	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, speed));
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.name=="LeftBorder")||(other.gameObject.name=="RightBorder"))
        {
            Vector2 currentVel = GetComponent<Rigidbody2D>().velocity;

            //GetComponent<Rigidbody2D>().velocity = new Vector2((currentVel.x * -1),(currentVel.y));
        }
        
    }
}