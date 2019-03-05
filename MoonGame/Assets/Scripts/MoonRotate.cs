using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotate : MonoBehaviour {
    //Rotates the Moon (and objects upon it) to give the impression
    //that the player is moving.

    public KeyCode pressLeft;

	public KeyCode pressRight;

	public Sprite moonSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, 0, 5 * -10 * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 0, 5 * 10 * Time.deltaTime);
        }
    }
}
