using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    [SerializeField] List<GameObject> Characters;
    [SerializeField] GameObject Watch;
    [SerializeField] GameObject Check;

    void Start()
    {
        PlayerPrefs.SetInt ("0", 1);
        PlayerPrefs.SetInt ("HAT", 0);
    }
    void Update()
    {
        transform.Rotate(0,1f,0);
    }
    public void Next()
    {
        if(Characters[0].activeInHierarchy)
        {
            Characters[0].SetActive(false);
            if(PlayerPrefs.GetInt("1")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }

            Characters[1].SetActive(true);
        }
        else if(Characters[1].activeInHierarchy)
        {
            Characters[1].SetActive(false);
            if(PlayerPrefs.GetInt("2")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[2].SetActive(true);
        }
        else if(Characters[2].activeInHierarchy)
        {
            Characters[2].SetActive(false);
            if(PlayerPrefs.GetInt("3")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[3].SetActive(true);
        }
        else if(Characters[3].activeInHierarchy)
        {
            Characters[3].SetActive(false);
            if(PlayerPrefs.GetInt("4")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[4].SetActive(true);
        }
        else if(Characters[4].activeInHierarchy)
        {
            Characters[4].SetActive(false);
            if(PlayerPrefs.GetInt("5")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[5].SetActive(true);
        }
        else if(Characters[5].activeInHierarchy)
        {
            Characters[5].SetActive(false);
            if(PlayerPrefs.GetInt("0")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[0].SetActive(true);
        }
    }
    public void Previous()
    {
        if(Characters[5].activeInHierarchy)
        {
            Characters[5].SetActive(false);
            if(PlayerPrefs.GetInt("4")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[4].SetActive(true);
        }
        if(Characters[4].activeInHierarchy)
        {
            Characters[4].SetActive(false);
            if(PlayerPrefs.GetInt("3")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[3].SetActive(true);
        }
        else if(Characters[3].activeInHierarchy)
        {
            Characters[3].SetActive(false);
            if(PlayerPrefs.GetInt("2")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[2].SetActive(true);
        }
        else if(Characters[2].activeInHierarchy)
        {
            Characters[2].SetActive(false);
            if(PlayerPrefs.GetInt("1")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[1].SetActive(true);
        }
        else if(Characters[1].activeInHierarchy)
        {
            Characters[1].SetActive(false);
            if(PlayerPrefs.GetInt("0")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
            Characters[0].SetActive(true);
        }
        else if(Characters[0].activeInHierarchy)
        {
            Characters[0].SetActive(false);
            if(PlayerPrefs.GetInt("5")==1)
            {
                Watch.SetActive(false);
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
                Watch.SetActive(true);
            }
                
            Characters[5].SetActive(true);
        }
       
    }
    public void WatchAd()
    {
        if(Characters[0].activeInHierarchy)PlayerPrefs.SetInt ("0", 1);
        else if(Characters[1].activeInHierarchy)PlayerPrefs.SetInt ("1", 1);
        else if(Characters[2].activeInHierarchy)PlayerPrefs.SetInt ("2", 1);
        else if(Characters[3].activeInHierarchy)PlayerPrefs.SetInt ("3", 1);
        else if(Characters[4].activeInHierarchy)PlayerPrefs.SetInt ("4", 1);
        else if(Characters[5].activeInHierarchy)PlayerPrefs.SetInt ("5", 1);
        Watch.SetActive(false);
        Check.SetActive(true);
        }
    public void CheckFunck()
    {
        if(Characters[0].activeInHierarchy)PlayerPrefs.SetInt ("HAT", 0);
        else if(Characters[1].activeInHierarchy)PlayerPrefs.SetInt ("HAT", 1);
        else if(Characters[2].activeInHierarchy)PlayerPrefs.SetInt ("HAT", 2);
        else if(Characters[3].activeInHierarchy)PlayerPrefs.SetInt ("HAT", 3);
        else if(Characters[4].activeInHierarchy)PlayerPrefs.SetInt ("HAT", 4);
        else if(Characters[5].activeInHierarchy)PlayerPrefs.SetInt ("HAT", 5);
         Check.SetActive(false);
    }
}
