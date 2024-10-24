using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PeaShooter : Weapon
{
    [SerializeField]
    [Tooltip("Time between projectiles")]
    float cooldown;
    [SerializeField]
    Vector2 spawnOffset;
    [SerializeField]
    GameObject projectile;

    // NetworkObjectPool projectiles;
    ObjectPool projectiles;
    float timer = 0f;
    bool IsFiring = false;

    private void Awake() {
        // projectiles = NetworkObjectPool.Singleton;
        projectiles = GetComponent<ObjectPool>();
    }

    private void Update() {
        if (!IsFiring) return;
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            timer = cooldown;
            // NetworkObject p = projectiles.GetNetworkObject(projectile, transform.position + (Vector3)spawnOffset, Quaternion.identity);
            GameObject p = projectiles.GetObject();
            p.SetActive(true);
            p.transform.position = transform.position + (Vector3)spawnOffset;
        }
    }

    public override void StartAttack()
    {
        IsFiring = true;
    }

    public override void StopAttack()
    {
        IsFiring = false;
        timer = 0f;
    }
}
