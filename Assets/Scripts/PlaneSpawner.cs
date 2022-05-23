using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> plane;
    [SerializeField] GameObject Sidewalk;
    [SerializeField] GameObject Michal;
    [SerializeField] GameObject Tomek;
    [SerializeField] GameObject Pawel;
    GameObject Player;
    private GameObject lastPlane;
    private bool isTimeToSpawn=false;
    // Start is called before the first frame update
    void Start()
    {
        if(Michal.activeInHierarchy) Player=Michal;
        else if(Tomek.activeInHierarchy) Player=Tomek;
        else if(Pawel.activeInHierarchy) Player=Pawel;

        lastPlane=Instantiate(plane[Random.Range(0, plane.Count)],(new Vector3(0,0,0)),(Quaternion.Euler(new Vector3(0, -90, 0))));
        lastPlane.transform.SetParent(transform);
        lastPlane=Instantiate(plane[Random.Range(0, plane.Count)],lastPlane.transform.GetChild(1).position,(Quaternion.Euler(new Vector3(0, -90, 0))));
        lastPlane.transform.SetParent(transform);
    }

    public void Spwan()
    {
        if(transform.childCount>2)Destroy(transform.GetChild(0).gameObject);

        lastPlane=Instantiate(plane[Random.Range(0, plane.Count)],lastPlane.transform.GetChild(1).position,(Quaternion.Euler(new Vector3(0, -90, 0))));
        lastPlane.transform.SetParent(transform);

        Sidewalk.transform.position=new Vector3(Player.transform.position.x,Sidewalk.transform.position.y,Sidewalk.transform.position.z);
    }
}
