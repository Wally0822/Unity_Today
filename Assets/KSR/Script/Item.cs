using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    // ������ ����
    int score = 1;
    
    private void Awake()
    {
        
    }

    // �޽��� ������
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // �÷��̾�� �������� �浹 ���� �� UImanager�� ����޽���
        {
            //GAMEMANAGER.INST.
            other.SendMessage("GetScore", SendMessageOptions.DontRequireReceiver);
        }        
    }    
}
