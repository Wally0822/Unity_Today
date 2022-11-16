using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        // player touched exit point
        if (collision.collider.tag == "Player")
            GameManager.Inst.Escaped();
    }



}
