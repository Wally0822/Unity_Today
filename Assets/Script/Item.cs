using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    // ������ ����
    int score = 1;
    

    // �޽��� ������
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // �÷��̾�� �������� �浹 ���� �� UImanager�� ����޽���
        {
            //GAMEMANAGER.INST.
            GameManager.Inst.SendMessage("Score", SendMessageOptions.DontRequireReceiver);

            this.gameObject.SetActive(false);

          
        }        
    }    
}
