using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[8];
    public Button[] InventoryButtons = new Button[8];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(GameObject item)
    {
        bool isAdd = false;
        //locate the first free slot
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                //GUI
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
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

    //probably need a RemoveItem function
    public void RemoveItem(GameObject item)
    {
        //locate the item
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                inventory[i] = null;
                //GUI - unity will replace it with the default
                InventoryButtons[i].image.overrideSprite = null;
                Debug.Log("Remove successful!");
                break;
            }
        }
    }

    public bool FindItem(GameObject item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                return true;
            }
        }
        //if the iventory is full but does not contain the item
        return false;
    }
}
