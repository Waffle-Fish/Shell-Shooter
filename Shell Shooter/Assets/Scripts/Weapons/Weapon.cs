using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Damage per hit or Damage per second
    protected float Damage;
    // Time between consecutive uses of this attack
    protected float Cooldown;

    abstract public void StartAttack();

    abstract public void StopAttack();

}
