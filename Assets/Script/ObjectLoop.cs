using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoop : MonoBehaviour
{

    [SerializeField] float time;
    [SerializeField] float speed = 1f;
    [SerializeField] float length = 0.5f;
    [SerializeField] float ypos;

    public int dir = 0;
    public float up;
    public float down;

    private void Awake()
    {

    }
    private void Start()
    {
        
    }
    void Update()
    {
        
        up = speed * Time.deltaTime;
        down = -speed * Time.deltaTime;

        // 초당 speed의 속도로 오른쪽으로 평행이동

        if (transform.localPosition.y > 4f)
        {
            dir = 1;
        }
        if (transform.localPosition.y <= 2f)
        {
            dir = 0;
        }

        switch (dir)
        {
            case 0:
                transform.Translate(new Vector3(0, up,0));
                break;
            case 1:
                transform.Translate(new Vector3(0, down,0));
                break;
        }

        /*time += Time.deltaTime * speed;

        if (ypos >= 1.7f)
        {
            ypos = (Mathf.Sin(time)) * -length;
            this.transform.position = new Vector3(0, ypos, 0);
        }
        if (ypos <= 0.7f)
        {
            
            ypos = (Mathf.Sin(time)) * length;
            this.transform.position = new Vector3(0, ypos, 0);
        }*/
    }


}
