using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_JSP : MonoBehaviour
{
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        // find "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // follow player
        Vector3 CamPosition = target.position;
        CamPosition.y = transform.position.y;
        transform.position = CamPosition;

        transform.rotation = Quaternion.Euler(90, 0, -target.eulerAngles.y);
    }
}
