using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("추격 속도")]
    [SerializeField] [Range (1f, 10f)] float moveSpeed = 5f;

    [Header("근접 거리")]
    [SerializeField][Range(1f, 10f)] float contactDistance = 1f;

    Transform player;
    //[SerializeField] Transform player = null;

    Rigidbody myrb = null;

    bool isFollow = false;

    private void Awake()
    {
        myrb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (Vector3.Distance(transform.position, player.position) > contactDistance && isFollow)
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        else
            myrb.velocity = Vector3.zero;

    }

    private void OnCollisionEnter(Collision collision)
    {
        isFollow = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isFollow = false;
    }


}
