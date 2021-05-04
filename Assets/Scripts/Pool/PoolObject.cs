using System;
using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    public delegate void OnPush(PoolObject poolObject);

    public static event OnPush onPush;

    internal Boolean isAvailable { set; get; }

    public abstract int GetPoolObjectType();

    public abstract PoolObject ResetProps();

    public abstract bool ShouldBePushed();

    public T ReadyToPull<T>(Vector3 position)
        where T : PoolObject
    {
        return this
            .ResetProps()
            .SetAvailability(false)
            .ResetPosition(position) as
        T;
    }

    public PoolObject ReadyToPush(Vector3 position)
    {
        return this.SetAvailability(true).ResetPosition(position);
    }

    private PoolObject ResetPosition(Vector3 position)
    {
        this.isAvailable = false;
        this.transform.position = position;
        return this;
    }

    private PoolObject SetAvailability(Boolean availability)
    {
        this.isAvailable = availability;
        this.gameObject.SetActive(!availability);
        return this;
    }

    public PoolObject Push()
    {
        if (ShouldBePushed() && onPush != null)
        {
            onPush(this);
        }
        return null;
    }
}
