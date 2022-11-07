using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Wally : MonoBehaviour
{
    [SerializeField] float speed = 5f; 
    [SerializeField] float attackRange = 5f; // 공격 가능 범위
    [SerializeField] float attackPower = 10f;
    [SerializeField] Transform Player = null;

    CapsuleCollider myrb = null;

    private void Awake()
    {
        myrb = GetComponent<CapsuleCollider>();
    }

    private void OnEnable()
    {
        //nextState()
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public enum STATE
    {
        NONE,
        IDLE,
        ATTACK
    }

    STATE curState = STATE.NONE;

    void nextState(STATE newState)
    {
        if(newState == curState)
            return;
        
    }
}
