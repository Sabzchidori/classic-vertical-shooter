using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : PoolObject
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

    public override PoolObject ResetProps()
    {
        return this;
    }

    public override int GetPoolObjectType() => (int) PoolObjectTypes.Shot;
}
