using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Wally : MonoBehaviour
{
    [SerializeField][Range(1f, 10f)] float moveSpeed = 5f;

    Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Start()
    {
        
    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * moveSpeed;
        float zSpeed = zInput * moveSpeed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        rb.velocity = newVelocity;
    }
}
