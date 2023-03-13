using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    [SerializeField] List<GameObject> Characters;
    [SerializeField] GameObject Check;
    int i=0;
    void Start()
    {
        PlayerPrefs.SetInt ("0", 1);
        if( PlayerPrefs.GetInt("HAT")!=0 &&
            PlayerPrefs.GetInt("HAT")!=1 && 
            PlayerPrefs.GetInt("HAT")!=2 && 
            PlayerPrefs.GetInt("HAT")!=3 && 
            PlayerPrefs.GetInt("HAT")!=4 && 
            PlayerPrefs.GetInt("HAT")!=5)
            {
                PlayerPrefs.SetInt ("HAT", 0);
            }
        if( PlayerPrefs.GetInt("HAT")!=0 ) 
            Check.SetActive(true);
    }
    void Update()
    {
        transform.Rotate(0,1f,0);
    }
    public void Next()
    {   
        Characters[i].SetActive(false);
        if(++i>5)
            i=0;
        Characters[i].SetActive(true);
        if(PlayerPrefs.GetInt("HAT")==i)
            Check.SetActive(false);
        else
            Check.SetActive(true);
    }
    public void Previous()
    {
        Characters[i].SetActive(false);
        if(--i<0)
            i=5;
        Characters[i].SetActive(true);
        if(PlayerPrefs.GetInt("HAT")==i)
            Check.SetActive(false);
        else
            Check.SetActive(true);
    }
    public void CheckFunck()
    {
        Debug.Log(i);
        PlayerPrefs.SetInt ("HAT", i);
        Check.SetActive(false);
        Debug.Log(PlayerPrefs.GetInt ("HAT"));
    }
}
