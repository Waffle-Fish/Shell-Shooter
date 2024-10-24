using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float MaxHp;
    float currentHp;

    private void Start() {
        currentHp = MaxHp;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.CompareTag("EnemyProjectiles")) {
            TakeDamage(other.GetComponent<BasicProjectileBehavior>().DamageVal);
        }
    }

    public void TakeDamage(float val) {
        currentHp -= val;
        if (currentHp < 0) {
            ProcessDeath();
        }
    }

    private void ProcessDeath()
    {
        Debug.Log(gameObject.name + " has died!");
        gameObject.SetActive(false);
    }
}