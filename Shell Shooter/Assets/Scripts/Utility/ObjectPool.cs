using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private int maxObjectCount;
    [SerializeField]
    private Transform newParent;
    
    public GameObject objectToCopy;

    public List<GameObject> objectPool = new();

    private void Awake() {
        GameObject temp;
        Transform parent = (newParent) ? newParent : transform;
        for (int i = 0; i < maxObjectCount; i++) {
            temp = Instantiate(objectToCopy, parent);
            temp.SetActive(false);
            objectPool.Add(temp);
        }
    }

    public GameObject GetObject() {
        for(int i = 0; i < maxObjectCount; i++) {
            if(!objectPool[i].activeInHierarchy) return objectPool[i];
        }
        return null;
    }
}
