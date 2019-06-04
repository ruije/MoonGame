using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //simple back and forth movement,
    //edges designated by "walls"
    public float speed;
    public Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

    }

    void OnTriggerEnter2D(Collider2D col) // col is the trigger object we collided with
    {
        if (col.tag == "EnemyWall")
        {
            speed *= -1;
        }
    }
}
