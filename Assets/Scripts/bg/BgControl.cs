using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBgcontral : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;
    public float speed = 1.0f;
    private float ImgSize;
    private float Tarpoint; 
    private void Start()
    {
        ImgSize = Screen.width;
        Tarpoint = ImgSize + bg1.transform.position.x;
        Debug.Log("ImgSize:" + ImgSize);
        bg2.transform.position =bg1.transform.position + Vector3.left * ImgSize;
        Debug.Log("bg1.x" + bg1.transform.position.x +¡¡"bg2.x" + bg2.transform.position.x);
    }
    void Update()
    {
        if (bg1.transform.position.x >= Tarpoint)
        {
            bg1.transform.position += 2 * Vector3.left * ImgSize;
        }
        if (bg2.transform.position.x >= Tarpoint)
        {
            bg2.transform.position += 2 * Vector3.left * ImgSize;
        }
        bg1.transform.position += Vector3.right * speed;
        bg2.transform.position += Vector3.right * speed;
    }
}
