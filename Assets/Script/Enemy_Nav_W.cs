using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav_W : MonoBehaviour
{
    public float range = 200;  // searching range

    public LayerMask whatIsTarget;
    public Transform targetPos;  // �߰ݴ�� transform

    private NavMeshAgent navMeshAgent;

    bool isFind = true;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

   
    private void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        
    }

    void Update()
    {
        
    }


}
