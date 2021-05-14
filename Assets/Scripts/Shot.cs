using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;

public class Shot : Pool.Object
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        Push();
    }

    public override bool ShouldBePushed()
    {
        return transform.position.y > 6.0f;
    }

    public override Pool.Object ResetProps()
    {
        return this;
    }
}
