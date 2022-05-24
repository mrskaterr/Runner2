using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isPlayingAnimation=false;
    bool isDied=false;
    bool isGrounded=true;
    bool isWallRunning=false;
    bool isMonkeyJumping=false;
    public bool isMonkeyJumping2=false;
    bool isWallClimb=false;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI Record;
    [SerializeField] GameObject DeadScreen;
    [SerializeField] GameObject PauseButton;
    int intScore;
    [SerializeField] Camera MainCamera;
    [Space]
    [SerializeField] Animator animator;
    [SerializeField] Transform person;
    [Space]
    [SerializeField] List<Rigidbody> Ragdoll;
    [Space]
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;
    bool isJumpSwipe=false;
    bool isSlideSwipe=false;
    bool grav;

    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        Record.text="Record : "+PlayerPrefs.GetInt("Record").ToString();
        for(int i =0 ;i<Ragdoll.Count;i++)
        {
            Ragdoll[i].isKinematic = true;
            Ragdoll[i].detectCollisions = false;
        }
    }
    void FixedUpdate()
    {
        if(!isDied)
        {
            intScore=((int)transform.position.x/10);
            Score.text="Score : "+intScore.ToString();
            if (isGrounded)
            {
                moveDirection = new Vector3(1, 0f, 0f);
                moveDirection *= speed;

                if ((Input.GetKey(KeyCode.W) || isJumpSwipe ) && !isMonkeyJumping && !isPlayingAnimation && !isWallRunning)
                {
                    moveDirection.y = jumpSpeed;
                    animator.SetTrigger("maly skok");

                    isJumpSwipe=false;
                    if(isWallClimb)
                    {
                        animator.SetTrigger("wspiecie sie");
                        isWallClimb=false;
                    }

                }
                else if ((Input.GetKey(KeyCode.W) || isJumpSwipe ) && isMonkeyJumping && !isPlayingAnimation && !isWallRunning)
                {
                    isMonkeyJumping2=true;
                    isJumpSwipe=false;
                }
                else if ((Input.GetKey(KeyCode.S) || isSlideSwipe) && !isPlayingAnimation)
                {
                    transform.GetComponent<CapsuleCollider>().height=0.5f;
                    transform.GetComponent<CapsuleCollider>().center=new Vector3(0f,-1f,0f);
                    animator.SetTrigger("slide");
                    StartCoroutine(Wait(1f));
                    isSlideSwipe=false;
                }
            }
            else if(isWallRunning)
            {
                
                if(grav)gameObject.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
                
                transform.rotation=Quaternion.Euler(new Vector3(-30, 0, 0));
                if (Input.GetKey(KeyCode.Space))
                {
                    animator.SetTrigger("jump over");
                    transform.GetComponent<Rigidbody>().velocity=new Vector3(2f,0f,0f);
                    isWallRunning=false;
                    moveDirection.y = jumpSpeed;
                }
            }
            else
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            transform.position += moveDirection * Time.deltaTime;
            person.position=new Vector3(    transform.position.x,
                                            person.position.y,
                                            transform.position.z);
            MainCamera.transform.position=new Vector3(  transform.position.x,
                                                        MainCamera.transform.position.y,
                                                        MainCamera.transform.position.z
                                                        );
        }
        else
        {
            if(PlayerPrefs.GetInt("Record")<intScore)PlayerPrefs.SetInt("Record",intScore);
            for(int i =0 ;i<Ragdoll.Count;i++)
            {
                animator.enabled=false;
                Ragdoll[i].isKinematic = false;
                Ragdoll[i].detectCollisions = true;
            }
            DeadScreen.SetActive(true);
            PauseButton.SetActive(false);
        }

    }
    public void JumpSwipe()
    {
        isJumpSwipe=true;
    }
    public void SlideSwipe()
    {
        isSlideSwipe=true;
    }
    IEnumerator WallGravity(float waitTime)
    {
        grav=true;
        yield return new WaitForSeconds(waitTime);
        grav=false;
    }
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.GetComponent<CapsuleCollider>().height=1.8f;
        transform.GetComponent<CapsuleCollider>().center=new Vector3(0f,-0.3f,0f);
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.GetComponent<Cube>())
        {
            isDied=true;
        }
        
        else if(collision.gameObject.GetComponentInChildren<Ground>())
        {
            isGrounded=true;
        }


    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.GetComponentInChildren<Ground>())
        {
            isGrounded=false;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<Slowling>())
        {
            isJumpSwipe=false;
            speed/=2;
            animator.SetTrigger("potkniecie");
        }
        if(collision.gameObject.GetComponent<Wall>())
        {
            StartCoroutine(WallGravity(1f));
            isWallRunning=true;
        }
        if(collision.gameObject.GetComponent<Rail>() && !isPlayingAnimation )
        {
            animator.SetTrigger("monkey jump");
            collision.gameObject.GetComponent<Rail>().DisableCollider();
        }


    }
    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.GetComponent<BigCube>())
        {
            GetComponent<Rigidbody>().velocity=new Vector3(0f,2f,0f);
            isWallClimb=true;
        }
        if(collision.gameObject.GetComponent<MonkeyJumpDetect>())
        {
            isMonkeyJumping=true;
        }

    }
    void OnTriggerExit(Collider collision)
    {

        if(collision.gameObject.GetComponent<Slowling>())
        {
            speed*=2;
            isJumpSwipe=false;
        }
        if(collision.gameObject.GetComponent<Wall>())
        {
            transform.rotation=Quaternion.Euler(new Vector3(0, 0, 0));
            isWallRunning=false;
        }
        if(collision.gameObject.GetComponent<MonkeyJumpDetect>())
        {
            isMonkeyJumping=false;
        }
    }

}