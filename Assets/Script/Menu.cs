using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PauseMenu;
    public Button jump, slide;
    public bool pause, tap;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!tap)
            {
                Pause();
                tap = true;
            }
            else if (tap)
            {
                Resume();
                tap = false;
            }
        }
    }

    public void Retry(int index)
    {
        pause = false;
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }

    public void Next(int index)
    {
        pause = false;
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        pause = false;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pause = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    public void Pause()
    {
        pause = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}