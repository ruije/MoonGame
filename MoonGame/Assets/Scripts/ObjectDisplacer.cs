using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectDisplacer : MonoBehaviour {

    public KeyCode pressLeft;

    public KeyCode pressRight;

    public float reducer = 1.0f;

    //this code will be applied to all sprites on the Moon's surface
    //EXCEPT for the player.
    public Sprite curSprite;
    public int coins = 0;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left"))
        {
            //transform.Rotate(0, 0, 1 * -10 * Time.deltaTime);
            transform.Translate((float) Math.Cos(Time.deltaTime) / reducer, (float) Math.Sin(Time.deltaTime) / reducer, 0);
        }
        if (Input.GetKey("right"))
        {
            //transform.Rotate(0, 0, 1 * 10 * Time.deltaTime);
            transform.Translate((float)Math.Cos(Time.deltaTime) / -reducer, (float)Math.Sin(Time.deltaTime) / reducer, 0);
        }
        
        }
}
