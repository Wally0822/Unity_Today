using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoop : MonoBehaviour
{
    float myPos;
    float speed;
    private void Awake()
    {
        myPos = gameObject.transform.position.y;
        speed = 1.2f;
        //1.26
    }

    void Update()
    {
        MoveDown();
        if (myPos <= 1.0f)
        {
            MoveUp();
        }
        else if (myPos >= 1.4f)
        {
            MoveDown();
        }
    }

    private void MoveUp()
    {
        transform.position = transform.position + new Vector3(0, -1, 0) * speed * Time.deltaTime;
        //transform.position = (transform.position * 1.2f) * speed * Time.deltaTime;
    }
    private void MoveDown()
    {
        transform.position = transform.position + new Vector3(0, -1, 0) * speed * Time.deltaTime;
        //transform.position = (transform.position * -1.2f) * speed * Time.deltaTime;
    }
}
