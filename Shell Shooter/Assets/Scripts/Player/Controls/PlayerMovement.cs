using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D),typeof(InputManager))]
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private float moveForce;

    private InputManager inputManager;
    private Rigidbody2D rb2D;

    private void Awake() 
    {
        rb2D = GetComponent<Rigidbody2D>(); 
        inputManager = GetComponent<InputManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        Move();
    }

    void Move() {
        rb2D.AddForce(moveForce * inputManager.GetPlayerMovement());
    }
}
