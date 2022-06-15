using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Transform endPoint;
    [SerializeField] List<GameObject> ObstacleObjects;
    [SerializeField] List<GameObject> ObstaclePlace;
    
    private int RandomBuff;

    void Start()
    {
        
        for(int i=0 ;i<ObstaclePlace.Count;i++)
        {
            RandomBuff=Random.Range(0, ObstacleObjects.Count);
            
            (Instantiate(ObstacleObjects[RandomBuff],(ObstaclePlace[i].transform.position),ObstacleObjects[RandomBuff].transform.rotation)).transform.SetParent(ObstaclePlace[i].transform);
        }
       
        
    }
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.GetComponentInChildren<Player>())
        {
            transform.parent.GetComponent<PlaneSpawner>().Spwan();
        }
    }

    
}
