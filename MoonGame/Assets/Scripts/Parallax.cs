using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector2 cameraShift)
    {
        
        Camera.main.transform.Translate(cameraShift * Time.deltaTime);
        
        foreach (Transform child in transform)
        {
            // related to distance.
            float keepUp = child.position.z;
            if (keepUp < 0)
            {
                keepUp = 0;
            }
            else if (keepUp > 1)
            {
                keepUp = 1;
            }
            if (cameraShift.y == 0) //just in case
            {
                Vector3 backgroundShift = cameraShift * keepUp;
                child.Translate(backgroundShift);
            }
        }
    }
}
