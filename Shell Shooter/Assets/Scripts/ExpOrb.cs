using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Player")) return;
        gameObject.SetActive(false);
        // Player picks up orb
    }
}
