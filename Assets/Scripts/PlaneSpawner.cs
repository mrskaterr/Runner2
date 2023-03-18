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

    
    public static PlaneSpawner SharedInstance;
    public List<GameObject> obstacleObjects;
    public List<GameObject> pooledObjects;
    public List<GameObject> objectToPool;
    public List<GameObject> objectActive;
    private int amountToPool=3;
    Quaternion quaternion; 
    void Awake()
    {
        quaternion=Quaternion.Euler(new Vector3(0, -90, 0));
        SharedInstance = this;
    }

    void Start()
    {
        objectActive=new List<GameObject>();
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < objectToPool.Count; i++)
        {
            for(int j=0;j<amountToPool;j++)
            {
                tmp = Instantiate(objectToPool[j],Vector3.zero,quaternion);
                tmp.transform.SetParent(transform);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

        int Character=PlayerPrefs.GetInt ("Character");
        if(Character==0)
            Player=Michal;
        else if(Character==1)
            Player=Pawel;
        else if(Character==2)
            Player=Tomek;

        Player.SetActive(true);
        
        objectActive.Add( GetPooledObject() );

        
        objectActive.Add( GetPooledObject() );
        
    }
    public void Spwan()
    {
        if(objectActive.Count>2)
        {
            objectActive[0].SetActive(false);
            objectActive.RemoveAt(0);
        }
        objectActive.Add( GetPooledObject() );

        Sidewalk.transform.position=new Vector3(Player.transform.position.x,Sidewalk.transform.position.y,Sidewalk.transform.position.z);
    }
    
    private GameObject GetPooledObject()
    {
        int i=0;
        do
        {
            i=Random.Range(0,pooledObjects.Count);

        }while(pooledObjects[i].activeInHierarchy);
        
        if(objectActive.Count!=0)
            pooledObjects[i].transform.position=objectActive[objectActive.Count-1].transform.GetChild(1).position;
        pooledObjects[i].SetActive(true);
        return   pooledObjects[i];
    }
}
