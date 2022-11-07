using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRigidbody = null;
    Animator myAnimator = null;

    Vector3 movePos = Vector3.zero;
    Vector3 myRotation = Vector3.zero;

    float xInput = 0f;
    float zInput = 0f;
    float moveSpeed = 10f;
    float turnSpeed = 1f;
    float jumpForce = 5;

    bool canJump = false;
    bool isMoving = false;
    bool Die = false;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        transform.position = new Vector3(73, 0, 48);
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Dot(collision.GetContact(0).normal, Vector3.up) > 0.5f) canJump = true; //바닥이라서 점프가능
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Plane") canJump = false; //점프시작하면 재점프 불가능
    }
    void Update()
    {
        if (GameManager.Inst.isGameOver)
        {
            isMoving = false;
            myAnimator.SetBool("Move", isMoving);
            return;
        }
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        moveSpeed = 15f;
        if(myRigidbody.velocity.magnitude < moveSpeed) moveSpeed = 25f;

        //movePos.x = xInput * Speed;
        movePos.z = zInput * moveSpeed;
        myRigidbody.AddRelativeForce(movePos * Time.deltaTime, ForceMode.VelocityChange);

        if (movePos != Vector3.zero) isMoving = true;
        else isMoving = false;

        myAnimator.SetBool("Move", isMoving);
        myAnimator.SetFloat("zAxis", zInput);

        myRotation.y += xInput*turnSpeed;
        myRigidbody.rotation = (Quaternion.Euler(myRotation));

        if (Input.GetKey(KeyCode.Q)) myAnimator.SetTrigger("Hi");
        if (canJump && Input.GetKey(KeyCode.Space)) Jumping();
    }

    void Jumping()
    {
        myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        myAnimator.SetTrigger("Jump");
        canJump = false;
    }
}
