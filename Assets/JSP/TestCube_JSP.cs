using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube_JSP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        if (xAxis != 0 || zAxis != 0)
        {
            transform.position = new Vector3(transform.position.x + xAxis * 10f * Time.deltaTime, 0f, transform.position.z + zAxis * 10f * Time.deltaTime);
        }
    }
}
