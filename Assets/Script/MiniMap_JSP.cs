using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_JSP : MonoBehaviour
{
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        // Player tag를 가진 gameobject를 찾아서 따라오기 
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CamPosition = target.position;
        CamPosition.y = transform.position.y;
        transform.position = CamPosition;
    }
}
