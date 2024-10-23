using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Weapon
{
    ParticleSystem ps;
    private void Awake() {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    public override void ProcessAttack()
    {
        ps.Play();
    }

    public override void StopAttack()
    {
        ps.Stop();
    }
}
