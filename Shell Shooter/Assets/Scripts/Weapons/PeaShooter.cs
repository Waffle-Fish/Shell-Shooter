using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class PeaShooter : Weapon
{
    [SerializeField]
    [Tooltip("Time between projectiles")]
    float cooldown;
    [SerializeField]
    Vector2 spawnOffset;

    ObjectPool projectiles;
    float timer = 0f;
    bool IsFiring = false;

    private void Awake() {
        projectiles = GetComponent<ObjectPool>();
    }

    private void Update() {
        if (!IsFiring) return;
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            timer = cooldown;
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
