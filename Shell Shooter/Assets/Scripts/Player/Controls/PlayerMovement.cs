using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce;
    PlayerControls playerControls;
    Rigidbody2D rb;


    // Start is called before the first frame update
    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    private void ProcessMovement() {
        rb.AddForce(GetInput() * moveForce, ForceMode2D.Force);
    }

    private Vector2 GetInput() {
        return new Vector2(playerControls.Movement.Horizontal.ReadValue<float>(), playerControls.Movement.Vertical.ReadValue<float>()).normalized;
    }
}
