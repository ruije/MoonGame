using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

    public bool invbool; //if true this object is able to go in inventory
    public bool openable; //object can be opened if true
    public bool locked; //object is locked if true
    public bool isNPC;

    public GameObject itemNeeded; //item that player uses to interact with this object

    public Animation curAnim;

    public string message; //what the object says
    public Text speachBubble; //where the speach appears

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoInteraction()
    {
        //code to be added for inventory system
        //object will disappear but not be destroyed
        gameObject.SetActive(false);
    }

    public void Open()
    {
        curAnim.Play();
    }

    public void Speak()
    {
        Debug.Log(message);
        speachBubble.text = message;
    }
}
