using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shmup.Core
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabs = new List<GameObject>();

        private Dictionary<string, List<GameObject>> _poolDictionary = new Dictionary<string, List<GameObject>>();

        private void Start()
        {
            foreach (GameObject prefab in prefabs)
            {
                string name = prefab.name;
                _poolDictionary.Add(name, new List<GameObject>());
            }
        }

        public GameObject PoolObject(string prefabName)
        {
            List<GameObject> objs = _poolDictionary[prefabName];

            if (objs != null)
            {
                foreach (GameObject g in objs)
                {
                    if (!g.activeInHierarchy)
                        return g;
                }

                foreach (GameObject prefab in prefabs)
                {
                    if (prefab.name == prefabName)
                    {
                        GameObject instance = Instantiate<GameObject>(prefab);
                        instance.SetActive(false);
                        _poolDictionary[prefabName].Add(instance);
                        return instance;
                    }
                }
            }

            return null;
        }
    }
}
