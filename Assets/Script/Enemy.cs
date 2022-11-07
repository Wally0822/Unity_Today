using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("추격 속도")]
    [SerializeField][Range(1f, 10f)] float moveSpeed = 5f;
    [SerializeField][Range(10f, 50f)] float audioPlayRange = 20f;

    [Header("근접 거리")]
    [SerializeField][Range(1f, 10f)] float contactDistance = 1f;

    Transform player;

    private Rigidbody myrb = null;
    private Animator animator = null;
    private AudioSource enemySource = null;
    public AudioClip workAudio = null;

    bool isFollow = false;


    private void Awake()
    {
        myrb = GetComponent<Rigidbody>();
        enemySource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (Vector3.Distance(transform.position, player.position) > contactDistance && isFollow)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.LookAt(player.transform);
        }
        else
            myrb.velocity = Vector3.zero;

    }
    private void OnTriggerEnter(Collider other)
    {
        isFollow = true;

        Attack();

        //if (other.tag == "Player")
        //{
        //}
    }


    private void OnTriggerExit(Collider other)
    {
        isFollow = false;
        enemySource.Stop();

    }


    public void Attack()
    {
        //Debug.Log("잡았다 !!");
        if (Vector3.Distance(player.transform.position, transform.position) <= audioPlayRange)
        {
            Debug.Log(Vector3.Distance(player.transform.position, transform.position) <= audioPlayRange);
            enemySource.Play();
        }
        animator.SetBool("Attacks", true);

        //other.SendMessage("Attack", SendMessageOptions.RequireReceiver);
    }



}
