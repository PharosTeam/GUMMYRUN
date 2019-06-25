using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject[] locked;
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
                locked[i].SetActive(true);
            }
            else if (data.stage[i] == true)
            {
                locked[i].SetActive(false);
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
            percen.text = progress * 100 + "%";
            yield return null;
        }
    }
}
