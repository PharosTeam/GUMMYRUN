using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public RectTransform rt;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rt.localScale = new Vector3(0.9f, 0.9f, 1);
        }
        if (Input.GetMouseButtonUp(0))
        {
            rt.localScale = new Vector3(1, 1, 1);
        }
    }
}
