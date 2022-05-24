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

    public void Pasue()
    {
        Debug.Log("pause");
        Time.timeScale=0f;
    }
    public void Resume()
    {
        Debug.Log("Resume");
        Time.timeScale=1f;
    }
    public void QuitButton()
    {
        Application.Quit();
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

}
