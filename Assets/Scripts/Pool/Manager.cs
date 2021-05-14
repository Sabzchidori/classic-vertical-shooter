using System;
using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Pool
{
    public class Manager : MonoBehaviour
    {
        private Manager _instance;

        public List<Config> poolConfig;

        private static Dictionary<ObjectTypes, Producer<Object>>
            producers = new Dictionary<ObjectTypes, Producer<Object>>();

        public static Element Pull<Element>(ObjectTypes type, Vector3 position)
            where Element : Object
        {
            var handler = producers[type];
            if (handler != null)
            {
                return handler.Pull(position) as Element;
            }
            throw new InvalidObjectType(type);
        }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy (gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad (gameObject);
            Initialize();
        }

        private void Initialize()
        {
            foreach (Config config in poolConfig)
            {
                var (objectType, size, position) = config;
                Manager.producers[objectType].Initialize(size, position);
            }
        }

        public static void AddProducer(Object @object)
        {
            var type = @object.poolObjectType;
            if (!Manager.producers.ContainsKey(type))
            {
                Manager.producers.Add(type, new Producer<Object>(@object));
            }
        }
    }
}
