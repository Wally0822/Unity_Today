using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    // 아이템 점수
    int score = 1;
    

    // 메시지 보내기
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // 플레이어와 아이템이 충돌 했을 때 UImanager로 센드메시지
        {
            //GAMEMANAGER.INST.
            GameManager.Inst.SendMessage("Score", SendMessageOptions.DontRequireReceiver);

            this.gameObject.SetActive(false);

          
        }        
    }    
}
