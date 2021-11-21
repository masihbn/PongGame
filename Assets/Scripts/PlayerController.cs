using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1;

    [Range(0.0f, 50.0f)]
    public float speed = 5;

    public Rigidbody2D rb;
    public Vector3 startPos;
    public int lives = 3;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movement;
        movement = Input.GetAxisRaw("Vertical");

        if (isPlayer1)
            rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        else
            rb.velocity = new Vector2(rb.velocity.x, movement * -speed);
    }
}
