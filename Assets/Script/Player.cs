using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // void FixedUpdate()
    // {
    //     GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
    //     if(Speed>0)
    //     {
    //         gameObject.transform.position+=new Vector3(Speed,0,0);
    //     }
        
    //     if(Input.GetKey(KeyCode.Space) && isGounded)
    //     {
    //         gameObject.GetComponent<Rigidbody>().velocity+=new Vector3(0,JumpPower,0);
    //     }
    // }
    bool isDied=false;
    bool isGrounded=true;
    [SerializeField] Camera MainCamera;
    [Space]
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;

    private Vector3 moveDirection = Vector3.zero;
    // CharacterController controller;
    // void Start()
    // {
    //     controller=GetComponent<CharacterController>();
    // }
    // void Update()
    // {
    //     if(!isDied)
    //     {
    //         if (controller.isGrounded)
    //         {
    //             moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    //             moveDirection *= speed;

    //             if (Input.GetButton("Jump"))
    //             {
    //                 moveDirection.y = jumpSpeed;
    //             }
    //         }
    //         moveDirection.y -= gravity * Time.deltaTime;

    //         controller.Move(moveDirection * Time.deltaTime);
    //         MainCamera.transform.position=new Vector3(transform.position.x,MainCamera.transform.position.y,MainCamera.transform.position.z);
    //     }
    // }
    void FixedUpdate()
    {
        if(!isDied)
        {
            //Debug.Log(Input.GetAxis("Horizontal"));
            if (isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                moveDirection *= speed;

                if (Input.GetKey(KeyCode.W))
                {
                    moveDirection.y = jumpSpeed;
                    transform.eulerAngles=new Vector3(0f,0f,0f);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.eulerAngles=new Vector3(0f,0f,90f);
                }
            }
            else
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            transform.position+=moveDirection * Time.deltaTime;
            
            MainCamera.transform.position=new Vector3(  transform.position.x,
                                                        MainCamera.transform.position.y,
                                                        MainCamera.transform.position.z
                                                        );
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Cube>())
        {
            Debug.Log("Cube");
            isDied=true;
        }
        else if(collision.gameObject.GetComponent<BigCube>())
        {
            GetComponent<Rigidbody>().velocity+=new Vector3(0f,10f,0f);
        }
        else if(collision.gameObject.GetComponent<Ground>())
        {
            isGrounded=true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.GetComponent<Ground>())
        {
            isGrounded=false;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<Slowling>())
        {
            speed/=2;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.GetComponent<Slowling>())
        {
            speed*=2;
        }
    }

}
