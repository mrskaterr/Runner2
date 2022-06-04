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
    // Start is called before the first frame update
    void Start()
    {
        int Character=PlayerPrefs.GetInt ("Character");
        if(Character==0)
            Player=Michal;
        else if(Character==1)
            Player=Pawel;
        else if(Character==2)
            Player=Tomek;

        Player.transform.parent.gameObject.SetActive(true);
        
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
