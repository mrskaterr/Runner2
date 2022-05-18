using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void SettingsButton()
    {
        
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
}
