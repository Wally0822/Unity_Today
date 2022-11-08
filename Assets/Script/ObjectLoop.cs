using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoop : MonoBehaviour
{

    [SerializeField] float time;
    [SerializeField] float speed;
    [SerializeField] float ypos;
    [SerializeField] float length;
    private void Awake()
    {
        length = 0.5f;
    }

    void Update()
    {

        time += Time.deltaTime * speed;
        ypos = (Mathf.Sin(time) + 1) * length;

    }


}
