using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    int Character;
    public void OnPlayButton()
    {
        PlayerPrefs.SetInt ("Character", Character);
        SceneManager.LoadScene("Game");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void Pasue()
    {
        Time.timeScale=0f;
    }
    public void Resume()
    {
        Time.timeScale=1f;
    }

    public void Next()
    {
        Character++;
        if(Character>2)Character=0;
    }
    public void Previous()
    {
        Character--;
        if(Character>0)Character=2;
    }
    public void Menu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }
    

}
