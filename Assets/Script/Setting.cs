using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Button music, sfx, control;
    public AudioSource listMusic, listSfx;
    public AudioClip click;
    public Data data;
    public GameObject controlJS, controlSJ;
    public Sprite musicOn, musicOff, sfxOn, sfxOff;

    private void Awake()
    {
        listSfx = GetComponent<AudioSource>();
    }

    public void Music()
    {
        listSfx.PlayOneShot(click);
        if (!data.music)
        {
            music.GetComponent<Image>().sprite = musicOn;
            music.GetComponent<Image>().color = new Color(0, 255, 0);
            listMusic.volume = 1f;
            data.music = true;
        }
        else if (data.music)
        {
            music.GetComponent<Image>().sprite = musicOff;
            music.GetComponent<Image>().color = new Color(255, 0, 0);
            listMusic.volume = 0f;
            data.music = false;
        }
        data.saveData();
    }

    public void Sfx()
    {
        listSfx.PlayOneShot(click);
        if (!data.sfx)
        {
            sfx.GetComponent<Image>().sprite = sfxOn;
            sfx.GetComponent<Image>().color = new Color(0, 255, 0);
            listSfx.volume = 1f;
            data.sfx = true;
        }
        else if (data.sfx)
        {
            sfx.GetComponent<Image>().sprite = sfxOff;
            sfx.GetComponent<Image>().color = new Color(255, 0, 0);
            listSfx.volume = 0f;
            data.sfx = false;
        }
        data.saveData();
    }

    public void Control()
    {
        listSfx.PlayOneShot(click);
        if (!data.control)
        {
            controlJS.SetActive(false);
            controlSJ.SetActive(true);
            data.control = true;
        }
        else if (data.control)
        {
            controlJS.SetActive(true);
            controlSJ.SetActive(false);
            data.control = false;
        }
        data.saveData();
    }
}
