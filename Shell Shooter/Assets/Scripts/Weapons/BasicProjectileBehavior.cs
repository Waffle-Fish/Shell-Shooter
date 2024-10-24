using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicProjectileBehavior : MonoBehaviour
{
    public float DamageVal;
    public float MoveForce;
    [Tooltip("How long they stay on the scene before disappearing ")]
    public float Lifetime;
    private float timer = 0f;
    Rigidbody2D rb2D;
    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        rb2D.AddForce(transform.up * MoveForce, ForceMode2D.Impulse);
    }

    private void OnDisable() {
        rb2D.velocity = Vector2.zero;
        timer = Lifetime;
    }

    private void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        gameObject.SetActive(false);
    }
}
