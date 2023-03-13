using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] List<GameObject> Characters;
    int i=0;
    void Update()
    {
        transform.Rotate(0,1f,0);
    }
    public void Next()
    {
            Characters[i].SetActive(false);
            if(++i>=Characters.Count)
                i=0;
            Characters[i].SetActive(true);
    }
    public void Previous()
    {
        Characters[i].SetActive(false);
        if(--i<0)
            i=Characters.Count-1;
        Characters[i].SetActive(true);
    }
    
    
}
