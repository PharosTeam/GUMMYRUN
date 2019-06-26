using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public Animator menu, chapter, stage1, stage2, stage3, setting;
    public TextMeshPro total, chapter1, chapter2, chapter3;
    public Image bintang;
    public Data data;
    public int scene, chap1, chap2, chap3;
    public Setting seting;
    public bool pop;
    public GameObject exit;

    private void Awake()
    {
        scene = 0;
        pop = false;
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        string path = Application.persistentDataPath + "/playerData.txt";
        if (File.Exists(path))
        {
            data.loadData();
            for (int i = 0; i < 4; i++)
            {
                chap1 += data.star[i];
            }
            chapter1.text = chap1 + "/15";
            for (int i = 5; i < 9; i++)
            {
                chap2 += data.star[i];
            }
            chapter2.text = chap2 + "/15";
            for (int i = 10; i < 14; i++)
            {
                chap3 += data.star[i];
            }
            chapter3.text = chap3 + "/15";

            if (data.music)
            {
                seting.music.GetComponent<Image>().color = new Color(0, 255, 0);
                seting.listMusic.volume = 1f;
            }
            else if (!data.music)
            {
                seting.music.GetComponent<Image>().color = new Color(255, 0, 0);
                seting.listMusic.volume = 0f;
            }

            if (data.sfx)
            {
                seting.sfx.GetComponent<Image>().color = new Color(0, 255, 0);
                seting.listSfx.volume = 1f;
            }
            else if (!data.sfx)
            {
                seting.sfx.GetComponent<Image>().color = new Color(255, 0, 0);
                seting.listSfx.volume = 0f;
            }

            if (data.control)
            {
                seting.control.GetComponent<Image>().color = new Color(0, 255, 0);
            }
            else if (!data.control)
            {
                seting.control.GetComponent<Image>().color = new Color(255, 0, 0);
            }
        }
        else
        {
            data.stage = new bool[15];
            data.star = new int[15];
            data.totalStar = 0;
            for (int i = 0; i < data.star.Length - 1; i++)
            {
                data.star[i] = 0;
                data.stage[i] = false;
            }
            data.music = true;
            data.sfx = true;
            data.control = true;
            data.saveData();
        }
        total.text = "x " + data.totalStar;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (scene)
            {
                case 0: if (!pop)
                        {
                            pop = true;
                            exit.SetActive(true);
                        }
                        else if (pop)
                        {
                            pop = false;
                            exit.SetActive(false);
                        }
                        break;
                case 1: ChapterToMenu(); break;
                case 2: Stage1ToChapter(); break;
                case 3: Stage2ToChapter(); break;
                case 4: Stage3ToChapter(); break;
                case -1: SettingIn(); break;
            }
        }
    }

    public void MenuToChapter()
    {
        scene = 1;
        seting.listSfx.PlayOneShot(seting.click);
        if (menu.GetInteger("Flow") == 0)
        {
            menu.SetInteger("Flow", -1);
        }
        else
        {
            menu.SetInteger("Flow", 1);
        }

        if (chapter.GetInteger("Flow") == 0)
        {
            chapter.SetInteger("Flow", -1);
        }
        else
        {
            chapter.SetInteger("Flow", 1);
        }
    }

    public void ChapterToMenu()
    {
        scene = 0;
        seting.listSfx.PlayOneShot(seting.click);
        menu.SetInteger("Flow", 2);
        if (chapter.GetInteger("Flow") == 1 || chapter.GetInteger("Flow") == -1)
        {
            chapter.SetInteger("Flow", 2);
        }else if(chapter.GetInteger("Flow") == 4)
        {
            chapter.SetInteger("Flow", 6);
        }
    }

    public void ChapterToStage1()
    {
        scene = 2;
        seting.listSfx.PlayOneShot(seting.click);
        if (chapter.GetInteger("Flow") == 1 || chapter.GetInteger("Flow") == -1)
        {
            chapter.SetInteger("Flow", 3);
        }
        else if (chapter.GetInteger("Flow") == 4)
        {
            chapter.SetInteger("Flow", 5);
        }

        if(stage1.GetInteger("Flow") == 0)
        {
            stage1.SetInteger("Flow", -1);
        }
        else
        {
            stage1.SetInteger("Flow", 1);
        }
    }

    public void Stage1ToChapter()
    {
        scene = 1;
        seting.listSfx.PlayOneShot(seting.click);
        chapter.SetInteger("Flow", 4);
        if (stage1.GetInteger("Flow") == 1 || stage1.GetInteger("Flow") == -1)
        {
            stage1.SetInteger("Flow", 2);
        }
    }

    public void ChapterToStage2()
    {
        scene = 3;
        seting.listSfx.PlayOneShot(seting.click);
        if (chapter.GetInteger("Flow") == 1 || chapter.GetInteger("Flow") == -1)
        {
            chapter.SetInteger("Flow", 3);
        }
        else if (chapter.GetInteger("Flow") == 4)
        {
            chapter.SetInteger("Flow", 5);
        }

        if (stage2.GetInteger("Flow") == 0)
        {
            stage2.SetInteger("Flow", -1);
        }
        else
        {
            stage2.SetInteger("Flow", 1);
        }
    }

    public void Stage2ToChapter()
    {
        scene = 1;
        seting.listSfx.PlayOneShot(seting.click);
        chapter.SetInteger("Flow", 4);
        if (stage2.GetInteger("Flow") == 1 || stage2.GetInteger("Flow") == -1)
        {
            stage2.SetInteger("Flow", 2);
        }
    }

    public void ChapterToStage3()
    {
        scene = 4;
        seting.listSfx.PlayOneShot(seting.click);
        if (chapter.GetInteger("Flow") == 1 || chapter.GetInteger("Flow") == -1)
        {
            chapter.SetInteger("Flow", 3);
        }
        else if (chapter.GetInteger("Flow") == 4)
        {
            chapter.SetInteger("Flow", 5);
        }

        if (stage3.GetInteger("Flow") == 0)
        {
            stage3.SetInteger("Flow", -1);
        }
        else
        {
            stage3.SetInteger("Flow", 1);
        }
    }

    public void Stage3ToChapter()
    {
        scene = 1;
        seting.listSfx.PlayOneShot(seting.click);
        chapter.SetInteger("Flow", 4);
        if (stage3.GetInteger("Flow") == 1 || stage3.GetInteger("Flow") == -1)
        {
            stage3.SetInteger("Flow", 2);
        }
    }

    public void SettingOut()
    {
        scene = -1;
        seting.listSfx.PlayOneShot(seting.click);
        setting.SetInteger("Flow", 1);
    }

    public void SettingIn()
    {
        scene = 0;
        seting.listSfx.PlayOneShot(seting.click);
        setting.SetInteger("Flow", 2);
    }

    public void confirm()
    {
        seting.listSfx.PlayOneShot(seting.click);
        Application.Quit();
    }

    public void cancel()
    {
        seting.listSfx.PlayOneShot(seting.click);
        exit.SetActive(false);
        pop = false;
    }
}
