using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyJumpDetect : MonoBehaviour
{
    [SerializeField] GameObject AnimCollider;
    [SerializeField] GameObject DamageCollider;


    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.GetComponent<Player>() &&  collision.gameObject.GetComponent<Player>().isMonkeyJumping2)
        {
            AnimCollider.SetActive(true);
            collision.gameObject.GetComponent<Player>().isMonkeyJumping2=false;
        }
    }
}
