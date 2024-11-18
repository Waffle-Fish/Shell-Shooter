using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private int maxObjectCount;
    public Transform NewParent;
    public GameObject objectToCopy;
    public List<GameObject> objectPool = new();

    private void Awake() {
        GameObject temp;
        // Transform parent = (newParent) ? newParent : transform;
        for (int i = 0; i < maxObjectCount; i++) {
            temp = Instantiate(objectToCopy);
            temp.SetActive(false);
            objectPool.Add(temp);
        }
        NewParent = GameObject.FindWithTag("EnemyProjectileDump").transform;
    }

    private void Start() {
        if (NewParent) {
            foreach (var item in objectPool)
            {
                item.transform.parent = NewParent;
            }
        }
    }

    public GameObject GetObject() {
        for(int i = 0; i < maxObjectCount; i++) {
            if(!objectPool[i].activeInHierarchy) return objectPool[i];
        }
        return null;
    }
}
