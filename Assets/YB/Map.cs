using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] Texture2D texture;
    [SerializeField] GameObject plane;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject item;

    [SerializeField] float mapsize = 100;

    void Start()
    {
        plane.transform.position = new Vector3(mapsize / 2, 0, mapsize / 2);
        plane.transform.localScale = new Vector3(mapsize/10, 0.1f, mapsize/10);
        MapSetting();
    }

    void MapSetting()
    {
        int itemNum = 0;
        float tx, tz;
        Vector3 point = new Vector3();
        GameObject mapcube;
        GameObject mapitem;

        for (int z = 0; z < mapsize; z++)
        {
            for(int x = 0; x < mapsize; x++)
            {
                tx = x / mapsize - 1;
                tz = z / mapsize - 1;

                point.x = x;
                point.z = z;
                point.y = texture.GetPixel(Mathf.FloorToInt(texture.width * tx), Mathf.FloorToInt(texture.height * tz)).grayscale;

                if(point.y > 0.3)
                {
                    point.y = 1.5f;
                    mapcube = Instantiate(cube, point, Quaternion.identity, this.transform);
                }
                else
                {
                    point.y = texture.GetPixel(Mathf.FloorToInt(texture.width * tx), Mathf.FloorToInt(texture.height * tz)).b;
                    if (point.y > 0.7 && itemNum%2 ==0)
                    {
                        point.y = 1f;
                        mapitem = Instantiate(item, point, Quaternion.identity, this.transform);
                    }

                }
                itemNum++;
            }
        }
        
    }
}
