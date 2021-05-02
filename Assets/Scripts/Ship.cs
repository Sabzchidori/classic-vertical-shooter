using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;
    public Vector3 initialPosition;
    public float screenBoundary;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var translationAmount = speed * Time.deltaTime;
        if(Input.GetKey("right")) {
            transform.Translate(translationAmount, 0, 0);
        }
        else if (Input.GetKey("left")) {
            transform.Translate(-translationAmount, 0, 0);
        }
        if(transform.position.x > screenBoundary) {
            transform.position = new Vector3(screenBoundary, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -screenBoundary) {
            transform.position = new Vector3(-screenBoundary, transform.position.y, transform.position.z);
        }
    }
}
