using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ObjectPool : NetworkBehaviour
{
    [SerializeField]
    private int maxObjectCount;
    public GameObject objectToCopy;
    public List<GameObject> objectPool = new();

    private void Awake() {
        for (int i = 0; i < maxObjectCount; i++) {
            GameObject temp = Instantiate(NetworkManager.GetNetworkPrefabOverride(objectToCopy));
            var tempNetworkObject = temp.GetComponent<NetworkObject>();
            tempNetworkObject.Spawn();
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
