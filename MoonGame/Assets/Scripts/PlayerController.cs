using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    //movement variables
    public float movex;
    public float speed;
    public float jumpforce;

    //interactivity variables
    public int coins = 0;
    public GameObject currObj = null;
    public Rigidbody2D rb2d;

    Vector3 startingPosition;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //right key => 1
        //left key => -1
        movex = Input.GetAxis("Horizontal");

        //changes the velocity to match the keypress
        rb2d.velocity = new Vector2(movex * speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
        }
        if (movex != 0f)
        {
            //Player starts facing right.
            //When its Scale.X value is negative it will face left instead.
            //The signs for Scale.X correspond to directions of the facing direction.
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(transform.localScale.x) * Mathf.Sign(movex);
            transform.localScale = localScale;
        }
        if (Input.GetKeyDown(KeyCode.Q) && currObj)
        {
            //Activate some function in the current item's script
            currObj.SendMessage("DoInteraction");
        }
    }

    void OnTriggerEnter2D(Collider2D col) // col is the trigger object we collided with
    {
        if (col.tag == "Coin")
        {
            coins++;
            Destroy(col.gameObject); // remove the coin
        }
        else if (col.tag == "FatalHazard")
        {
            //Add a life counter?
            //Reset position upon "death"
            transform.position = startingPosition;
        }
        //items can be picked up, or otherwise interacted with
        else if (col.tag == "Item")
        {
            currObj = col.gameObject;
            Debug.Log(currObj.name);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Item")
        {
            if (col.tag == currObj.name) {
                currObj = null;
            }
        }
    }
}
