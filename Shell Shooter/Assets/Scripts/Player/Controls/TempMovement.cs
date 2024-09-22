using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TempMovement : NetworkBehaviour
{
    
    void Update()
    {
        if (!IsOwner) { return; }

        Vector3 moveDir = new(0,0,0);
        if (Input.GetKey(KeyCode.W)) moveDir.y = 1f;
        if (Input.GetKey(KeyCode.S)) moveDir.y = -1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = 1f;

        float moveSpeed = 3f;
        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }
}
