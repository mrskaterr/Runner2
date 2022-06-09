using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject Tutorial;
    int Character=0;
    int Hat;
    public void OnPlayButton()
    {
        PlayerPrefs.SetInt ("Character", Character);
        if(PlayerPrefs.GetInt("Record")!=0)
        {
            Retry();
        }
        else 
        {
            Tutorial.SetActive(true);
        }

        
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
        if(Character<0)Character=2;
    }
    public void Menu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }
    public void Next2()
    {
        Hat++;
        if(Hat>5)Hat=1;
    }
    public void Previous2()
    {
        Hat--;
        if(Hat>1)Hat=2;
    }
    

}
