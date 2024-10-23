using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class InputManager : NetworkBehaviour
{
    private PlayerControls playerControls;

    private void Awake() {

        playerControls = new();
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable() {
        playerControls.Movement.Enable();
        playerControls.Attack.Enable();
    }

    private void OnDisable() {
        playerControls.Movement.Disable();
        playerControls.Attack.Disable();
    }

    public Vector2 GetPlayerMovement() {
        return playerControls.Movement.Move.ReadValue<Vector2>();
    }

    public bool IsBasicAttackPressed() {
        return playerControls.Attack.BasicAttack.WasPressedThisFrame();
    }

    public bool IsSpecialAttackPressed() {
        return playerControls.Attack.SpecialAttack.WasPressedThisFrame();
    }
}
