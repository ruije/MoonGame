﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

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
}
