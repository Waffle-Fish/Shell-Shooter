using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private List<Weapon> weapons = new();
    private bool toggleAttack = true;

    private void Awake() {
        GetComponentsInChildren<Weapon>(true, weapons);
    }

    private void Update() {
        ProcessBasicAttack();
    }

    private void ProcessBasicAttack()
    {
        if (/*!IsOwner ||*/ weapons.Count == 0) return;
        if (toggleAttack) {
            foreach (Weapon weapon in weapons)
            {
                weapon.StartAttack();
            }
        } else {
            foreach (Weapon weapon in weapons)
            {
                weapon.StopAttack();
            }
        }
    }


}
