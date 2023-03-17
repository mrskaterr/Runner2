using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class czapa : MonoBehaviour
{
    [SerializeField] GameObject Head;
        // Start is called before the first frame update


    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation=Head.transform.rotation;
        //transform.position=Head.transform.position;
        //transform.position+=new Vector3(0.1f,0.3f,0f);
    }
}
