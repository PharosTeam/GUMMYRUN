using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Button[] buton;
    public GameObject[] locked;
    public GameObject[] number;
    public GameObject[] star;
    public Slider bar;
    public Text percen;
    public Data data;

    public void loadLevel(int index)
    {
        StartCoroutine(LoadAsync(index));
    }

    void Update()
    {
        for(int i = 0; i < locked.Length; i++)
        {
            if(data.stage[i] == false)
            {
                buton[i].interactable = false;
                locked[i].SetActive(true);
                number[i].SetActive(false);
            }
            else if (data.stage[i] == true)
            {
                buton[i].interactable = true;
                locked[i].SetActive(false);
                number[i].SetActive(true);
                if (data.star[i] == 1)
                {
                    star[i + (2 * i)].SetActive(true);
                }
                else if (data.star[i] == 2)
                {
                    star[i + (2 * i)].SetActive(true);
                    star[i + (2 * i) + 1].SetActive(true);
                }
                else if (data.star[i] == 3)
                {
                    star[i + (2 * i)].SetActive(true);
                    star[i + (2 * i) + 1].SetActive(true);
                    star[i + (2 * i) + 2].SetActive(true);
                }
            }
        }
    }

    IEnumerator LoadAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.gameObject.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            bar.value = progress;
            percen.text = (progress * 100f).ToString("F0") + "%";
            yield return null;
        }
    }
}
