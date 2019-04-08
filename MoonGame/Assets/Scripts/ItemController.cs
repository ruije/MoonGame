using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    public bool invbool; //if true this object is able to go in inventory
    public bool openable; //object can be opened if true
    public bool closeable; //object can be closed if true
    public bool locked; //object is locked if true

    public GameObject itemNeeded; //item that player uses to interact with this object

    public Animation curAnim;

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
}
