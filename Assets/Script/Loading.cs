using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider bar;
    public Text percen;
    public Data data;

    public void loadLevel(int index)
    {
        StartCoroutine(LoadAsync(index));
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
