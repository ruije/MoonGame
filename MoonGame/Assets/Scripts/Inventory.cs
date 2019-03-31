using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[4];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addItem(GameObject item)
    {
        bool isAdd = false;
        //locate the first free slot
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                isAdd = true;
                item.SendMessage("DoInteraction");
                Debug.Log("Pickup successful!");
                break;
            }
            
        }
        if (!isAdd)
        {
            //inventory full
            Debug.Log("Inventory is already full");
        }
    }
}
