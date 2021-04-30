using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldScroller : MonoBehaviour
{
    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, scrollSpeed * Time.deltaTime, 0);
        if(transform.position.y < -10.0f) {
            transform.Translate(0, 20.48f, 0);
        }
    }
}
