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
    public void QuitButton()
    {
        Application.Quit();
    }
}
