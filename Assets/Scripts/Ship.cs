using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

public class Ship : Pool.Consumer
{
    public float speed;

    public Vector3 initialPosition;

    public float screenBoundary;

    public Shot shot;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var translationAmount = speed * Time.deltaTime;
        if (Input.GetKey("right"))
        {
            transform.Translate(translationAmount, 0, 0);
        }
        else if (Input.GetKey("left"))
        {
            transform.Translate(-translationAmount, 0, 0);
        }
        if (Input.GetKeyDown("space"))
        {
            Consume<Shot>(new Vector3(transform.position.x,
                transform.position.y,
                0.5f));
        }
        if (transform.position.x > screenBoundary)
        {
            transform.position =
                new Vector3(screenBoundary,
                    transform.position.y,
                    transform.position.z);
        }
        else if (transform.position.x < -screenBoundary)
        {
            transform.position =
                new Vector3(-screenBoundary,
                    transform.position.y,
                    transform.position.z);
        }
    }
}
