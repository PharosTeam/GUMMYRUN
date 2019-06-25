using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider bar;
    public GameManager manager;

    void Update()
    {
        bar.value = manager.scoreCount;
    }
}
