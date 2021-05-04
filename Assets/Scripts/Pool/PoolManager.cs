using System.Collections.Generic;
using UnityEngine;

public class PoolManager<PoolElement> where PoolElement : PoolObject
{
    public Vector3 position;

    public readonly PoolElement poolObject;

    private readonly int type;

    public PoolManager(PoolElement element, Vector3 position)
    {
        this.position = position;
        this.poolObject = element;
        PoolObject.onPush += Push;
        this.type = element.GetPoolObjectType();
    }

    private Stack<PoolElement> pool = new Stack<PoolElement>();

    public PoolElement Pull(Vector3 position)
    {
        if (pool.Count != 0)
        {
            var element = pool.Pop();
            return element.ReadyToPull<PoolElement>(position);
        }
        return UnityEngine
            .Object
            .Instantiate<PoolElement>(poolObject,
            position,
            Quaternion.identity);
    }

    public void Push(PoolObject element)
    {
        if (type == element.GetPoolObjectType()) {
            pool.Push(element.ReadyToPush(position) as PoolElement);
        }
    }
}
