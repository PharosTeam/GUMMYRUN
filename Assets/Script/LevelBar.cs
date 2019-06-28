using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Slider bar;
    public GameManager manager;
    public Sprite bStar, yStar;
    public GameObject star1, star2, star3;

    void Update()
    {
        bar.value = manager.scoreCount;

        if (manager.scoreCount >= manager.get1)
        {
            star1.GetComponent<Image>().sprite = yStar;
        }
        else
        {
            star1.GetComponent<Image>().sprite = bStar;
        }

        if (manager.scoreCount >= manager.get2)
        {
            star2.GetComponent<Image>().sprite = yStar;
        }
        else
        {
            star2.GetComponent<Image>().sprite = bStar;
        }

        if (manager.scoreCount >= manager.get3)
        {
            star3.GetComponent<Image>().sprite = yStar;
        }
        else
        {
            star3.GetComponent<Image>().sprite = bStar;
        }
    }
}
