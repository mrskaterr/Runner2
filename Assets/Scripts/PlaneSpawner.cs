using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] GameObject Plane;
    private GameObject LastPlane;
    bool isTimeToSpawn=false;
    // Start is called before the first frame update
    void Start()
    {
        LastPlane=Instantiate(Plane,(new Vector3(0,0,0)),(Quaternion.Euler(new Vector3(0, 0, 0))));
        LastPlane.transform.SetParent(transform);
        StartCoroutine( Wait(3));
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isTimeToSpawn)
        {
            LastPlane=Instantiate(Plane,LastPlane.transform.GetChild(1).position,(Quaternion.Euler(new Vector3(0, 0, 0))));
            LastPlane.transform.SetParent(transform);
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
