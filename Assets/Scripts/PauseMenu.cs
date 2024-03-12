using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject hud;
    private bool isPaused;
    public string currentScene;
    public static bool pausingEnabled;  // remember to turn back on after using !!!!!

    private void pauseResume()
    {
        pauseMenu.SetActive(isPaused);
        hud.SetActive(!isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        pausingEnabled = true;
        isPaused = false;
        pauseResume();
    }

    // Update is called once per frame
    void Update()
    {
        // toggle pause menu with "esc" key
        if (pausingEnabled && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseResume();
        }
    }

    public void ResumeButton()
    {
        isPaused = false;
        pauseResume();
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("mainMenu");
    }

    public void QuitToDesktopButton()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
