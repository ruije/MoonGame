using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    //Code makes the player sprite face the direction of
    //the most recent directional button press.

    public float speed;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get user input to determine which way the sprite should face
        speed = Input.GetAxis("Horizontal"); //does not exist apparently...

        if (speed != 0f)
        {
            //Player starts facing right.
            //When its Scale.X value is negative it will face left instead.
            //The signs for Scale.X correspond to directions of the facing direction.
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(transform.localScale.x) * Mathf.Sign(speed);
            transform.localScale = localScale;
        }

        
    }

    
}
