using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> plane;
    private GameObject lastPlane;
    private bool isTimeToSpawn=false;
    // Start is called before the first frame update
    void Start()
    {

        lastPlane=Instantiate(plane[Random.Range(0, plane.Count)],(new Vector3(0,0,0)),(Quaternion.Euler(new Vector3(0, -90, 0))));
        lastPlane.transform.SetParent(transform);
        StartCoroutine( Wait(3));
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isTimeToSpawn)
        {
            lastPlane=Instantiate(plane[Random.Range(0, plane.Count)],lastPlane.transform.GetChild(1).position,(Quaternion.Euler(new Vector3(0, -90, 0))));
            lastPlane.transform.SetParent(transform);
            isTimeToSpawn=false;
            StartCoroutine( Wait(3));
        }

    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isTimeToSpawn=true;
    }
}
