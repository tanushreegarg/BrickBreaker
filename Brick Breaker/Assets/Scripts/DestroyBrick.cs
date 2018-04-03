using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour {

    public Transform boomobj;
    public Transform slide_expand;
    public Transform slide_shrink;
    public Transform fastball;
    public Transform slowball;
    public int life=1;
    public int whichpowerup;
    public UIManager ui;
	// Use this for initialization
	void Start () {
		
	}	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        whichpowerup = Random.Range(1, 10);
        if(whichpowerup==1)
        {
            Instantiate(slide_expand,transform.position,slide_expand.rotation);
        }
        if(whichpowerup==2)
        {
            Instantiate(slide_shrink,transform.position,slide_shrink.rotation);
        }
        if(whichpowerup==3)
        {
            Instantiate(fastball, transform.position, fastball.rotation);
        }
        if (whichpowerup == 3)
        {
            Instantiate(slowball, transform.position, slowball.rotation);
        }
        if (life==0)
        {
            //SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if(gameObject.CompareTag("pink"))
            {
                ui.AddScore(10);
            }
            if (gameObject.CompareTag("dblue"))
            {
                ui.AddScore(20);
            }
            if (gameObject.CompareTag("yellow"))
            {
                ui.AddScore(20);
            }
            if (gameObject.CompareTag("red"))
            {
                ui.AddScore(20);
            }
            if (gameObject.CompareTag("lblue"))
            {
                ui.AddScore(10);
            }
            if (gameObject.CompareTag("orange"))
            {
                ui.AddScore(30);
            }
            if (gameObject.CompareTag("sblue"))
            {
                ui.AddScore(40);
            }
            Destroy(gameObject);
            Instantiate(boomobj, transform.position, boomobj.rotation);
        }
        life--;
    }
}
