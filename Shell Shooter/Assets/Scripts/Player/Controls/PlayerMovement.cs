using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce;

    private InputManager inputManager;
    private Rigidbody2D rb2D;

    private void Awake() {
        inputManager = InputManager.Instance;
        rb2D = GetComponent<Rigidbody2D>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        rb2D.AddForce(moveForce * inputManager.GetPlayerMovement());
    }
}
