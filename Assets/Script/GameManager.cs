using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public int scoreCount, level, get1, get2, get3;
    public TextMeshPro score, tutorial;
    public Image victory, gameOver, gray;
    public GameObject star1, star2, star3;
    public bool tutor1 = false, tutor2 = false, tutor3 = false, tutor4 = false, tutor5 = false, tutor6 = false, done = false;
    public Movement karakter;
    public Data data;
    public AudioSource listMusic, listSfx;
    public RectTransform jump, slide;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        data.loadData();
        scoreCount = 0;

        string path = Application.persistentDataPath + "/playerData.txt";
        if (File.Exists(path))
        {
            data.loadData();

            if (data.music)
            {
                listMusic.volume = 1f;
            }
            else if (!data.music)
            {
                listMusic.volume = 0f;
            }

            if (data.sfx)
            {
                listSfx.volume = 1f;
            }
            else if (!data.sfx)
            {
                listSfx.volume = 0f;
            }

            if (data.control)
            {
                jump.offsetMin += new Vector2(0, 0);
                jump.offsetMax -= new Vector2(0, 0);
                slide.offsetMin += new Vector2(0, 0);
                slide.offsetMax -= new Vector2(0, 0);
            }
            else if (!data.control)
            {
                jump.offsetMin += new Vector2(-800, 0);
                jump.offsetMax -= new Vector2(800, 0);
                slide.offsetMin += new Vector2(800, 0);
                slide.offsetMax -= new Vector2(-800, 0);
            }
        }
    }

    void Update()
    {
            score.text = "x " + scoreCount;
        GameObject[] a = GameObject.FindGameObjectsWithTag("orange");
        foreach (GameObject o in a)
        {
            o.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 150));
        }
        GameObject[] b = GameObject.FindGameObjectsWithTag("strawberry");
        foreach (GameObject o in b)
        {
            o.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 150));
        }
        GameObject[] c = GameObject.FindGameObjectsWithTag("pineapple");
        foreach (GameObject o in c)
        {
            o.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 100));
        }

        if(karakter.finish == true && done == false)
        {
            if (scoreCount >= get3)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                if(data.star[level] < 3)
                {
                    data.star[level] = 3;
                }
            }
            else if(scoreCount >= get2)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                if (data.star[level] < 2)
                {
                    data.star[level] = 2;
                }
            }
            else if(scoreCount >= get1)
            {
                star1.SetActive(true);
                if (data.star[level] < 1)
                {
                    data.star[level] = 1;
                }
            }
            data.stage[level] = true;
            data.saveData();
            done = true;
        }
    }
}
