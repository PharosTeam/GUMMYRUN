using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connect : MonoBehaviour
{
    public Button googlePlay, century;
    public AudioSource listSfx;
    public Data data;
    public AudioClip click;
    public Sprite gpOn, gpOff, cOn, cOff;

    public void GooglePlay()
    {
        listSfx.PlayOneShot(click);
        if (!data.gp)
        {
            googlePlay.GetComponent<Image>().sprite = gpOn;
            data.gp = true;
        }
        else if (data.gp)
        {
            googlePlay.GetComponent<Image>().sprite = gpOff;
            data.gp = false;
        }
        data.saveData();
    }

    public void Century()
    {
        listSfx.PlayOneShot(click);
        if (!data.century)
        {
            century.GetComponent<Image>().sprite = cOn;
            data.century = true;
        }
        else if (data.century)
        {
            century.GetComponent<Image>().sprite = cOff;
            data.century = false;
        }
        data.saveData();
    }
}
