using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public float speed=5f;
    public UIManager ui;
    public bool timer;
    public bool start = true;
    public GameObject paddle;
    private AudioSource source;
    public AudioClip brick;
    public AudioClip pad;
    public AudioClip die;
    public float Volume;
	// Use this for initialization
	void Start ()
    {

        timer = false;
        source = GetComponent<AudioSource>();
        Volume = PlayerPrefs.GetFloat("EffectsVolume",1);
	}	
	// Update is called once per frame
	void Update ()
    {
        /*if (Input.GetKeyUp(KeyCode.Space))
        {            
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, speed));
            timer = true;
        }
        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;
            

        }*/

        if(start == true)
        {
            transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y + 1f);
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, speed));
                timer = true;
                start = false;
            }
        }
        
            
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.name=="LeftBorder")||(other.gameObject.name=="RightBorder"))
        {
            Vector2 currentVel = GetComponent<Rigidbody2D>().velocity;
            if(currentVel.y <0.5 && currentVel.y > -0.5)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(1/currentVel.x, 10/currentVel.y));
            }

        }
        if(other.gameObject.tag == "Brick")
        {
            source.PlayOneShot(brick,Volume);
        }
        if(other.gameObject.tag == "Paddle")
        {
            source.PlayOneShot(pad,Volume);
        }
                
    }
    void OnTriggerEnter2D(Collider2D bottom)
    {
        if(bottom.gameObject.CompareTag("bottomborder"))
        {
            Debug.Log("Hi");
            ui.DeductLife(1);
            start = true;
            GetComponent<Transform>().position = new Vector2(paddle.transform.position.x, paddle.transform.position.y + 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            source.PlayOneShot(die,Volume);
        }
    }
}

