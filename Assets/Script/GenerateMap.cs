using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    Color color;
    Vector3 point;
    Vector3[] vertice;

    [SerializeField] GameObject ground;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject item;
    [SerializeField] Texture2D MapImage;
    [SerializeField] int resolution = 10;
    [SerializeField] int mapValue = 5;

    // ������ ����
    [SerializeField] int itemMin = 0;
    [SerializeField] int itemMax = 100;

    GameObject[] items;

    int vtxIndex;
    float tx;
    float tz;

    private void Awake()
    {
        Vector3 groundPos = new Vector3(80,0,80);
        // �̹��� ������ return
        if (MapImage == null) return;
        Instantiate(ground, groundPos, Quaternion.identity, this.transform.parent);

    }
    private void Start()
    {

        items = new GameObject[itemMax];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = item;
        }

        vertice = new Vector3[resolution * resolution];
        point = Vector3.zero;

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                int rnd = Random.Range(0, 22);
                // ������� ���� �־���
                vtxIndex = x + y * resolution;

                tx = (float)x / (resolution - 1f);
                tz = (float)y / (resolution - 1f);

                point.x = x;
                point.y = MapImage.GetPixel(Mathf.FloorToInt(MapImage.height * tx), Mathf.FloorToInt(MapImage.width * tz)).grayscale;
                point.z = y;
                // grayscale 0-1���� ���������� �� Ű��� ���� ���� / ��� = 1 / ���� = 0

                vertice[vtxIndex] = point;

                if (point.y <= 0.08)
                {
                    //point = new Vector3(point.x, 0, point.z);
                    point.y = 0;
                    Instantiate(cube, point, Quaternion.identity, this.transform.parent);
                }
                else if (point.y <= 0.7) // itemMin <= itemMax && 
                {
                    if (itemMin <= itemMax)
                    {
                        point.y = MapImage.GetPixel(Mathf.FloorToInt(MapImage.height * tx), Mathf.FloorToInt(MapImage.width * tz)).r;
                        if (point.y > 0.7 && rnd== 0)
                        {
                            //point = new Vector3(point.x, 1, point.z);
                            point.y = 1;
                            // �迭�� ���� ������ �ϳ��� ����
                            Instantiate(item, point, Quaternion.identity);
                            //itemMin++;
                        }
                        
                    }

                }


            }
        }

        
    }


}
