using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject lvlSelectBox;
    public GameObject errorBox;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayButton()
    {
        if (PlayerData.Instance.lvl1completed) lvlSelectBox.SetActive(true);
        else UnityEngine.SceneManagement.SceneManager.LoadScene("cityOne");
    }

    public void GarageButton()
    {
        if (PlayerData.Instance.lvl1completed) UnityEngine.SceneManagement.SceneManager.LoadScene("garage");
        else errorBox.SetActive(true);
    }

    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        lvlSelectBox.SetActive(false);
    }

    public void MainMenuButton()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
        lvlSelectBox.SetActive(false);
        errorBox.SetActive(false);
    }

    public void QuitButton()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void BackButton()
    {
        lvlSelectBox.SetActive(false);
    }

    public void OkButton()
    {
        errorBox.SetActive(false);
    }

    public void Lvl1Button()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("cityOne");
    }

    public void Lvl2Button()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("cityTwo");
    }
}
