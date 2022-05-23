using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] List<GameObject> Characters;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,1f,0);
    }
    public void Next()
    {
        if(Characters[0].activeInHierarchy)
        {
            Characters[0].SetActive(false);
            Characters[1].SetActive(true);
        }
        else if(Characters[1].activeInHierarchy)
        {
            Characters[1].SetActive(false);
            Characters[2].SetActive(true);
        }
        else if(Characters[2].activeInHierarchy)
        {
            Characters[2].SetActive(false);
            Characters[0].SetActive(true);
        }
    }
    public void Previous()
    {
        if(Characters[2].activeInHierarchy)
        {
            Characters[2].SetActive(false);
            Characters[1].SetActive(true);
        }
        else if(Characters[1].activeInHierarchy)
        {
            Characters[1].SetActive(false);
            Characters[0].SetActive(true);
        }
        else if(Characters[0].activeInHierarchy)
        {
            Characters[0].SetActive(false);
            Characters[2].SetActive(true);
        }
    }
    
    
}
