using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] List<GameObject> ObstacleObjects;
    [SerializeField] Transform ObstaclePlace;
    void Start()
    {
        int x=Random.Range(0, ObstacleObjects.Count);
        Instantiate(ObstacleObjects[x],(ObstaclePlace.position),ObstacleObjects[x].transform.rotation);
    }

    
}
