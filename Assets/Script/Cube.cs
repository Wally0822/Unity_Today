using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    void End()
    {
        StartCoroutine("cubeDestroy");
    }
    IEnumerator cubeDestroy()
    {
        while (gameObject.transform.position.y >= 0)
        {

            gameObject.transform.Translate(Vector3.down * Time.deltaTime);

        }
        gameObject.SetActive(false);

       yield return null;
    }
}
