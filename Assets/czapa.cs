using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class czapa : MonoBehaviour
{
    [SerializeField] GameObject Head;
    [SerializeField] GameObject Hat;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Hat.transform.rotation=Head.transform.rotation;
        Hat.transform.position=Head.transform.position;
        Hat.transform.position+=new Vector3(0.1f,0.2f,0f);
    }
}
