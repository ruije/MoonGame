using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //movement variables
    public float movex;
    public float speed;
    public float jumpforce;

    //interactivity variables
    public int coins = 0;
    public ItemController currIOScript = null;
    public Inventory inventory;
    public GameObject currObj = null;
    public Rigidbody2D rb2d;

    private bool isJumping;

    Vector3 startingPosition;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //right key => 1
        //left key => -1
        movex = Input.GetAxis("Horizontal");

        //changes the velocity to match the keypress
        //transforms position
        rb2d.velocity = new Vector2(movex * speed, rb2d.velocity.y);

        
        // localScale;
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
            isJumping = true;
        }

        if (movex != 0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(transform.localScale.x) * Mathf.Sign(movex);
            transform.localScale = localScale;

        }




        if (Input.GetKeyDown(KeyCode.T) && currObj)
        {
            //Check if object is storable
            if (currIOScript.invbool)
            {
                Debug.Log(currObj.name + " is inventory");
                inventory.AddItem(currObj);
                //Activate some function in the current item's script
                //currObj.SendMessage("DoInteraction");
            }

            //Can the object be opened?
            if (currIOScript.openable)
            {
                //Is it locked?
                if (currIOScript.locked)
                {
                    //Does the player have the key?
                    if (inventory.FindItem(currIOScript.itemNeeded))
                    {
                        currIOScript.locked = false;
                        Debug.Log(currObj.name + " is unlocked");
                        //run door animation
                    }
                    else
                    {
                        Debug.Log(currObj.name + " needs a key");
                        //door is unopenable - do nothing
                    }
                }
                else
                {
                    //run door animation
                    Debug.Log(currObj.name + " swings open violently");
                    currIOScript.Open();
                }
            }



        }
    }



    void OnTriggerEnter2D(Collider2D col) // col is the trigger object we collided with
    {
        Debug.Log(col.tag);
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
            //Get script for the object
            currIOScript = currObj.GetComponent<ItemController>();
            Debug.Log(currObj.name);

            //NPC's speak
            if (currIOScript.isNPC)
            {
                //tell it to speak
                currIOScript.Speak();
            }
        }
        if (col.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(col.tag);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if (col.tag == "Item")
        {
            if (col.tag == currObj.name)
            {
                currObj = null;
            }

            //clear NPC's speech
            if (currIOScript.isNPC)
            {
                //tell it to speak
                currIOScript.speachBubble.text = "";
            }
        }
    }

}
