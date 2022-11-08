using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody myRigidbody;
    Vector3 moveforce = Vector3.zero;
    Vector3 myRotation = Vector3.zero;
    float Speed = 15f;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveforce.x = Input.GetAxis("Horizontal");
        moveforce.z = Input.GetAxis("Vertical");

        myRigidbody.AddRelativeForce(moveforce * Time.deltaTime * Speed, ForceMode.VelocityChange);

        //myRotation.y += moveforce.x * moveforce.z;
        myRotation.y += Input.GetAxis("Mouse X");
        myRigidbody.rotation = (Quaternion.Euler(myRotation));
    }
        
}
