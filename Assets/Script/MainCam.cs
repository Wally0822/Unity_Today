using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] Camera cam = null;

    private void Awake()
    {
        if(player == null) player = FindObjectOfType<PlayerController>().transform;
        if(cam == null) cam = GetComponent<Camera>();
    }
    [SerializeField] Vector3 camPos = new Vector3(0, 1.5f, -3f);
    [SerializeField] Quaternion camRot = Quaternion.Euler(5f, 0f, 0f);
    [SerializeField] float interpolation = 5f;
    private void Start()
    {
        transform.position = camPos;
        transform.rotation = camRot;
    }
    private void Update()
    {
        this.transform.position = player.position + camPos;
        /*
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        foreach(Plane plane in planes)
        {
            if(plane.GetDistanceToPoint(player.position) < 0)
            {
                //¹ÛÀ¸·Î ¹þ¾î³²
                Debug.Log("¹þ¾î³²");
            }
        }*/

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, player.rotation, Time.deltaTime);
    }
}
