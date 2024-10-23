using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class PlayerAttack : NetworkBehaviour
{
    private InputManager inputManager;
    private List<Weapon> weapons = new();
    private bool toggleAttack = false;

    private void Awake() {
        inputManager = GetComponent<InputManager>();
        GetComponentsInChildren<Weapon>(true, weapons);
    }

    private void Update() {
        ProcessBasicAttack();
    }

    private void ProcessBasicAttack()
    {
        if (!IsOwner || weapons.Count == 0) return;
        if(inputManager.IsBasicAttackPressed()) {
            toggleAttack = !toggleAttack;
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
}
