using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Range(0.0f, 50.0f)]
    public float speed;
    public Rigidbody2D rigidbody;
    public EventSystemCustom eventSystem;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Launch();
    }

    public void Launch()
    {
        float minimum = 0.4f, maximum = 0.8f;
        System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);

        float x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1 * (float) rand.NextDouble() * (maximum - minimum) + minimum,
              y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1 * (float) rand.NextDouble() * (maximum - minimum) + minimum;

        rigidbody.velocity = new Vector2(speed * x, speed * y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal")) 
            eventSystem.OnPlayerMissed.Invoke();
    }
}
