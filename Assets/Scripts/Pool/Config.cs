using System;
using UnityEngine;

namespace Pool
{
    [Serializable]
    public struct Config
    {
        public ObjectTypes objectType;

        public int size;

        public Vector3 position;

        public void Deconstruct(
            out ObjectTypes objectType,
            out int size,
            out Vector3 position
        )
        {
            objectType = this.objectType;
            size = this.size;
            position = this.position;
        }
    }
}
